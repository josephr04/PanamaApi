using PanamaApi.Models;

namespace PanamaApi.Interfaces
{
    public interface IPresidentService
    {
        Task<IEnumerable<President>> GetPresidents();
        Task<President?> GetPresidentById(int id);
    }
}
