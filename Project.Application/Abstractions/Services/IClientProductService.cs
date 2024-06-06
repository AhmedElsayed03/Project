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
        void AddClientProduct(ClientProductAddDto newclientProductAdd);
        void UpdateClientProduct(clientProductUpdateDto clientProductUpdateDto);
        void DeleteClientProduct(int productId, int clientId);
    }
}
