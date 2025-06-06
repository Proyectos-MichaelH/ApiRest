using ApiRest.Models;

namespace ApiRest.Services
{
    public interface IHistoryService
    {
        Task<IEnumerable<SearchHistory>> GetAllHistoryAsync();
        Task SaveSearchAsync(SearchHistory history);
    }
}