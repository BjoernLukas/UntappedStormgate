using UntappedAPI.DatabaseContext;
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

            var playerSnapshot = CreateSnapshotByPlayerLookUpDto(profileId).Result;

            _untappedDbContext.Set<PlayerSnapshot>().Add(playerSnapshot);
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
            //TODO add prefilling of que from light snapshots

            //STEP 2: work on que while also adding new players to the que
            while (_playerIdsQueue.Count != 0)
            {
                await WorkOnQueue();
            }


            return $"Players found {_amountOfNewPlayersFound}";
        }



        #region Private Methods
        /// <summary>
        /// Work on the queue of player ids.
        /// </summary>
        /// <returns></returns>
        private async Task WorkOnQueue()
        {
            string playerId = _playerIdsQueue.Dequeue();

            var isPlayerIdWorthLookingUp = IsPlayerIdWorthLookingUp(playerId);

            if (isPlayerIdWorthLookingUp is false)
            {
                return; //Do nothing  
            }

            //*********Continue work from here!
            var PlayerInfoSnapshot = await CreateSnapshotByPlayerLookUpDto(playerId);





            return;
        }

        private bool IsPlayerIdWorthLookingUp(string playerId)
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
                _ => true,
            };
        }



        private async Task<PlayerSnapshot> CreateSnapshotByPlayerLookUpDto(string profile_id)
        {
            var playerBasicInfo = await _untappedApiService.GetPlayerLookUpDto(profile_id);
            var playerStatsAllMetaPeriodsCurated = await _untappedApiService.GetPlayerStats(profile_id, "ranked_1v1", "current");

            var playerInfoSnapshot = new PlayerSnapshot
            {
                InfoRichness = InfoRichness.Medium_Lookup,

                ProfileId = playerBasicInfo.profileId,
                PlayerName = playerBasicInfo.playerName,
                LastSnapshot = DateTime.UtcNow,
                MatchHistoryVisibility = playerBasicInfo.matchHistoryVisibility.RANKED_1V1,
                ReplayVisibility = playerBasicInfo.replayVisibility.RANKED_1V1,

            };

            return playerInfoSnapshot;
            
        }

        #endregion













    }
}
