using Microsoft.AspNetCore.Mvc;
using PanamaApi.Interfaces;

namespace PanamaApi.Controllers
{
    [ApiController]
    [Route("api/v1/presidents")]
    public class PresidentsController : ControllerBase
    {
        private readonly IPresidentService _presidentService;
        private readonly ILogger<PresidentsController> _logger;

        public PresidentsController(IPresidentService presidentService, ILogger<PresidentsController> logger)
        {
            _presidentService = presidentService;
            _logger = logger;
        }

        // GET api/v1/presidents
        // GET api/v1/presidents?year=1999
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? year)
        {
            try
            {
                var presidents = await _presidentService.GetPresidents(year);
                return Ok(new { success = true, data = presidents });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting presidents");
                return StatusCode(500, new { success = false, message = "Internal server error", code = 500 });
            }
        }

        // GET api/v1/presidents/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var president = await _presidentService.GetPresidentById(id);

                if (president == null)
                {
                    return NotFound(new { success = false, message = "President not found", code = 404 });
                }

                return Ok(new { success = true, data = president });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting president {Id}", id);
                return StatusCode(500, new { success = false, message = "Internal server error", code = 500 });
            }
        }
    }
}