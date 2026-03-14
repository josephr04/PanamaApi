using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PanamaApi.Interface;

namespace PanamaApi.Controllers
{
    [ApiController]
    [Route("api/v1/holidays")]
    public class HolidaysController : ControllerBase
    {
        private readonly IHolidayService _holidayService;
        private readonly ILogger<HolidaysController> _logger;

        public HolidaysController(IHolidayService holidayService, ILogger<HolidaysController> logger)
        {
            _holidayService = holidayService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? year, [FromQuery] string? type)
        {
            try
            {
                var holidays = await _holidayService.GetHolidays(year, type);
                return Ok(new { success = true, data = holidays });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting holidays");
                return StatusCode(500, new { success = false, message = "Internal server error", code = 500 });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var holiday = await _holidayService.GetHolidayById(id);

                if (holiday == null)
                    return NotFound(new { success = false, message = "Holiday not found", code = 404 });

                return Ok(new { success = true, data = holiday });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting holiday {Id}", id);
                return StatusCode(500, new { success = false, message = "Internal server error", code = 500 });
            }
        }
    }
}
