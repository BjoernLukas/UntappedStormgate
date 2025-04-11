using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UntappedAPI.DataUtility;
using UntappedAPI.Models;
using UntappedAPI.Models.PlayerStats.AllMetaPeriods;

namespace UntappedAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StormgateController : ControllerBase
{
    private readonly TemplateDbContext _templateDbContext;

    public StormgateController(TemplateDbContext templateDbContext)
    {
        _templateDbContext = templateDbContext; //Todo
    }


    /// <summary>
    /// Get player information by display name, default is "ByteBender"
    /// https://stormgate.untapped.gg/en/docs/api
    /// </summary>
    /// <param name="displayName"></param>
    /// <returns></returns>
    [HttpGet("Search")]
    public async Task<IActionResult> GetPlayerSearch(string displayName = "ByteBender")
    {
        var url = $"https://api.stormgate.untapped.gg/api/v1/players?q={Uri.EscapeDataString(displayName)}";

        using HttpClient client = new();
        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode is false)
        {
            return NotFound($"Player with name {displayName} not found.");
        }
        var PlayerInfoResponse = await response.Content.ReadFromJsonAsync<List<PlayerBasicInfo>>();

        var playerInfo = PlayerInfoResponse?.Single();

        return Ok(playerInfo);
    }


    /// <summary>
    /// For testing use "VF92gcD" for ByteBender
    /// </summary>
    /// <param name="profileId"></param>
    /// <returns></returns>
    [HttpGet("Lookup")]
    public async Task<IActionResult> GetPlayerLookup(string profileId)
    {
        var url = $"https://api.stormgate.untapped.gg/api/v1/players/{profileId}";

        using HttpClient client = new();
        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode is false)
        {
            return NotFound($"Player with name {profileId} not found.");
        }

        var PlayerLookupResponse = await response.Content.ReadFromJsonAsync<PlayerBasicInfo>();


        return Ok();
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

        var playerStatsRAW = await response.Content.ReadAsStringAsync();

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





