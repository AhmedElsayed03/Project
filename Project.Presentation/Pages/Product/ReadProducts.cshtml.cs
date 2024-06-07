using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.Abstractions.Services;
using Project.Application.Models.DTOs;

namespace Project.Presentation.Pages.Product
{
    public class ReadProductsModel : PageModel
    {
        private readonly IProductService _productService;
        public ReadProductsModel(IProductService productService)
        {
            _productService = productService;
        }
        public List<ProductReadDto> ProductsList { get; set; }
        public ProductPaginationDto Products { get; set; }
        public List<int> PageNumbers { get; set; }
        public int CurrentPage { get; set; }

        public void OnGet(int pageNumber = 1, int elementsPerPage = 2)
        {
            Products = _productService.GetAll(pageNumber, elementsPerPage);
            ProductsList = Products.Products.ToList();
            int allProductsCount = Products.TotalCount;
            int totalPages = (int)Math.Ceiling((double)allProductsCount / elementsPerPage);
            PageNumbers = Enumerable.Range(1, totalPages).ToList();
            CurrentPage = pageNumber;
        }
    }
}
