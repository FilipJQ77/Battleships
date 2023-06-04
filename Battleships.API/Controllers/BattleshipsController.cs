using Microsoft.AspNetCore.Mvc;

namespace Battleships.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BattleshipsController : ControllerBase
{
    private readonly ILogger<BattleshipsController> _logger;

    public BattleshipsController(ILogger<BattleshipsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public List<int> Get()
    {
        _logger.LogWarning("Test 123");
        return Enumerable.Range(1, 5).ToArray();
    }
}