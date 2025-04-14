using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UntappedAPI.DataUtility;
using UntappedAPI.Models.Untapped;
using UntappedAPI.Models.Untapped.PlayerStats;
using UntappedAPI.Service;

namespace UntappedAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UntappedApiController : ControllerBase
{
    private readonly PlayerInformationService _dataCollectorService;

    public UntappedApiController(PlayerInformationService dataCollectorService)
    {
        _dataCollectorService = dataCollectorService;
    }



    /// <summary>
    /// Get player information by display name, default is "ByteBender"
    /// https://stormgate.untapped.gg/en/docs/api
    /// </summary>
    /// <param name="displayName"></param>
    /// <returns></returns>
    [HttpGet("GetPlayerBasicInfoByDisplayName")]
    public async Task<IActionResult> GetPlayerBasicInfoByDisplayName(string displayName = "ByteBender")
    {
        var result = await _dataCollectorService.GetPlayerBasicInfoByDisplayName(displayName);

        return Ok(result);
    }


    /// <summary>
    /// For testing use "VF92gcD" for ByteBender
    /// </summary>
    /// <param name="profileId"></param>
    /// <returns></returns>
    [HttpGet("GetPlayerBasicInfoById")]
    public async Task<IActionResult> GetPlayerBasicInfoById(string profileId)
    {
      
        var result = await _dataCollectorService.GetPlayerBasicInfoById(profileId);

        return Ok(result);
    }

    /// <summary>
    /// Get player stats by profileId, default is "ranked_1v1" and "current" season
    /// </summary>
    /// <param name="profileId"></param>
    /// <param name="matchMode"></param>
    /// <param name="season"></param>
    /// <returns></returns>
    [HttpGet("PlayerStats")]
    public async Task<IActionResult> GetPlayerStats(string profileId, string matchMode = "ranked_1v1", string season = "current")
    {
        var url = $"https://api.stormgate.untapped.gg/api/v2/matches/players/{profileId}/stats/{matchMode}?season={season}";

        using HttpClient client = new();
        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode is false)
        {
            return NotFound($"Player with name {profileId} not found.");
        }       
        var playerStatsAllMetaPeriodsCurated = await response.Content.ReadFromJsonAsync<PlayerStatsAllMetaPeriodsCurated>();

        return Ok(playerStatsAllMetaPeriodsCurated);
    }
    [HttpGet("MetaPeriods")]
    public async Task<IActionResult> GetMetaPeriods()
    {
        var url = "https://api.stormgate.untapped.gg/api/v1/meta-periods";

        using HttpClient client = new();
        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode is false)
        {
            return NotFound("Failed to retrieve meta periods.");
        }

        var metaPeriodsRAW = await response.Content.ReadAsStringAsync();

        var metaPeriods = await response.Content.ReadFromJsonAsync<List<MetaPeriod>>();


        return Ok(metaPeriods);
    }
}





