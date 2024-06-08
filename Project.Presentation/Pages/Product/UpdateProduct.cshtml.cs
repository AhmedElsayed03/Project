using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.Abstractions.Services;
using Project.Application.Models.DTOs;

namespace Project.Presentation.Pages.Product
{
    public class UpdateProductModel : PageModel
    {
        private readonly IProductService _productService;
        public UpdateProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public ProductUpdateDto? productUpdateDto { get; set; }

        public IActionResult OnGet(int id)
        {

            var product = _productService.GetProductDetails(id);

            if (product == null)
            {
                return NotFound();
            }

            productUpdateDto = new ProductUpdateDto
            {
                ProductId = id,
                Name = product.Name,
                Description = product.Description,
                IsActive = product.IsActive,
             
            };

            return Page();

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _productService.UpdateProduct(productUpdateDto!);
            return RedirectToPage("./ReadProducts");

        }
    }
}
