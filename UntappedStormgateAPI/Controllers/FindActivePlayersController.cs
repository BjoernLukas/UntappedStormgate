using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UntappedAPI.DataUtility;
using UntappedAPI.Models;
using UntappedAPI.Models.Untapped;
using UntappedAPI.Service;

namespace UntappedAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FindActivePlayersController : ControllerBase
{
    private readonly TemplateDbContext _templateDbContext;
    private readonly PlayerInformationService _dataCollectorService;

    public FindActivePlayersController(TemplateDbContext templateDbContext, PlayerInformationService dataCollectorService)
    {
        _templateDbContext = templateDbContext;
        _dataCollectorService = dataCollectorService;
    }


    /// <summary>
    /// Start on Player ByteBender work from there.
    /// </summary>
    /// <returns></returns>
    [HttpGet("StartLookingForUniquePlayers")]
    public async Task<IActionResult> StartLookingForUniquePlayers()
    {
        var playerInfoSnapshots = new List<PlayerInfoSnapshot>();

        var firstPlayerInfoSnapshot = await CreatePlayerInfoSnapshot("VF92gcD"); // ByteBender
        playerInfoSnapshots.Add(firstPlayerInfoSnapshot);

        //WIP just Vanguard for now
        foreach (var outcomes_by_opponent in firstPlayerInfoSnapshot.PlayerStatsAllMetaPeriodsCurated.All.Vanguard.outcomes_by_opponent)
        {
           var playerSnapshot = await CreatePlayerInfoSnapshot(outcomes_by_opponent.profile_id);
            playerInfoSnapshots.Add(playerSnapshot);

        }

        return Ok($"{playerInfoSnapshots.Count} Unique Players found");
    }

    private async Task<PlayerInfoSnapshot> CreatePlayerInfoSnapshot(string profile_id)
    {
       var playerBasicInfo = await _dataCollectorService.GetPlayerBasicInfoById(profile_id);
       var playerStatsAllMetaPeriodsCurated = await _dataCollectorService.GetPlayerStats(profile_id, "ranked_1v1", "current");

        var playerInfoSnapshot = new PlayerInfoSnapshot
        {
            LastSnapshot = DateTime.UtcNow,
            PlayerBasicInfo = playerBasicInfo,
            PlayerStatsAllMetaPeriodsCurated = playerStatsAllMetaPeriodsCurated
        };

        return playerInfoSnapshot;
    }
}





