using UntappedAPI.Models;
using UntappedAPI.Models.Untapped.PlayerStats;

namespace UntappedAPI.Service
{
    public class PlayerDiscoveryService
    {

        private readonly UntappedApiService _dataCollectorService;
        private Queue<string> _playerIdsQueue;
        private List<PlayerInfoSnapshot> _playerInfoSnapshots;

        public PlayerDiscoveryService(UntappedApiService dataCollectorService)
        {
            _dataCollectorService = dataCollectorService;
            _playerIdsQueue = new Queue<string>();
            _playerInfoSnapshots = new List<PlayerInfoSnapshot>();
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
            AddIdsToQueFromRecentMatch(PlayerInfoSnapshot);
            //TODO: Add to DB

        }

        private async Task<PlayerInfoSnapshot> CreatePlayerInfoSnapshot(string profile_id)
        {
            var playerBasicInfo = await _dataCollectorService.GetPlayerBasicInfoById(profile_id);
            var playerStatsAllMetaPeriodsCurated = await _dataCollectorService.GetPlayerStats(profile_id, "ranked_1v1", "current");

            var playerInfoSnapshot = new PlayerInfoSnapshot
            {
                PlayerName = playerBasicInfo.PlayerName,
                ProfileId = playerBasicInfo.ProfileId,
                LastSnapshot = DateTime.UtcNow,
                PlayerBasicInfo = playerBasicInfo,
                CuratedPlayerStats = playerStatsAllMetaPeriodsCurated
            };

            return playerInfoSnapshot;
        }


        private void AddIdsToQueFromRecentMatch(PlayerInfoSnapshot playerInfoSnapshots)
        {

            if (playerInfoSnapshots.CuratedPlayerStats == null)
            {
                return;
            }


            if (playerInfoSnapshots.CuratedPlayerStats.All.Vanguard is not null)
            {
                //Vanguard
                foreach (var recentMatch in playerInfoSnapshots.CuratedPlayerStats.All.Vanguard.outcomes_by_opponent)
                { OnlyAddToQueueIfUnique(recentMatch.profile_id); }
            }

            if (playerInfoSnapshots.CuratedPlayerStats.All.Infernals is not null)
            {
                //Infernals
                foreach (var recentMatch in playerInfoSnapshots.CuratedPlayerStats.All.Infernals.outcomes_by_opponent)
                { OnlyAddToQueueIfUnique(recentMatch.profile_id); }
            }

            if (playerInfoSnapshots.CuratedPlayerStats.All.Celestials is not null)
            {
                //Celestials
                foreach (var recentMatch in playerInfoSnapshots.CuratedPlayerStats.All.Celestials.outcomes_by_opponent)
                { OnlyAddToQueueIfUnique(recentMatch.profile_id); }

            }






        }

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
