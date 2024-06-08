using Project.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Abstractions.Services
{
    public interface IClientProductService
    {
        Task AddClientProduct(ClientProductAddDto newclientProductAdd);
        Task UpdateClientProduct(clientProductUpdateDto clientProductUpdateDto);
        Task DeleteClientProduct(int productId, int clientId);
    }
}
