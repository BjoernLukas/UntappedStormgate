using Microsoft.AspNetCore.Mvc;
using UntappedAPI.DTOs;
using UntappedAPI.DTOs.PlayerLookUpDto;
using UntappedAPI.DTOs.PlayerStatsCuratedStatsDto;


namespace UntappedAPI.Service
{
    public class UntappedApiService
    {
        public async Task<PlayerLookUpDto> GetPlayerBasicInfoByDisplayName(string displayName)
        {
            var url = $"https://api.stormgate.untapped.gg/api/v1/players?q={Uri.EscapeDataString(displayName)}";

            using HttpClient client = new();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode is false)
            {
                throw new($"Player with name {displayName} not found.");
            }
            var PlayerInfoResponse = await response.Content.ReadFromJsonAsync<List<PlayerLookUpDto>>();

            var playerInfo = PlayerInfoResponse?.Single();


            return playerInfo ?? throw new();
        }

        public async Task<PlayerLookUpDto?> GetPlayerLookUpDto(string id)
        {
            try
            {
                var url = $"https://api.stormgate.untapped.gg/api/v1/players/{id}";

                using HttpClient client = new();
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode is false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Player with id {id} not found");
                    Console.ForegroundColor = ConsoleColor.Black;

                    return null;
                }



                var result = await response.Content.ReadFromJsonAsync<PlayerLookUpDto>();

                return result;
            }
            catch
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong with GetPlayerLookUpDto");
                Console.ForegroundColor = ConsoleColor.Black;

                return null;

            }


        }




        public async Task<PlayerStatsCuratedStatsDto?> GetPlayerStats(string profileId, string matchMode, string season)
        {
            try
            {
                var url = $"https://api.stormgate.untapped.gg/api/v2/matches/players/{profileId}/stats/{matchMode}?season={season}";

                using HttpClient client = new();
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode is false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Player with id {profileId} not found");
                    Console.ForegroundColor = ConsoleColor.Black;

                    return null;
                }

                var playerStatsAllMetaPeriodsCurated = await response.Content.ReadFromJsonAsync<PlayerStatsCuratedStatsDto>();

                return playerStatsAllMetaPeriodsCurated;
            }
            catch (Exception)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong with GetPlayerStats");
                Console.ForegroundColor = ConsoleColor.Black;

                return null;

            }
        }




    }

}
