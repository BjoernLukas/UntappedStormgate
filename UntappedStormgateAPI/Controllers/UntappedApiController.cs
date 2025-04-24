using Microsoft.AspNetCore.Mvc;
using UntappedAPI.DTOs;
using UntappedAPI.DTOs.PlayerStatsCuratedStatsDto;
using UntappedAPI.Service;

namespace UntappedAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UntappedApiController : ControllerBase
{
    private readonly UntappedApiService _untappedApiService;

    public UntappedApiController(UntappedApiService dataCollectorService)
    {
        _untappedApiService = dataCollectorService;
    }



    /// <summary>
    /// Get player information by display name, default is "ByteBender"
    /// https://stormgate.untapped.gg/en/docs/api
    /// </summary>
    /// <param name="displayName"></param>
    /// <returns></returns>
    [Obsolete]
    [HttpGet("GetPlayerBasicInfoByDisplayName")]    
    public async Task<IActionResult> GetPlayerBasicInfoByDisplayName(string displayName = "ByteBender")
    {
        var result = await _untappedApiService.GetPlayerBasicInfoByDisplayName(displayName);

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
      
        var result = await _untappedApiService.GetPlayerBasicInfoById(profileId);

        return Ok(result);
    }

    /// <summary>
    /// Get player stats by profileId, default is "ranked_1v1" and "current" season
    /// Default profileId: ByteBender's id VF92gcD
    /// Default matchMode: ranked_1v1
    /// Try season: 13 (0.4)
    /// </summary>
    /// <param name="profileId"></param>
    /// <param name="matchMode"></param>
    /// <param name="season"></param>
    /// <returns></returns>
    [HttpGet("PlayerStats")]
    public async Task<IActionResult> GetPlayerStats(string profileId = "VF92gcD", string matchMode = "ranked_1v1", string season = "current")
    {
        var url = $"https://api.stormgate.untapped.gg/api/v2/matches/players/{profileId}/stats/{matchMode}?season={season}";

        using HttpClient client = new();
        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode is false)
        {
            return NotFound($"Player with name {profileId} not found.");
        }


        var raw = await response.Content.ReadAsStringAsync();

        var PlayerStatsCuratedStatsDto = await response.Content.ReadFromJsonAsync<PlayerStatsCuratedStatsDto>();

        return Ok(PlayerStatsCuratedStatsDto);
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

        var metaPeriods = await response.Content.ReadFromJsonAsync<List<MetaPeriodDto>>();


        return Ok(metaPeriods);
    }
}





