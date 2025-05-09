using System.Diagnostics;
using UntappedAPI.DatabaseContext;
using UntappedAPI.Models;
using System.Linq;

namespace UntappedAPI.Service
{
    public class PlayerDiscoveryService
    {
        private readonly UntappedApiService _untappedApiService;
        private readonly UntappedDbContext _untappedDbContext;
        private readonly TotalProgressService _totalProgressService;
        private Queue<string> _playerIdsQueue;
        private int _amountOfNewPlayersFound = 0;


        public PlayerDiscoveryService(UntappedApiService dataCollectorService, UntappedDbContext untappedDbContext, TotalProgressService totalProgressService)
        {
            _untappedApiService = dataCollectorService;
            _playerIdsQueue = new Queue<string>();
            _untappedDbContext = untappedDbContext;
            _totalProgressService = totalProgressService;
        }


        public async Task<string> StartQueueOnSpecificPlayer(string profileId)
        {
            //STEP 1: Seed First Player   
            _playerIdsQueue.Enqueue(profileId);

            //STEP 2: work on que while also adding new players to the que
            while (_playerIdsQueue.Count != 0)
            {
                Console.WriteLine($"Total Players found so far {_totalProgressService.newPlayersFound}!");
                await StartWorkingOnQueue();
                
            }

            return $"StartWorkingOnQueue done, no more in Queue";
        }


        public async Task StartWorkingOnQueue()
        {            

            //TODO: Make this a ConsoleLogger wrapper
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Queue status: Id's in Queue = {_playerIdsQueue.Count} -- Players saved this session = {_amountOfNewPlayersFound}");
            Console.ForegroundColor = ConsoleColor.White;


            string currentPlayerId = _playerIdsQueue.Dequeue();


            //TODO: improve this so there is not 2x db calls
            var isPlayerIdWorthLookingUp = IsWorthDoingLookUpSearch(currentPlayerId);
            if (isPlayerIdWorthLookingUp is false)
            {
                Console.WriteLine($"Player {currentPlayerId} not worth looking up ");
                AddPlayerIdsToQue();
                return ; 
            }


            //**Medium Snapshot - All players at this point are ether Light unknow and worth saving to db
            var snapshotExists = _untappedDbContext.Set<PlayerSnapshot>().Any(snapshot => snapshot.ProfileId == currentPlayerId);



            if (snapshotExists is false)
            {
                await CreateAndSaveMediumSnapshot(currentPlayerId);

            }
            else
            {
                await UpdateMediumSnapshot(currentPlayerId);

            }

            await CreateAndSaveLightSnapshots(currentPlayerId);

            AddPlayerIdsToQue();

            _totalProgressService.newPlayersFound =+ _amountOfNewPlayersFound;
            Console.WriteLine($"Total Players found so far {_totalProgressService.newPlayersFound}!");

            return ;
        }

        /// <summary>
        /// Will add new Id if they are not in the que already
        /// </summary>
        /// <returns></returns>
        private void AddPlayerIdsToQue()
        {
            var lightRichnessPlayerIds = _untappedDbContext.Set<PlayerSnapshot>()
                .Where(snapshot => snapshot.InfoRichness == InfoRichness.Light_NameAndIdKnow)
                .Select(snapshot => snapshot.ProfileId)
                .ToList();


            foreach (var playerId in lightRichnessPlayerIds.Where(playerId => _playerIdsQueue.Contains(playerId) is false))
            { _playerIdsQueue.Enqueue(playerId); }


        }

        private async Task CreateAndSaveLightSnapshots(string currentPlayerId)
        {
            var allOpponentSet_Id_Name = await GetOpponentIdsFromMatchHistory(currentPlayerId);
            var lightSnapshotsToBeProcessed = new List<PlayerSnapshot>();

            //TOD: improve so we do not create the Player-snapshot before we know it is not in the db
            foreach (var set_Id_Name in allOpponentSet_Id_Name)
            {
                var lightSnapshot = await CreateLightSnapshotFromPlayerHistory(set_Id_Name.Key, set_Id_Name.Value);
                lightSnapshotsToBeProcessed.Add(lightSnapshot);
            }


            var notYetKnownPlayerSnapshot = CheckIflightSnapshotOfPlayerIdExistsInDb(lightSnapshotsToBeProcessed);

            _untappedDbContext.AddRange(notYetKnownPlayerSnapshot);
            await _untappedDbContext.SaveChangesAsync();


            _amountOfNewPlayersFound = +notYetKnownPlayerSnapshot.Count;
            Console.WriteLine($"current Player has meet {allOpponentSet_Id_Name.Count} Opponents --  {notYetKnownPlayerSnapshot.Count} was new discoveries");
        }

        private async Task UpdateMediumSnapshot(string currentPlayerId)
        {
            var existingPlayerSnapshot = _untappedDbContext.Set<PlayerSnapshot>().Where(x => x.ProfileId == currentPlayerId).First();

            var playerLookUpDto = await _untappedApiService.GetPlayerLookUpDto(currentPlayerId);
            if (playerLookUpDto is null)
            { return; }


            existingPlayerSnapshot.MatchHistoryVisibility = playerLookUpDto?.matchHistoryVisibility?.RANKED_1V1;
            existingPlayerSnapshot.ReplayVisibility = playerLookUpDto?.replayVisibility?.RANKED_1V1;
            existingPlayerSnapshot.LastSnapshot = DateTime.UtcNow;
            existingPlayerSnapshot.InfoRichness = InfoRichness.Medium_Lookup;

            await _untappedDbContext.SaveChangesAsync();
        }

