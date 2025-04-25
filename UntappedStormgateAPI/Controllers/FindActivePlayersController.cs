using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UntappedAPI.Service;

namespace UntappedAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FindActivePlayersController : ControllerBase
{
    private readonly PlayerDiscoveryService _playerDiscoveryService;

    public FindActivePlayersController(PlayerDiscoveryService playerDiscoveryService)
    {
        _playerDiscoveryService = playerDiscoveryService;
    }


    /// <summary>
    /// Start on Player ByteBender work from there.
    /// </summary>
    /// <returns></returns>
    [HttpGet("NOTDONEStartWorkingOnQue")]
    public async Task<IActionResult> NOTDONEStartWorkingOnQue()
    {
        var result = await _playerDiscoveryService.StartDiscoveryOnSpecificPlayerId("VF92gcD"); // ByteBender

        return Ok(result);
    }

    /// <summary>
    /// Test the DbContext with a player.
    /// </summary>
    /// <returns></returns>
    [HttpGet("SaveSnapshotOnlyOnePlayer")]
    public IActionResult SaveSnapshotOnlyOnePlayer()
    {
        // Call the method to test the DbContext with a player
        var result =  _playerDiscoveryService.SaveSnapshotOnlyOnePlayer("VF92gcD"); // ByteBender

        return Ok(result);
    }
}





