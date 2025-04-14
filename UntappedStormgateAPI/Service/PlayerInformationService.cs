using Microsoft.AspNetCore.Mvc;
using UntappedAPI.Models.Untapped;
using UntappedAPI.Models.Untapped.PlayerStats;

namespace UntappedAPI.Service
{
    public class PlayerInformationService
    {
        public async Task<PlayerBasicInfo> GetPlayerBasicInfoByDisplayName(string displayName)
        {
            var url = $"https://api.stormgate.untapped.gg/api/v1/players?q={Uri.EscapeDataString(displayName)}";

            using HttpClient client = new();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode is false)
            {
                throw new($"Player with name {displayName} not found.");
            }
            var PlayerInfoResponse = await response.Content.ReadFromJsonAsync<List<PlayerBasicInfo>>();

            var playerInfo = PlayerInfoResponse?.Single();


            return playerInfo ?? throw new();
        }

        public async Task<PlayerBasicInfo> GetPlayerBasicInfoById(string id)
        {
            var url = $"https://api.stormgate.untapped.gg/api/v1/players/{id}";

            using HttpClient client = new();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode is false)
            {
                throw new($"Player with id {id} not found.");
            }

            var result = await response.Content.ReadFromJsonAsync<PlayerBasicInfo>();

            return result ?? throw new();
        }




        public async Task<PlayerStatsAllMetaPeriodsCurated> GetPlayerStats(string profileId, string matchMode, string season)
        {
            var url = $"https://api.stormgate.untapped.gg/api/v2/matches/players/{profileId}/stats/{matchMode}?season={season}";

            using HttpClient client = new();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode is false)
            {
                throw new($"Player: {profileId} not found.");
            }

            var playerStatsAllMetaPeriodsCurated = await response.Content.ReadFromJsonAsync<PlayerStatsAllMetaPeriodsCurated>();

            return playerStatsAllMetaPeriodsCurated ?? throw new($"Player: {profileId} id not have any playerStats");
        }




    }

}
