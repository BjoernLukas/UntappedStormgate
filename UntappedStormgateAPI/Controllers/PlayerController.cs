using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UntappedAPI.DataUtility;
using UntappedAPI.Models;

namespace UntappedAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly TemplateDbContext _templateDbContext;

    public PlayerController(TemplateDbContext templateDbContext)
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
    public async Task<IActionResult> Search(string displayName = "ByteBender")
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
    public async Task<IActionResult> Lookup(string profileId)
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

    [HttpGet("PlayerStats")]
    public async Task<IActionResult> PlayerStats(string profileId, string matchMode = "ranked_1v1", string season = "current")
    {
        var url = $"https://api.stormgate.untapped.gg/api/v2/matches/players/{profileId}/stats/{matchMode}?season={season}";

        using HttpClient client = new();
        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode is false)
        {
            return NotFound($"Player with name {profileId} not found.");
        }

        //TODO: Why is this PlayerStats null? 
        var PlayerStats = await response.Content.ReadFromJsonAsync<PlayerStats>();


        return Ok(PlayerStats);
    }





}





