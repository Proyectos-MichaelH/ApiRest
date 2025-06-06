using ApiRest.Context;
using ApiRest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly AppDbContext _context;

        public HistoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SearchHistory>> GetAllHistoryAsync()
        {
            return await _context.SearchHistories
                                 .OrderByDescending(h => h.Timestamp)
                                 .ToListAsync();
        }

        public async Task SaveSearchAsync(SearchHistory history)
        {
            _context.SearchHistories.Add(history);
            await _context.SaveChangesAsync();
        }
    }
}