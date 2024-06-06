using Project.Application.Abstractions.Repositories;
using Project.Application.Abstractions.Services;
using Project.Application.Abstractions.UnitOfWork;
using Project.Application.Models.DTOs;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Services
{
    public class ClientProductService : IClientProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClientProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddClientProduct(ClientProductAddDto newclientProductAdd)
        {
            var isActive = _unitOfWork.ProductRepo.GetByIdAsync(newclientProductAdd.ProductId).Result!.IsActive;
            if (isActive == true)
            {
                _unitOfWork.ClientProductRepo.AddAsync(new ClientProduct
                {
                    StartDate = newclientProductAdd.StartDate,
                    EndDate = newclientProductAdd.EndDate,
                    License = newclientProductAdd.License,
                    ClientId = newclientProductAdd.ClientId,
                    ProductId = newclientProductAdd.ProductId
                });
            }
            _unitOfWork.SaveChangesAsync();
        }

        public void UpdateClientProduct(clientProductUpdateDto clientProductUpdateDto)
        {

            var clientProductToUpdate = _unitOfWork.ClientProductRepo.GetByCompositeKeyAsync(clientProductUpdateDto.ProductId, clientProductUpdateDto.ClientId).Result!;
            clientProductToUpdate.StartDate = clientProductUpdateDto.StartDate;
            clientProductToUpdate.EndDate = clientProductUpdateDto.EndDate;
            clientProductToUpdate.License = clientProductUpdateDto.License;
            clientProductToUpdate.ClientId = clientProductUpdateDto.ClientId;
            clientProductToUpdate.ProductId = clientProductUpdateDto.ProductId;

            _unitOfWork.SaveChangesAsync();
        }


        public void DeleteClientProduct(int productId, int clientId)
        {

            var clientProductToDelete = _unitOfWork.ClientProductRepo.GetByCompositeKeyAsync(productId, clientId).Result!;
            _unitOfWork.ClientProductRepo.DeleteAsync(clientProductToDelete);
            _unitOfWork.SaveChangesAsync();
        }
    }
}
