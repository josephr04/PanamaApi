using PanamaApi.Models;

namespace PanamaApi.Interfaces
{
    public interface IPresidentService
    {
        Task<IEnumerable<President>> GetPresidents(int? year = null);
        Task<President?> GetPresidentById(int id);
    }
}
