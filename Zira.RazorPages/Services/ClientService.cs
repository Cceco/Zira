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
            var clients = _dbContext.Clients.Include(c => c.Details).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                clients = clients.Where(c => c.Name.ToLower().Contains(searchTerm.ToLower()) || c.Region.Contains(searchTerm));
            }

            return await clients.ToListAsync();
        }
    }
}
