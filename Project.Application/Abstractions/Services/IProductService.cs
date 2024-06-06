using Project.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<ProductPaginationDto> GetAll(int page, int countPerPage);
        Task<ProductDetailsReadDto> GetProductDetails(int Id);
        void AddProduct(ProductAddDto newProduct);
        void UpdateProduct(ProductUpdateDto productUpdateDto);
    }
}
