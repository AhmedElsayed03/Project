using Azure;
using Microsoft.EntityFrameworkCore;
using Project.Application.Abstractions.Services;
using Project.Application.Abstractions.UnitOfWork;
using Project.Application.Models.DTOs;
using Project.Domain.Entities;
using Project.Domain.Enums;
using Project.Infrastructure.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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
            var clientsQuery = await _unitOfWork.ClientRepo.GetAll(page, countPerPage);
                                                     
            var orderedClientsQuery = clientsQuery.OrderBy(c => c.Id);
            var clients =  orderedClientsQuery.ToList();

            var clientsDto = clients.Select(i => new ClientReadDto
            {
                Id = i.Id,
                Name = i.Name,
                State = i.State,
                Class = i.Class,
                Code = i.Code,
            });

            return clientsDto;
        }



        public async Task<ClientDetailsReadDto> GetClientDetails(int Id)
        {
            var client = await _unitOfWork.ClientRepo.GetByIdAsync(Id);

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

        public async Task AddClient(ClientAddDto newClient)
        {

            Client client = new Client
            {
                Name = newClient.Name,
                Code = newClient.Code,
                Class = (Class)newClient.Class,
                State = State.Pending
            };
            Debug.WriteLine($"Client Data: {client}");
            await _unitOfWork.ClientRepo.AddAsync(client);
            await _unitOfWork.SaveChangesAsync();
        }


        
        public async Task UpdateClient(ClientUpdateDto clientUpdateDto)
        {
           
           var clientToUpdate =await _unitOfWork.ClientRepo.GetByIdAsync(clientUpdateDto.ClientId);
            clientToUpdate!.Name = clientUpdateDto.Name;
            clientToUpdate.State = (State)clientUpdateDto.State;
            clientToUpdate.Class = (Class)clientUpdateDto.Class;

           await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteClient(int id) {

            var clientToDelete =await _unitOfWork.ClientRepo.GetByIdAsync(id);
            await _unitOfWork.ClientRepo.DeleteAsync(clientToDelete!);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<int> GetClientCount()
        {
            return await _unitOfWork.ClientRepo.GetCount();
        }

        public async Task<IEnumerable<ClientReadDto>> GetAllClients()
        {
            var Clients = await _unitOfWork.ClientRepo.GetAllAsync();

            var orderdClients = Clients.OrderBy(c => c.Id).ToList();


            var clientsDto = Clients.Select(i => new ClientReadDto
            {
                Id = i.Id,
                Name = i.Name,
                State = i.State,
                Class = i.Class,
                Code = i.Code,
            });

            return clientsDto;
        }
    }
}
