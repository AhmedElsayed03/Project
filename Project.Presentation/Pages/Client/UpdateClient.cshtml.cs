using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.Abstractions.Services;
using Project.Application.Models.DTOs;
using Project.Domain.Enums;

namespace Project.Presentation.Pages.Clients
{
    public class UpdateClientModel : PageModel
    {
        private readonly IClientService _clientService;
        public UpdateClientModel(IClientService clientService)
        {
            _clientService = clientService;
        }

        [BindProperty]
        public ClientUpdateDto? ClientUpdateDto { get; set; }

        public IActionResult OnGet(int id)
        {

            var client = _clientService.GetClientDetails(id);

            if (client == null)
            {
                return NotFound();
            }

            ClientUpdateDto = new ClientUpdateDto
            {
                ClientId = id,
                Name = client.Name,
                Class = (ClassEnumViewModel)client.Class,
                State = (StateEnumViewModel)client.State
            };

            return Page();

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _clientService.UpdateClient(ClientUpdateDto!);
            return RedirectToPage("./ReadClients");

        }
    }
}
