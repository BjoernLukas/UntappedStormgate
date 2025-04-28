using System.Diagnostics;
using UntappedAPI.DatabaseContext;
using UntappedAPI.DTOs.PlayerLookUpDto;
using UntappedAPI.Models;

namespace UntappedAPI.Service
{
    public class PlayerDiscoveryService
    {
        private readonly UntappedApiService _untappedApiService;
        private readonly UntappedDbContext _untappedDbContext;
        private Queue<string> _playerIdsQueue;
        private int _amountOfNewPlayersFound = 0;


        public PlayerDiscoveryService(UntappedApiService dataCollectorService, UntappedDbContext untappedDbContext)
        {
            _untappedApiService = dataCollectorService;
            _playerIdsQueue = new Queue<string>();
            _untappedDbContext = untappedDbContext;
        }

        public string SaveSnapshotOnlyOnePlayer(string profileId)
        {

            var playerSnapshot = CreateMediumSnapshotByPlayerLookUpDto(profileId).Result;

            _untappedDbContext.Set<PlayerSnapshot>().Update(playerSnapshot);
            _untappedDbContext.SaveChanges();


            return $"PlayersSnapshot saved {profileId}";
        }



        /// <summary>
        /// Start on Player (default ByteBender) work from there.
        /// </summary>
        /// <param name="profileId"></param>
        /// <returns></returns>
        public async Task<string> StartDiscoveryOnSpecificPlayerId(string profileId)
        {


            //STEP 1: Seed First Player   
            _playerIdsQueue.Enqueue(profileId);
            

            //STEP 2: work on que while also adding new players to the que
            while (_playerIdsQueue.Count != 0)
            {
                await WorkOnSnapshotQueue();
            }


            return $"StartDiscoveryOnSpecificPlayerId done";
        }


        public async Task WorkOnSnapshotQueue()
        {
            Trace.TraceInformation($"_playerIdsQueue = {_playerIdsQueue.Count}");

            string playerId = _playerIdsQueue.Dequeue();

            Trace.TraceInformation($"Starting on new player {playerId}");

            var isPlayerIdWorthLookingUp = IsWorthDoingLookUpSearch(playerId);

            if (isPlayerIdWorthLookingUp is false)
            {
                Trace.TraceInformation($"Player {playerId} not worth looking up ");
                return; //Do nothing  
            }

            //BIG TODO needs to hande updateing Light to medium.


            //**Medium Snapshot - All players at this point are ether Light unknow and worth saving to db
            var mediumPlayerSnapshot = await CreateMediumSnapshotByPlayerLookUpDto(playerId);
            _untappedDbContext.Add(mediumPlayerSnapshot);
           await _untappedDbContext.SaveChangesAsync();

            Trace.TraceInformation($"mediumPlayerSnapshot was saved: {mediumPlayerSnapshot.ProfileId},{mediumPlayerSnapshot.PlayerName} ");


            //**Light Snapshot

            var allOpponentSet_Id_Name = await GetOpponentIdsFromMatchHistory(playerId);

            Trace.TraceInformation($"{mediumPlayerSnapshot.PlayerName} has meet {allOpponentSet_Id_Name.Count} Opponents");

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

            Trace.TraceInformation($"{notYetKnownPlayerSnapshot.Count} new players found and there light Snapshot have been saved to Db");

            //Because the light snapshot is sill something we can collect a match history on we adds them to the que
            var idsToBeAddedToQue = notYetKnownPlayerSnapshot.Select(x => x.ProfileId).ToList();

            foreach (var id in idsToBeAddedToQue)
            { _playerIdsQueue.Enqueue(id); }

            return;
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

            var allOpponentIdsMeetAsVanguard = statsCuratedDto.All?.Vanguard?.outcomes_by_opponent;
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
            var allOpponentIdsMeetAsInfernals = statsCuratedDto.All?.Infernals?.outcomes_by_opponent;
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

            var allOpponentIdsMeetAsCelestials = statsCuratedDto.All?.Celestials?.outcomes_by_opponent;
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



        private async Task<PlayerSnapshot> CreateMediumSnapshotByPlayerLookUpDto(string profile_id)
        {
            var playerLookUpDto = await _untappedApiService.GetPlayerLookUpDto(profile_id);

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
