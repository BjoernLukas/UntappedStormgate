using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using UntappedAPI.DatabaseContext;
using UntappedAPI.Models;
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
    [HttpGet("StartQueueOnSpecificPlayer")]
    public async Task<IActionResult> StartDiscoveryOnSpecificPlayerId(string playerId = "VF92gcD") // ByteBender
    {
        var result = await _playerDiscoveryService.StartQueueOnSpecificPlayer(playerId); 

        return Ok(result);
    }

    /// <summary>
    /// Test the DbContext with a player.
    /// </summary>
    /// <returns></returns>
    [Obsolete]
    [HttpGet("SaveSnapshotOnlyOnePlayer")]
    public IActionResult SaveSnapshotOnlyOnePlayer()
    {
        // Call the method to test the DbContext with a player       

        //var playerSnapshot = CreateMediumSnapshotByPlayerLookUpDto(profileId).Result;

        //_untappedDbContext.Set<PlayerSnapshot>().Update(playerSnapshot);
        //_untappedDbContext.SaveChanges();


        return Ok();
    }


    [HttpGet("ConsoleTest")]
    public IActionResult LogConsoleTest()
    {

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"DarkGreen Test");
        Console.ForegroundColor = ConsoleColor.White;

                
        Console.WriteLine("Test msg no color.");


        


        return Ok();
    }

}





