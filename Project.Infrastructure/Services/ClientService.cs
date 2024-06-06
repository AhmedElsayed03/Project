using Microsoft.EntityFrameworkCore;
using Project.Application.Abstractions.Services;
using Project.Application.Abstractions.UnitOfWork;
using Project.Application.Models.DTOs;
using Project.Domain.Entities;
using Project.Infrastructure.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ClientReadDto>> GetAll(int page, int countPerPage)
        {
            var Clients = await _unitOfWork.ClientRepo.GetAll(page, countPerPage);
            var clientsDto = Clients.Select(i => new ClientReadDto
                {
                    Name = i.Name,
                    State = i.State,
                });

            return clientsDto;
        }

        public async Task<ClientDetailsReadDto> GetClientDetails(int Id)
        {
            var client =await _unitOfWork.ClientRepo.GetByIdAsync(Id);

            return new ClientDetailsReadDto
            {
                Name = client!.Name,
                Code = client.Code,
                Class = client.Class,
                State = client.State,
            };
        }

        public async Task<ClientWithProductsDto> GetClientWithProducts(int Id)
        {
            var clientWithProducts = await _unitOfWork.ClientRepo.GetClientWithProducts(Id);

            var result = new ClientWithProductsDto
            {
                ClientName = clientWithProducts!.Name,
                Code = clientWithProducts.Code,
                Class = clientWithProducts.Class,
                State = clientWithProducts.State,
            };

            result.ClientProduct = clientWithProducts.ClientProduct
                .OrderBy(i => i.Product.Name)
                .Select(i => new ProductsListReadDto
                {
                    EndDate = i.EndDate,
                    StartDate = i.StartDate,
                    License = i.License,
                    Description = i.Product.Description,
                    IsActive = i.Product.IsActive,
                    Name = i.Product.Name

                }).ToList();

            return result;
        }

        public void AddClient(ClientAddDto newClient)
        {
            Client client = new Client
            {
                Name = newClient.Name,
                Code = newClient.Code,
                Class = newClient.Class,
                State = newClient.State,
            };

            _unitOfWork.ClientRepo.AddAsync(client);
            _unitOfWork.SaveChangesAsync();
        }


        //User Can only update his name
        public void UpdateClient(ClientUpdateDto clientUpdateDto)
        {
           
           var clientToUpdate = _unitOfWork.ClientRepo.GetByIdAsync(clientUpdateDto.ClientId).Result!;
           clientToUpdate.Name = clientUpdateDto.Name;

           _unitOfWork.SaveChangesAsync();
        }

        public void DeleteClient(int id) {

            var clientToDelete = _unitOfWork.ClientRepo.GetByIdAsync(id);
            _unitOfWork.ClientRepo.DeleteAsync(clientToDelete.Result!);
            _unitOfWork.SaveChangesAsync();

        }

}
}
