#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zira.RazorPages.Data.Models;
using Zira.RazorPages.Services;

namespace Zira.RazorPages.Pages
{
    public class ClientListModel : PageModel
    {
        private readonly IClientService _clientService;

        public ClientListModel(IClientService clientService)
        {
            _clientService = clientService;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Client = await _clientService.GetClientsAsync(SearchTerm);
        }
    }
}
