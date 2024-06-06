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

        public async Task<ProductPaginationDto> GetAll(int page, int countPerPage)
        {
            var products = await _unitOfWork.ProductRepo.GetAll(page, countPerPage);
            var productsDto = products.Select(i => new ProductReadDto
                {
                    Name = i.Name,
                    IsActive = i.IsActive
                });

            int totalCount = await _unitOfWork.ProductRepo.GetCount();

            return new ProductPaginationDto { Products = productsDto, TotalCount = totalCount };
        }

        public async Task<ProductDetailsReadDto> GetProductDetails(int Id)
        {
            var product = await _unitOfWork.ProductRepo.GetByIdAsync(Id);

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

            _unitOfWork.ProductRepo.AddAsync(product);
            _unitOfWork.SaveChangesAsync();
        }

   
        public void UpdateProduct(ProductUpdateDto productUpdateDto)
        {

            var productToUpdate = _unitOfWork.ProductRepo.GetByIdAsync(productUpdateDto.ProductId).Result!;
            productToUpdate.Name = productUpdateDto.Name;
            productToUpdate.Description = productUpdateDto.Description;
            productToUpdate.IsActive = productUpdateDto.IsActive;

            _unitOfWork.SaveChangesAsync();
        }

        public void DeleteProduct(int id)
        {

            var ProductToDelete = _unitOfWork.ProductRepo.GetByIdAsync(id);
            if (ProductToDelete.Result!.ClientProduct.Any() == false) {

                _unitOfWork.ProductRepo.DeleteAsync(ProductToDelete.Result!);
                _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
