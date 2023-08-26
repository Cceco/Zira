using Microsoft.EntityFrameworkCore;
using Zira.RazorPages.Data;
using Zira.RazorPages.Data.Models;

namespace Zira.RazorPages.Services
{
    public class ClientService : IClientService
    {
        private ApplicationDbContext _dbContext;

        public ClientService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Client>> GetClientsAsync(string searchTerm)
        {
            var query = _dbContext.Clients.Include(c => c.Details.FactSheets).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(c => c.Name.ToLower().Contains(searchTerm.ToLower()) || c.Region.Contains(searchTerm));
            }

            return await query.ToListAsync();
        }
    }
}
