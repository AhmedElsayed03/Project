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
        Task<IEnumerable<ClientReadDto>> GetAll(int page, int countPerPage);
        Task<IEnumerable<ClientReadDto>> GetAllClients();
        Task<ClientDetailsReadDto> GetClientDetails(int Id);
        Task AddClient(ClientAddDto newclient);
        Task<ClientWithProductsDto> GetClientWithProducts(int Id);
        Task<int> GetClientCount();
        Task UpdateClient(ClientUpdateDto clientUpdateDto);
        Task DeleteClient(int id);

    }
}
