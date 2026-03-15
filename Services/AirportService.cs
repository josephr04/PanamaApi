using Dapper;
using PanamaApi.Interfaces;
using PanamaApi.Models;
using System.Data;

namespace PanamaApi.Services
{
    public class AirportService : IAirportService
    {
        private readonly IDbConnection _conexion;

        public AirportService(IDbConnection conexion)
        {
            _conexion = conexion;
        }

        public async Task<IEnumerable<Airport>> GetAirports(string? category, string? province)
        {
            return await _conexion.QueryAsync<Airport>("SELECT * FROM get_airports(@Category, @Province)", new { Category = category, Province = province });
        }

        public async Task<Airport?> GetAirportById(int id)
        {
            return await _conexion.QueryFirstOrDefaultAsync<Airport>("SELECT * FROM get_airport_by_id(@Id)", new { Id = id });
        }
    }
}
