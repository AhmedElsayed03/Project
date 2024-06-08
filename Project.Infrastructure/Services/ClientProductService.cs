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

        public async Task AddClientProduct(ClientProductAddDto newclientProductAdd)
        {
            var isActive = await _unitOfWork.ProductRepo.GetByIdAsync(newclientProductAdd.ProductId)!;
            var resultIsActive = isActive!.IsActive;
            if (resultIsActive == true)
            {
                await _unitOfWork.ClientProductRepo.AddAsync(new ClientProduct
                {
                    StartDate = DateTime.Now,
                    EndDate = newclientProductAdd.EndDate,
                    License = newclientProductAdd.License,
                    ClientId = newclientProductAdd.ClientId,
                    ProductId = newclientProductAdd.ProductId
                });
            }
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateClientProduct(clientProductUpdateDto clientProductUpdateDto)
        {

            var clientProductToUpdate = await _unitOfWork.ClientProductRepo.GetByCompositeKeyAsync(clientProductUpdateDto.ProductId, clientProductUpdateDto.ClientId);
            clientProductToUpdate.StartDate = DateTime.Now;
            clientProductToUpdate.EndDate = clientProductUpdateDto.EndDate;
            clientProductToUpdate.License = clientProductUpdateDto.License;
            clientProductToUpdate.ClientId = clientProductUpdateDto.ClientId;
            clientProductToUpdate.ProductId = clientProductUpdateDto.ProductId;

            await _unitOfWork.SaveChangesAsync();
        }


        public async Task DeleteClientProduct(int productId, int clientId)
        {

            var clientProductToDelete = await _unitOfWork.ClientProductRepo.GetByCompositeKeyAsync(productId, clientId);
            await _unitOfWork.ClientProductRepo.DeleteAsync(clientProductToDelete);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
