using Dapper;
using PanamaApi.Interfaces;
using PanamaApi.Models;
using System.Data;

namespace PanamaApi.Services
{
    public class PresidentService : IPresidentService
    {
        private readonly IDbConnection _conexion;

        public PresidentService(IDbConnection conexion)
        {
            _conexion = conexion;
        }

        public async Task<IEnumerable<President>> GetPresidents()
        {
            return await _conexion.QueryAsync<President>("SELECT * FROM get_presidents()");
        }

        public async Task<President?> GetPresidentById(int id)
        {
            return await _conexion.QueryFirstOrDefaultAsync<President>("SELECT * FROM get_president_by_id(@Id)", new { Id = id });
        }
    }
}
