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
        Task<ClientDetailsReadDto> GetClientDetails(int Id);
        void AddClient(ClientAddDto newclient);
        Task<ClientWithProductsDto> GetClientWithProducts(int Id);
        void UpdateClient(ClientUpdateDto clientUpdateDto);
        void DeleteClient(int id);

    }
}
