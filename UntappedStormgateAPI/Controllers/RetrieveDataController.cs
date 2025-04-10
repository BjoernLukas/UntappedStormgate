using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UntappedAPI.DataUtility;
using UntappedAPI.Models;

namespace UntappedAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RetrieveDataController : ControllerBase
{
    private readonly TemplateDbContext _templateDbContext;

    public RetrieveDataController(TemplateDbContext templateDbContext)
    {
        _templateDbContext = templateDbContext; 
    }

    
   


    
}





