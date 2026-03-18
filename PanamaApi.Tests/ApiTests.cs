using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace PanamaApi.Tests
{
    public class ApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        // PROVINCES
        [Fact]
        public async Task GetProvinces_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/v1/provinces");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetProvince_WithValidId_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/v1/provinces/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetProvince_WithInvalidId_ReturnsNotFound()
        {
            var response = await _client.GetAsync("/api/v1/provinces/9999");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetProvinceDistricts_WithValidId_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/v1/provinces/1/districts");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetProvinceDistricts_WithInvalidId_ReturnsNotFound()
        {
            var response = await _client.GetAsync("/api/v1/provinces/9999/districts");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        // DISTRICTS
        [Fact]
        public async Task GetDistricts_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/v1/districts");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetDistrict_WithValidId_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/v1/districts/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetDistrict_WithInvalidId_ReturnsNotFound()
        {
            var response = await _client.GetAsync("/api/v1/districts/9999");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetDistrictCorregimientos_WithValidId_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/v1/districts/1/corregimientos");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetDistrictCorregimientos_WithInvalidId_ReturnsNotFound()
        {
            var response = await _client.GetAsync("/api/v1/districts/9999/corregimientos");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        // CORREGIMIENTOS
        [Fact]
        public async Task GetCorregimiento_WithValidId_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/v1/corregimientos/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetCorregimiento_WithInvalidId_ReturnsNotFound()
        {
            var response = await _client.GetAsync("/api/v1/corregimientos/9999");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        // HOLIDAYS
        [Fact]
        public async Task GetHolidays_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/v1/holidays");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetHolidays_WithValidYear_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/v1/holidays?year=2026");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetHolidays_WithInvalidYear_ReturnsNotFound()
        {
            var response = await _client.GetAsync("/api/v1/holidays?year=2077");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetHoliday_WithValidId_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/v1/holidays/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetHoliday_WithInvalidId_ReturnsNotFound()
        {
            var response = await _client.GetAsync("/api/v1/holidays/9999");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        // AIRPORTS
        [Fact]
        public async Task GetAirports_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/v1/airports");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAirports_WithValidProvince_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/v1/airports?province=PANAMA");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAirports_WithInvalidProvince_ReturnsNotFound()
        {
            var response = await _client.GetAsync("/api/v1/airports?province=Antioquia");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAirport_WithValidId_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/v1/airports/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAirport_WithInvalidId_ReturnsNotFound()
        {
            var response = await _client.GetAsync("/api/v1/airports/9999");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        // PRESIDENTS
        [Fact]
        public async Task GetPresidents_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/v1/presidents");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetPresidents_WithValidYear_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/v1/presidents?year=1999");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetPresident_WithValidId_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/v1/presidents/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetPresident_WithInvalidId_ReturnsNotFound()
        {
            var response = await _client.GetAsync("/api/v1/presidents/9999");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        // COUNTRY INFO
        [Fact]
        public async Task GetCountryInfo_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/v1/countryinfo");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
