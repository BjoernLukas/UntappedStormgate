using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UntappedAPI.DataUtility;
using UntappedAPI.Models;

namespace UntappedAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerInfoController : ControllerBase
{
    private readonly TemplateDbContext _templateDbContext;

    public PlayerInfoController(TemplateDbContext templateDbContext)
    {
        _templateDbContext = templateDbContext;
    }

    [HttpGet()]
    public async Task<IActionResult> GetPersonByNameAsync(string displayName = "ByteBender")
    {
        var url = $"https://api.stormgate.untapped.gg/api/v1/players?q={Uri.EscapeDataString(displayName)}";

        using HttpClient client = new();
        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode is false)
        {
            return NotFound($"Player with name {displayName} not found.");
        }        
        var PlayerInfoResponse = await response.Content.ReadFromJsonAsync<List<PlayerInfo>>(); //Need to know what type to use here        
    
        var playerInfo = PlayerInfoResponse?.Single();

       

        return Ok(playerInfo);
    }

    //private static async Task<string> DeserializePlayerData(HttpResponseMessage response, string output)
    //{
    //    if (response.IsSuccessStatusCode)
    //    {
    //        string json = await response.Content.ReadAsStringAsync();



    //        var players = JsonSerializer.Deserialize<List<Player>>(json, new JsonSerializerOptions
    //        {
    //            PropertyNameCaseInsensitive = true
    //        });

    //        List<string> playerSummaries = new();

    //        foreach (var player in players)
    //        {
    //            var summary = $"Name: {player.PlayerName}, ID: {player.ProfileId}";

    //            if (player.Ranks?.Ranked1v1?.Infernals != null)
    //            {
    //                var stats = player.Ranks.Ranked1v1.Infernals;
    //                summary += $" | MMR: {stats.Mmr}, League: {stats.League}, Wins: {stats.Wins}, Losses: {stats.Losses}";
    //            }

    //            playerSummaries.Add(summary);
    //        }

    //        output = string.Join("\n", playerSummaries);
    //    }
    //    else
    //    {
    //        output = $"Error: {response.StatusCode}";
    //    }

    //    // You now have the result in the 'output' variable.
    //    // You can return it, log it, send it, etc.
    //    return output;
    //}
}





