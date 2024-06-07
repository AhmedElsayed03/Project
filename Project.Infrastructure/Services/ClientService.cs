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

        public IEnumerable<ClientReadDto> GetAll(int page, int countPerPage)
        {
            var Clients = _unitOfWork.ClientRepo.GetAll(page, countPerPage);
            var clientsDto = Clients.Select(i => new ClientReadDto
                {
                    Id= i.Id,
                    Name = i.Name,
                    State = i.State,
                    Class = i.Class,
                    Code = i.Code,
                });

            return clientsDto;
        }
        
        public ClientDetailsReadDto GetClientDetails(int Id)
        {
            var client = _unitOfWork.ClientRepo.GetByID(Id);

            return new ClientDetailsReadDto
            {
                Name = client!.Name,
                Code = client.Code,
                Class = client.Class,
                State = client.State,
            };
        }

        public ClientWithProductsDto GetClientWithProducts(int Id)
        {
            var clientWithProducts = _unitOfWork.ClientRepo.GetClientWithProducts(Id);

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
                Class = (Class)newClient.Class,
                State = State.Pending
            };
            Debug.WriteLine($"Client Data: {client}");
            _unitOfWork.ClientRepo.Add(client);
            _unitOfWork.SaveChanges();
        }


        
        public void UpdateClient(ClientUpdateDto clientUpdateDto)
        {
           
           var clientToUpdate = _unitOfWork.ClientRepo.GetByID(clientUpdateDto.ClientId);
            clientToUpdate!.Name = clientUpdateDto.Name;
            clientToUpdate.State = (State)clientUpdateDto.State;
            clientToUpdate.Class = (Class)clientUpdateDto.Class;

           _unitOfWork.SaveChanges();
        }

        public void DeleteClient(int id) {

            var clientToDelete = _unitOfWork.ClientRepo.GetByID(id);
            _unitOfWork.ClientRepo.Delete(clientToDelete!);
            _unitOfWork.SaveChanges();

        }

        public int GetClientCount()
        {
            return _unitOfWork.ClientRepo.GetCount();
        }


    }
}
