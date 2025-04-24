using UntappedAPI.DatabaseContext;
using UntappedAPI.Models;

namespace UntappedAPI.Service
{
    public class PlayerDiscoveryService
    {

        private readonly UntappedApiService _untappedApiService;
        private readonly UntappedDbContext _untappedDbContext;
        private Queue<string> _playerIdsQueue;
        private List<PlayerSnapshot> _playerInfoSnapshots;

        public PlayerDiscoveryService(UntappedApiService dataCollectorService, UntappedDbContext untappedDbContext)
        {
            _untappedApiService = dataCollectorService;
            _playerIdsQueue = new Queue<string>();
            _playerInfoSnapshots = new List<PlayerSnapshot>();
            _untappedDbContext = untappedDbContext;
        }

        public string TestDbContextWithPlayer(string profileId = "VF92gcD") // ByteBender
        {
                      

            var playerSnapshot = CreatePlayerInfoSnapshot(profileId).Result;

            _untappedDbContext.Set<PlayerSnapshot>().Add(playerSnapshot);

            _untappedDbContext.SaveChanges();


            return $"PlayersSnapshot saved {profileId}";
        }





        /// <summary>
        /// Start on Player (default ByteBender) work from there.
        /// </summary>
        /// <param name="profileId"></param>
        /// <returns></returns>
        public async Task<string> StartDiscoveryOnSpecificPlayer(string profileId = "VF92gcD") // ByteBender
        {
            //STEP 1: Seed First Player   
            _playerIdsQueue.Enqueue(profileId);

            //STEP 2: work on que while also adding new players to the que
            while (_playerIdsQueue.Count != 0)
            {
                await WorkOnQueue();
            }


            return $"Players found {_playerInfoSnapshots.Count}";
        }



        #region Private Methods
        /// <summary>
        /// Work on the queue of player ids.
        /// </summary>
        /// <returns></returns>
        private async Task WorkOnQueue()
        {
            string playerId = _playerIdsQueue.Dequeue();

            var PlayerInfoSnapshot = await CreatePlayerInfoSnapshot(playerId);
            _playerInfoSnapshots.Add(PlayerInfoSnapshot);
            //AddIdsToQueFromRecentMatch(PlayerInfoSnapshot);
            //TODO: Add to DB

        }

        private async Task<PlayerSnapshot> CreatePlayerInfoSnapshot(string profile_id)
        {
            var playerBasicInfo = await _untappedApiService.GetPlayerBasicInfoById(profile_id);
            var playerStatsAllMetaPeriodsCurated = await _untappedApiService.GetPlayerStats(profile_id, "ranked_1v1", "current");

            //var playerInfoSnapshot = new PlayerSnapshot
            //{
            //    PlayerName = playerBasicInfo.PlayerName,
            //    PlayerSnapshotId = playerBasicInfo.ProfileId,
            //    LastSnapshot = DateTime.UtcNow,
            //    Profile = playerBasicInfo,
            //    CuratedStats = playerStatsAllMetaPeriodsCurated
            //};

            //return playerInfoSnapshot;

            throw new NotImplementedException("PlayerSnapshot creation is not implemented yet.");
        }


        //private void AddIdsToQueFromRecentMatch(PlayerSnapshot playerInfoSnapshots)
        //{

        //    if (playerInfoSnapshots.CuratedStats == null)
        //    {
        //        return;
        //    }


        //    if (playerInfoSnapshots.CuratedStats.All.Vanguard is not null)
        //    {
        //        //Vanguard
        //        foreach (var recentMatch in playerInfoSnapshots.CuratedStats.All.Vanguard.outcomes_by_opponent)
        //        { OnlyAddToQueueIfUnique(recentMatch.profile_id); }
        //    }

        //    if (playerInfoSnapshots.CuratedStats.All.Infernals is not null)
        //    {
        //        //Infernals
        //        foreach (var recentMatch in playerInfoSnapshots.CuratedStats.All.Infernals.outcomes_by_opponent)
        //        { OnlyAddToQueueIfUnique(recentMatch.profile_id); }
        //    }

        //    if (playerInfoSnapshots.CuratedStats.All.Celestials is not null)
        //    {
        //        //Celestials
        //        foreach (var recentMatch in playerInfoSnapshots.CuratedStats.All.Celestials.outcomes_by_opponent)
        //        { OnlyAddToQueueIfUnique(recentMatch.profile_id); }

        //    }






        //}

        /// <summary>
        /// Check if the player id is already in the queue. If not, add it to the queue.
        /// </summary>
        /// <param name="profile_id"></param>
        /// <returns> returns true if id was added to que</returns>
        private bool OnlyAddToQueueIfUnique(string profile_id)
        {
            if (_playerIdsQueue.Contains(profile_id))
            {
                return false;
            }

            _playerIdsQueue.Enqueue(profile_id);
            return true;
        }
        #endregion













    }
}
