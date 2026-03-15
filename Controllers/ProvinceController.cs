using Microsoft.AspNetCore.Mvc;
using PanamaApi.Interfaces;

namespace PanamaApi.Controllers
{
    [ApiController]
    [Route("api/v1/provinces")]
    public class ProvinceController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly ILogger<ProvinceController> _logger;

        public ProvinceController(ILocationService locationService, ILogger<ProvinceController> logger)
        {
            _locationService = locationService;
            _logger = logger;
        }

        // GET api/v1/provinces
        [HttpGet]
        public async Task<IActionResult> GetProvinces()
        {
            try
            {
                var provinces = await _locationService.GetProvinces();
                return Ok(new { success = true, data = provinces });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving provinces");
                return StatusCode(500, new { success = false, message = "Internal server error", code = 500 });
            }
        }

        // GET api/v1/provinces/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProvinceById(int id)
        {
            try
            {
                var province = await _locationService.GetProvinceById(id);
                if (province == null)
                {
                    return NotFound(new { success = false, message = "Province not found", code = 404 });
                }
                return Ok(new { success = true, data = province });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving province with ID {id}");
                return StatusCode(500, new { success = false, message = "Internal server error", code = 500 });
            }
        }

        // GET api/v1/provinceId/districts
        [HttpGet("{id}/districts")]
        public async Task<IActionResult> GetProvinceDistricts(int id)
        {
            try
            {
                var districts = await _locationService.GetProvinceDistricts(id);
                return Ok(new { success = true, data = districts });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving districts for province with ID {id}");
                return StatusCode(500, new { success = false, message = "Internal server error", code = 500 });
            }
        }
    }
}
