using Zira.RazorPages.Data.Models;

namespace Zira.RazorPages.Services
{
    public interface IClientService
    {
        Task<List<Client>> GetClientsAsync(string searchTerm);
    }
}
