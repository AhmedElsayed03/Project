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
                    Id = i.Id,
                    Name = i.Name,
                    IsActive = i.IsActive,
                    Description = i.Description,

                });

            int totalCount = await _unitOfWork.ProductRepo.GetCount();

            return new ProductPaginationDto { Products = productsDto, TotalCount = totalCount };
        }

        public async Task<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            var products = await _unitOfWork.ProductRepo.GetAllAsync();
            var productsDto = products.Select(i => new ProductReadDto
            {
                Id= i.Id,
                Name = i.Name,
                IsActive = i.IsActive,
                Description = i.Description,

            });

            return productsDto;
        }

        public async Task<ProductDetailsReadDto> GetProductDetails(int Id)
        {
            var product =await _unitOfWork.ProductRepo.GetByIdAsync(Id);

            return new ProductDetailsReadDto
            {
                
                Name = product!.Name,
                Description = product.Description,
                IsActive = product.IsActive

            };
        }

        public async Task AddProduct(ProductAddDto newProduct)
        {
            Product product = new Product
            {
                Name = newProduct.Name,
                Description = newProduct.Description,
                IsActive = newProduct.IsActive
            };

            await _unitOfWork.ProductRepo.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }

   
        public async Task UpdateProduct(ProductUpdateDto productUpdateDto)
        {

            var productToUpdate = await _unitOfWork.ProductRepo.GetByIdAsync(productUpdateDto.ProductId);
            productToUpdate!.Name = productUpdateDto.Name;
            productToUpdate.Description = productUpdateDto.Description;
            productToUpdate.IsActive = productUpdateDto.IsActive;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {

            var ProductToDelete = await _unitOfWork.ProductRepo.GetByIdAsync(id);
            //if (ProductToDelete.ClientProduct.Any() == false) {

                await _unitOfWork.ProductRepo.DeleteAsync(ProductToDelete!);
                await _unitOfWork.SaveChangesAsync();
            //}
        }
    }
}
