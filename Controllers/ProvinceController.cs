using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PanamaApi.Interface;

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

        [HttpGet("provinceId")]
        public async Task<IActionResult> GetProvinceById(int provinceId)
        {
            try
            {
                var province = await _locationService.GetProvinceById(provinceId);
                if (province == null)
                {
                    return NotFound(new { success = false, message = "Province not found", code = 404 });
                }
                return Ok(new { success = true, data = province });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving province with ID {provinceId}");
                return StatusCode(500, new { success = false, message = "Internal server error", code = 500 });
            }
        }

        [HttpGet("{provinceId}/districts")]
        public async Task<IActionResult> GetProvinceDistricts(int provinceId)
        {
            try
            {
                var districts = await _locationService.GetProvinceDistricts(provinceId);
                return Ok(new { success = true, data = districts });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving districts for province with ID {provinceId}");
                return StatusCode(500, new { success = false, message = "Internal server error", code = 500 });
            }
        }
    }
}
