using Project.Application.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IClientRepo ClientRepo { get; }
        public IProductRepo ProductRepo { get; }
        public IClientProductRepo ClientProductRepo { get; }
        Task<int> SaveChangesAsync();
    }
}
