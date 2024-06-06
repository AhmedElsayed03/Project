using Microsoft.EntityFrameworkCore;
using Project.Application.Abstractions.Repositories;
using Project.Application.Models.DTOs;
using Project.Domain.Entities;
using Project.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Data.Repositories
{
    public class ClientRepo : GenericRepo<Client>, IClientRepo
    {
        private readonly MarketDbContext _dbContext;

        public ClientRepo(MarketDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public IEnumerable<Client> GetAll(int page, int countPerPage)
        {
            var clients = _dbContext.Clients
                     //.Where(i => i.State == 0) //Uncomment to get Active Clients Only
                     .OrderBy(i => i.Code)
                     .Skip((page - 1) * countPerPage)
                     .Take(countPerPage)
                     .ToList();
            return clients;
        }

        public Client? GetClientWithProducts(int id)
        {
            var client = _dbContext.Clients
                    .Where(i => i.Id == id)
                    .Include(i => i.ClientProduct)
                        .ThenInclude(i => i.Product)
                        .Select(c => new Client
                        {
                            Id = c.Id,
                            Code = c.Code,
                            Name = c.Name,
                            Class = c.Class,
                            State = c.State,
                            ClientProduct = c.ClientProduct
                        .OrderBy(c => c.Product.Name)
                        .ToList()
                    })
                    .FirstOrDefault();
            return client;
        }
    }
}
