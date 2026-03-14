using Microsoft.AspNetCore.Mvc;
using PanamaApi.Interface;

[ApiController]
[Route("api/v1/corregimientos")]
public class CorregimientosController : ControllerBase
{
    private readonly ILocationService _locationService;
    private readonly ILogger<CorregimientosController> _logger;

    public CorregimientosController(ILocationService locationService, ILogger<CorregimientosController> logger)
    {
        _locationService = locationService;
        _logger = logger;
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAll()
    //{
    //    try
    //    {
    //        var corregimientos = await _locationService.GetCorregimientos();
    //        return Ok(new { success = true, data = corregimientos });
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "Error getting corregimientos");
    //        return StatusCode(500, new { success = false, message = "Internal server error", code = 500 });
    //    }
    //}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var corregimiento = await _locationService.GetCorregimientoById(id);

            if (corregimiento == null)
            {
                return NotFound(new { success = false, message = "Corregimiento not found", code = 404 });
            }

            return Ok(new { success = true, data = corregimiento });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting corregimiento {Id}", id);
            return StatusCode(500, new { success = false, message = "Internal server error", code = 500 });
        }
    }
}