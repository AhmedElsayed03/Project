using Project.Application.Models.DTOs;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Abstractions.Repositories
{
    public interface IClientRepo : IGenericRepo<Client>
    {
        IEnumerable<Client> GetAll(int page, int countPerPage);
        Client? GetClientWithProducts(int id);

    }
}
