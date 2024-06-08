using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Application.Abstractions.Services;
using Project.Application.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Project.Presentation.Pages.Cart
{
    public class AddProductToClientModel : PageModel
    {
        private readonly IClientProductService _clientProductService;
        private readonly IClientService _clientService;
        private readonly IProductService _productService;

        public AddProductToClientModel(IClientProductService clientProductService, IClientService clientService, IProductService productService)
        {
            _clientProductService = clientProductService;
            _clientService = clientService;
            _productService = productService;
        }

        [BindProperty]
        public ClientProductAddDto ClientProductAdd { get; set; }

        public List<SelectListItem> ClientsList { get; set; }
        public List<SelectListItem> ProductsList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ClientsList = (await _clientService.GetAllClients())
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            ProductsList = (await _productService.GetAllProducts())
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ClientsList = (await _clientService.GetAllClients())
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList();

                ProductsList = (await _productService.GetAllProducts())
                    .Select(p => new SelectListItem
                    {
                        Value = p.Id.ToString(),
                        Text = p.Name
                    }).ToList();

                return Page();
            }

            await _clientProductService.AddClientProduct(ClientProductAdd);

            return RedirectToPage("/Index");
        }
    }
}