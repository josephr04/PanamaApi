using Microsoft.AspNetCore.Mvc;

namespace PanamaApi.Controllers
{
    [ApiController]
    [Route("api/v1/countryinfo")]
    public class InfoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var info = new
            {
                Name = "República de Panamá",
                Capital = "Ciudad de Panamá",
                Population = 4351267,
                Surface = 75417,
                Currency = new[]
                {
                "Balboa",
                "United States dollar"
            },
                CurrencyCode = new[]
                {
                "PAB",
                "USD"
            },
                Language = "Spanish",
                CallingCode = "+507",
                IsoCode = "PA",
                Iso3Code = "PAN",
                Region = "Americas",
                SubRegion = "Central America",
                Borders = new[]
                {
                "Costa Rica",
                "Colombia"
            },
                Government = "Presidential Republic",
                TimeZone = "UTC-5",
                Flags = new[]
                {
                "https://flagcdn.com/pa.svg",
                "https://flagcdn.com/w320/pa.png"
            }
            };

            return Ok(new { success = true, data = info });
        }
    }
}