using PanamaApi.Models;

namespace PanamaApi.Interfaces
{
    public interface ILocationService
    {
        // Province-related methods
        Task<IEnumerable<Province>> GetProvinces();
        Task<Province?>GetProvinceById(int provinceId);
        Task<IEnumerable<District>> GetProvinceDistricts(int provinceId);

        // District-related methods
        Task<IEnumerable<District>> GetDistricts();
        Task<District?> GetDistrictById(int districtId);
        Task<IEnumerable<Corregimiento>> GetDistrictCorregimientos(int districtId);

        // Corregimiento-related methods
        Task<Corregimiento?> GetCorregimientoById(int corregimientoId);
    }
}