        private async Task CreateAndSaveMediumSnapshot(string currentPlayerId)
        {
            var mediumPlayerSnapshot = await CreateMediumSnapshotByPlayerLookUpDto(currentPlayerId);
            if (mediumPlayerSnapshot is null)
            {
                return;
            }

            _untappedDbContext.Add(mediumPlayerSnapshot);
            await _untappedDbContext.SaveChangesAsync();

            _amountOfNewPlayersFound++;
            Console.WriteLine($"mediumPlayerSnapshot was saved: {mediumPlayerSnapshot.ProfileId} -- {mediumPlayerSnapshot.PlayerName} ");
        }

        /// <summary>
        /// Returns a list of PlayerSnapshot that are not already in the database.
        /// </summary>
        /// <param name="lightSnapshotsToBeSaved"></param>
        /// <returns></returns>
        private List<PlayerSnapshot> CheckIflightSnapshotOfPlayerIdExistsInDb(List<PlayerSnapshot> lightSnapshotsToBeSaved)
        {
            var notYetKnownPlayerSnapshot = new List<PlayerSnapshot>();

            foreach (var lightSnapshot in lightSnapshotsToBeSaved)
            {
                var existsInDb = _untappedDbContext.Set<PlayerSnapshot>()
                    .Any(snapshot => snapshot.ProfileId == lightSnapshot.ProfileId);

                if (existsInDb is false)
                {
                    notYetKnownPlayerSnapshot.Add(lightSnapshot);
                }
            }

            return notYetKnownPlayerSnapshot;
        }

        private async Task<Dictionary<string, string>> GetOpponentIdsFromMatchHistory(string playerId)
        {

            var opponentSet_Id_Name = new Dictionary<string, string>();

            var statsCuratedDto = await _untappedApiService.GetPlayerStats(playerId, "ranked_1v1", "current");

            var allOpponentIdsMeetAsVanguard = statsCuratedDto?.All?.Vanguard?.outcomes_by_opponent;
            if (allOpponentIdsMeetAsVanguard is not null)
            {
                foreach (var opponent in allOpponentIdsMeetAsVanguard)
                {
                    if (opponentSet_Id_Name.ContainsKey(opponent.profile_id) is false)
                    {
                        opponentSet_Id_Name.Add(opponent.profile_id, opponent.player_name);
                    }

                }
            }
            var allOpponentIdsMeetAsInfernals = statsCuratedDto?.All?.Infernals?.outcomes_by_opponent;
            if (allOpponentIdsMeetAsInfernals is not null)
            {
                foreach (var opponent in allOpponentIdsMeetAsInfernals)
                {
                    if (opponentSet_Id_Name.ContainsKey(opponent.profile_id) is false)
                    {
                        opponentSet_Id_Name.Add(opponent.profile_id, opponent.player_name);
                    }

                }
            }

            var allOpponentIdsMeetAsCelestials = statsCuratedDto?.All?.Celestials?.outcomes_by_opponent;
            if (allOpponentIdsMeetAsCelestials is not null)
            {
                foreach (var opponent in allOpponentIdsMeetAsCelestials)
                {
                    if (opponentSet_Id_Name.ContainsKey(opponent.profile_id) is false)
                    {
                        opponentSet_Id_Name.Add(opponent.profile_id, opponent.player_name);
                    }

                }
            }




            return opponentSet_Id_Name;
        }





        private static Task<PlayerSnapshot> CreateLightSnapshotFromPlayerHistory(string playerId, string playerName)
        {
            var playerSnapshot = new PlayerSnapshot
            {
                InfoRichness = InfoRichness.Light_NameAndIdKnow,

                ProfileId = playerId,
                PlayerName = playerName,
                LastSnapshot = DateTime.UtcNow,

            };



            return Task.FromResult(playerSnapshot);
        }

        /// <summary>
        /// Determines whether performing a lookup search for the specified player is worthwhile based on the player's
        /// information richness.
        /// </summary>
        /// <param name="playerId">The unique identifier of the player whose information richness is being evaluated.</param>
        /// <returns><see langword="true"/> if a lookup search is considered worthwhile; otherwise, <see langword="false"/>.
        /// Returns <see langword="true"/> if no snapshot is found for the specified <paramref name="playerId"/>.</returns>
        private bool IsWorthDoingLookUpSearch(string playerId)
        {


            var infoRichness = _untappedDbContext.Set<PlayerSnapshot>()
                .Where(x => x.ProfileId == playerId)
                .Select(x => x.InfoRichness)
                .FirstOrDefault();


            return infoRichness switch
            {
                InfoRichness.Light_NameAndIdKnow => true,
                InfoRichness.Medium_Lookup => false,
                InfoRichness.Full_PublicHistory => false,
                _ => true, //Returns true if ProfileId does not return any snapshot
            };
        }



        private async Task<PlayerSnapshot?> CreateMediumSnapshotByPlayerLookUpDto(string profile_id)
        {
            var playerLookUpDto = await _untappedApiService.GetPlayerLookUpDto(profile_id);

            if (playerLookUpDto is null)
            { return null; }

            var playerSnapshot = new PlayerSnapshot
            {
                InfoRichness = InfoRichness.Medium_Lookup,

                ProfileId = playerLookUpDto.profileId,
                PlayerName = playerLookUpDto.playerName,
                LastSnapshot = DateTime.UtcNow,
                MatchHistoryVisibility = playerLookUpDto?.matchHistoryVisibility?.RANKED_1V1,
                ReplayVisibility = playerLookUpDto?.replayVisibility?.RANKED_1V1,

            };

            return playerSnapshot;

        }



    }

}

