using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.Abstractions.Services;
using Project.Application.Models.DTOs;

namespace Project.Presentation.Pages.Product
{
    public class AddProductModel : PageModel
    {
        private readonly IProductService _ProductService;
        public AddProductModel(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [BindProperty]
        public ProductAddDto? productAddDto { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid == false)
            {
                return Page();
            }
            _ProductService.AddProduct(productAddDto!);
            return RedirectToPage("./ReadProducts");
        }
    }
}
