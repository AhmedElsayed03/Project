using Project.Application.Abstractions.Repositories;
using Project.Application.Abstractions.UnitOfWork;
using Project.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IClientRepo ClientRepo { get; }
        public IProductRepo ProductRepo { get; }
        public IClientProductRepo ClientProductRepo { get; }


        private readonly MarketDbContext _context;
        
        public UnitOfWork(MarketDbContext context,
                          IClientRepo clientRepo,
                          IProductRepo productRepo,
                          IClientProductRepo clientProductRepo)
        {
            _context = context;
            ClientRepo= clientRepo;
            ProductRepo= productRepo;
            ClientProductRepo= clientProductRepo;
  
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
