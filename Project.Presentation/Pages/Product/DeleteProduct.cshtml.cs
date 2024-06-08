using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.Abstractions.Services;
using Project.Application.Models.DTOs;

namespace Project.Presentation.Pages.Product
{
    public class DeleteProductModel : PageModel
    {
        private readonly IProductService _productService;
        public DeleteProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public ProductUpdateDto? productUpdateDto { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await _productService.GetProductDetails(id);

            if (product == null)
            {
                return NotFound();
            }

            productUpdateDto = new ProductUpdateDto
            {
                ProductId = id,
                Name = product.Name,
                Description = product.Description,
                IsActive = product.IsActive
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productService.DeleteProduct(productUpdateDto!.ProductId);
            return RedirectToPage("./ReadProducts");
        }

    }
}
