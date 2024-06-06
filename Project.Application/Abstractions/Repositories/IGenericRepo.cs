using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Abstractions.Repositories
{
    public interface IGenericRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetByID(int Id);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        int SaveChanges();
    }
}
