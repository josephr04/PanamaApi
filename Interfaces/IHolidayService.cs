using PanamaApi.Models;

namespace PanamaApi.Interfaces
{
    public interface IHolidayService
    {
        Task<IEnumerable<Holiday>> GetHolidays(int? year, string? type);
        Task<Holiday?> GetHolidayById(int id);
    }
}
