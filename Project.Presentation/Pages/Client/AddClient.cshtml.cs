using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.Abstractions.Services;
using Project.Application.Models.DTOs;

namespace Project.Presentation.Pages.Clients
{
    public class AddClientModel : PageModel
    {
        private readonly IClientService _clientService;
        public AddClientModel(IClientService clientService)
        {
            _clientService = clientService;
        }

        [BindProperty]
        public ClientAddDto? clientAddDto { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost() {

            if (ModelState.IsValid == false)
            {
                return Page();
            }
            _clientService.AddClient(clientAddDto!);
            return RedirectToPage("./ReadClients");
        }
    }
}
