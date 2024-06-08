using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.Abstractions.Services;
using Project.Application.Models.DTOs;

namespace Project.Presentation.Pages.Client
{
    public class ClientWithProductsModel : PageModel
    {
        private readonly IClientProductService _clientProductService;
        private readonly IClientService _clientService;

        public ClientWithProductsModel(IClientProductService clientProductService, IClientService clientService)
        {
            _clientProductService = clientProductService;
            _clientService = clientService;
        }
        public ClientWithProductsDto ClientWithProducts { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            ClientWithProducts = await _clientService.GetClientWithProducts(id);

            if (ClientWithProducts == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
