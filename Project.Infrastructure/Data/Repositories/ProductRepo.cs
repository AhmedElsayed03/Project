using Microsoft.EntityFrameworkCore;
using Project.Application.Abstractions.Repositories;
using Project.Domain.Entities;
using Project.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Data.Repositories
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        private readonly MarketDbContext _dbContext;

        public ProductRepo(MarketDbContext context) : base(context)
        {
            _dbContext = context;
        }


        public async Task<IEnumerable<Product>> GetAll(int page, int countPerPage)
        {
            var products =await _dbContext.Products
                           //.Where(i => i.IsActive == true) //Uncomment to get Active Products Only
                           .OrderBy(i => i.Name)
                           .Skip((page - 1) * countPerPage)
                           .Take(countPerPage)
                           .ToListAsync();
            return products;
        }

        public async Task<int> GetCount()
        {
            var productsCount =await _dbContext.Products.CountAsync();
            return productsCount;
        }

     
    }
}
