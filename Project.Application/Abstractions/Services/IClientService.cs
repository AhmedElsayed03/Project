using Project.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Abstractions.Services
{
    public interface IClientService
    {
        IEnumerable<ClientReadDto> GetAll(int page, int countPerPage);
        IEnumerable<ClientReadDto> GetAllClients();
        ClientDetailsReadDto GetClientDetails(int Id);
        void AddClient(ClientAddDto newclient);
        ClientWithProductsDto GetClientWithProducts(int Id);
        int GetClientCount();
        void UpdateClient(ClientUpdateDto clientUpdateDto);
        void DeleteClient(int id);

    }
}
