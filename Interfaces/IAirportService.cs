using PanamaApi.Models;

namespace PanamaApi.Interfaces
{
    public interface IAirportService
    {
        Task<IEnumerable<Airport>> GetAirports(string? category, string? province);
        Task<Airport?> GetAirportById(int id);
    }
}
