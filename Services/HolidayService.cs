using Dapper;
using PanamaApi.Interfaces;
using PanamaApi.Models;
using System.Data;

namespace PanamaApi.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IDbConnection _conexion;

        public HolidayService(IDbConnection conexion)
        {
            _conexion = conexion;
        }

        public async Task<IEnumerable<Holiday>> GetHolidays(int? year, string? type)
        {
            return await _conexion.QueryAsync<Holiday>("SELECT * FROM get_holidays(@Year, @Type)", new { Year = year, Type = type });
        }

        public async Task<Holiday?> GetHolidayById(int id)
        {
            return await _conexion.QueryFirstOrDefaultAsync<Holiday>("SELECT * FROM get_holiday_by_id(@Id)", new { Id = id });
        }
    }
}
