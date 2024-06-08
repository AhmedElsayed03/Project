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
            var isActive = _unitOfWork.ProductRepo.GetByID(newclientProductAdd.ProductId)!.IsActive;
            if (isActive == true)
            {
                _unitOfWork.ClientProductRepo.Add(new ClientProduct
                {
                    StartDate = DateTime.Now,
                    EndDate = newclientProductAdd.EndDate,
                    License = newclientProductAdd.License,
                    ClientId = newclientProductAdd.ClientId,
                    ProductId = newclientProductAdd.ProductId
                });
            }
            _unitOfWork.SaveChanges();
        }

        public void UpdateClientProduct(clientProductUpdateDto clientProductUpdateDto)
        {

            var clientProductToUpdate = _unitOfWork.ClientProductRepo.GetByCompositeKeyAsync(clientProductUpdateDto.ProductId, clientProductUpdateDto.ClientId);
            clientProductToUpdate.StartDate = DateTime.Now;
            clientProductToUpdate.EndDate = clientProductUpdateDto.EndDate;
            clientProductToUpdate.License = clientProductUpdateDto.License;
            clientProductToUpdate.ClientId = clientProductUpdateDto.ClientId;
            clientProductToUpdate.ProductId = clientProductUpdateDto.ProductId;

            _unitOfWork.SaveChanges();
        }


        public void DeleteClientProduct(int productId, int clientId)
        {

            var clientProductToDelete = _unitOfWork.ClientProductRepo.GetByCompositeKeyAsync(productId, clientId);
            _unitOfWork.ClientProductRepo.Delete(clientProductToDelete);
            _unitOfWork.SaveChanges();
        }
    }
}
