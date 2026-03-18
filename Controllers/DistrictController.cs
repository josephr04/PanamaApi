using Microsoft.AspNetCore.Mvc;
using PanamaApi.Interfaces;

namespace PanamaApi.Controllers
{
    [ApiController]
    [Route("api/v1/districts")]
    public class DistrictsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly ILogger<DistrictsController> _logger;

        public DistrictsController(ILocationService locationService, ILogger<DistrictsController> logger)
        {
            _locationService = locationService;
            _logger = logger;
        }

        // GET api/v1/districts
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var districts = await _locationService.GetDistricts();
                return Ok(new { success = true, data = districts });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting districts");
                return StatusCode(500, new { success = false, message = "Internal server error", code = 500 });
            }
        }

        // GET api/v1/districts/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var district = await _locationService.GetDistrictById(id);

                if (district == null)
                {
                    return NotFound(new { success = false, message = "District not found", code = 404 });
                }

                return Ok(new { success = true, data = district });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting district {Id}", id);
                return StatusCode(500, new { success = false, message = "Internal server error", code = 500 });
            }
        }

        // GET api/v1/districtId/corregimientos
        [HttpGet("{id}/corregimientos")]
        public async Task<IActionResult> GetCorregimientos(int id)
        {
            try
            {
                var district = await _locationService.GetDistrictById(id);

                if (district == null)
                {
                    return NotFound(new { success = false, message = "District not found", code = 404 });
                }

                var corregimientos = await _locationService.GetDistrictCorregimientos(id);
                return Ok(new { success = true, data = corregimientos });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting corregimientos for district {Id}", id);
                return StatusCode(500, new { success = false, message = "Internal server error", code = 500 });
            }
        }
    }
}