using Dapper;
using PanamaApi.Interface;
using PanamaApi.Models;
using System.Data;

namespace PanamaApi.Services
{
    public class LocationService : ILocationService
    {

        private readonly IDbConnection _conexion;

        public LocationService(IDbConnection conexion)
        {
            _conexion = conexion;
        }

        // province-related methods

        public async Task<IEnumerable<Province>> GetProvinces()
        {
            return await _conexion.QueryAsync<Province>("SELECT * FROM get_provinces()");
        }

        public async Task<Province?> GetProvinceById(int provinceId)
        {
            return await _conexion.QueryFirstOrDefaultAsync<Province>("SELECT * FROM get_province_by_id(@Id)", new { Id = provinceId });
        }

        public async Task<IEnumerable<District>> GetProvinceDistricts(int provinceId)
        {
            return await _conexion.QueryAsync<District>("SELECT * FROM get_province_districts(@Id)", new { Id = provinceId });
        }

        // District-related methods

        public async Task<IEnumerable<District>> GetDistricts()
        {
            return await _conexion.QueryAsync<District>("SELECT * FROM get_districts()");
        }

        public async Task<District?> GetDistrictById(int districtId)
        {
            return await _conexion.QueryFirstOrDefaultAsync<District>("SELECT * FROM get_district_by_id(@Id)",new { Id = districtId });
        }

        public async Task<IEnumerable<Corregimiento>> GetDistrictCorregimientos(int districtId)
        {
            return await _conexion.QueryAsync<Corregimiento>("SELECT * FROM get_district_corregimientos(@Id)", new { Id = districtId });
        }

        // Corregimiento-related methods
        //public async Task<IEnumerable<Corregimiento>> GetCorregimientos()
        //{
        //    return await _conexion.QueryAsync<Corregimiento>("SELECT * FROM get_corregimientos()");
        //}

        public async Task<Corregimiento?> GetCorregimientoById(int id)
        {
            return await _conexion.QueryFirstOrDefaultAsync<Corregimiento>("SELECT * FROM get_corregimiento_by_id(@Id)", new { Id = id });
        }
    }
}
