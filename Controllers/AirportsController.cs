using Microsoft.AspNetCore.Mvc;
using PanamaApi.Interfaces;

namespace PanamaApi.Controllers
{
    [ApiController]
    [Route("api/v1/airports")]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportService _airportService;
        private readonly ILogger<AirportsController> _logger;

        public AirportsController(IAirportService airportService, ILogger<AirportsController> logger)
        {
            _airportService = airportService;
            _logger = logger;
        }

        // GET api/v1/airports
        // GET api/v1/airports?category=Internacional
        // GET api/v1/airports?province=PANAMA
        // GET api/v1/airports?category=Internacional&province=PANAMA
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? category, [FromQuery] string? province)
        {
            try
            {
                var airports = await _airportService.GetAirports(category, province);
                return Ok(new { success = true, data = airports });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting airports");
                return StatusCode(500, new { success = false, message = "Internal server error", code = 500 });
            }
        }

        // GET api/v1/airports/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var airport = await _airportService.GetAirportById(id);

                if (airport == null)
                {
                    return NotFound(new { success = false, message = "Airport not found", code = 404 });
                }

                return Ok(new { success = true, data = airport });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting airport {Id}", id);
                return StatusCode(500, new { success = false, message = "Internal server error", code = 500 });
            }
        }
    }
}