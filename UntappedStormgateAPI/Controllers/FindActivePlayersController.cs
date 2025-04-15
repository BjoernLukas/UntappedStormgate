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
    private readonly PlayerDiscoveryService _playerDiscoveryService;

    public FindActivePlayersController(PlayerDiscoveryService playerDiscoveryService)
    {
        _playerDiscoveryService = playerDiscoveryService;
    }


    /// <summary>
    /// Start on Player ByteBender work from there.
    /// </summary>
    /// <returns></returns>
    [HttpGet("StartOnByteBender")]
    public async Task<IActionResult> StartOnByteBender()
    {
        var result = await _playerDiscoveryService.StartDiscoveryOnSpecificPlayer("VF92gcD"); // ByteBender

        return Ok(result);
    }

    /// <summary>
    /// Test the DbContext with a player.
    /// </summary>
    /// <returns></returns>
    [HttpGet("TestDbContextWithPlayer")]
    public async Task<IActionResult> TestDbContextWithPlayer()
    {
        // Call the method to test the DbContext with a player
        var result = await _playerDiscoveryService.TestDbContextWithPlayer();

        return Ok(result);
    }
}





