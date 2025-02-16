using WorldAttractionsExplorer.DataAccess.Models;

namespace WorldAttractionsExplorer.Services.Contracts
{
    public interface IAttractionService
    {
        Task<IEnumerable<Attractions>> GetAllAsync();

        Task<Attractions?> GetByIdAsync(int id);

        Task<Attractions> CreateAsync(Attractions attraction);

        Task<bool> UpdateAsync(int id, Attractions attraction);

        Task<bool> DeleteAsync(int id);
    }
}
