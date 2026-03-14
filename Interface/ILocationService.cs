using PanamaApi.Models;

namespace PanamaApi.Interface
{
    public interface ILocationService
    {
        // Province-related methods
        Task<IEnumerable<Province>> GetProvinces();
        Task<Province?>GetProvinceById(int provinceId);
        Task<IEnumerable<District>> GetProvinceDistricts(int provinceId);

        // District-related methods
        Task<IEnumerable<District>> GetDistricts();
        Task<District?> GetDistrictById(int id);
        Task<IEnumerable<Corregimiento>> GetDistrictCorregimientos(int districtId);

        // Corregimiento-related methods
        //Task<IEnumerable<Corregimiento>> GetCorregimientos();
        Task<Corregimiento?> GetCorregimientoById(int id);
    }
}
