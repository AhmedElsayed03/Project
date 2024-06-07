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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ProductPaginationDto GetAll(int page, int countPerPage)
        {
            var products = _unitOfWork.ProductRepo.GetAll(page, countPerPage);
            var productsDto = products.Select(i => new ProductReadDto
                {
                    Name = i.Name,
                    IsActive = i.IsActive,
                    Description = i.Description,

                });

            int totalCount = _unitOfWork.ProductRepo.GetCount();

            return new ProductPaginationDto { Products = productsDto, TotalCount = totalCount };
        }

        public ProductDetailsReadDto GetProductDetails(int Id)
        {
            var product = _unitOfWork.ProductRepo.GetByID(Id);

            return new ProductDetailsReadDto
            {
                Name = product!.Name,
                Description = product.Description,
                IsActive = product.IsActive

            };
        }

        public void AddProduct(ProductAddDto newProduct)
        {
            Product product = new Product
            {
                Name = newProduct.Name,
                Description = newProduct.Description,
                IsActive = newProduct.IsActive
            };

            _unitOfWork.ProductRepo.Add(product);
            _unitOfWork.SaveChanges();
        }

   
        public void UpdateProduct(ProductUpdateDto productUpdateDto)
        {

            var productToUpdate = _unitOfWork.ProductRepo.GetByID(productUpdateDto.ProductId);
            productToUpdate.Name = productUpdateDto.Name;
            productToUpdate.Description = productUpdateDto.Description;
            productToUpdate.IsActive = productUpdateDto.IsActive;

            _unitOfWork.SaveChanges();
        }

        public void DeleteProduct(int id)
        {

            var ProductToDelete = _unitOfWork.ProductRepo.GetByID(id);
            if (ProductToDelete.ClientProduct.Any() == false) {

                _unitOfWork.ProductRepo.Delete(ProductToDelete);
                _unitOfWork.SaveChanges();
            }
        }
    }
}
