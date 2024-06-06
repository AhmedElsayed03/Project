using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.Abstractions.Services;
using Project.Application.Models.DTOs;

namespace Project.Presentation.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IProductService _productService;
        public ProductsModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public ProductReadDto Product { get; set; }
        public void OnGet()
        {
        }
    }
}
