﻿using Microsoft.EntityFrameworkCore;
using Zira.RazorPages.Data;
using Zira.RazorPages.Data.Models;

namespace Zira.RazorPages.Services
{
    public class ClientService : IClientService
    {
        private ApplicationDbContext _dbContext;

        public ClientService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<Client>> GetClientsAsync(string searchTerm)
        {
            var clients = _dbContext.Client.Include(c => c.Details).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                clients = clients.Where(c => c.Name.Contains(searchTerm) || c.Region.Contains(searchTerm));
            }

            return await clients.ToListAsync();
        }
    }
}
