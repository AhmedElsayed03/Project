using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.Abstractions.Services;
using Project.Application.Models.DTOs;

namespace Project.Presentation.Pages.Clients
{
    public class DeleteClientModel : PageModel
    {
        private readonly IClientService _clientService;
        public DeleteClientModel(IClientService clientService)
        {
            _clientService = clientService;
        }


        [BindProperty]
        public ClientUpdateDto? ClientUpdateDto { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = await _clientService.GetClientDetails(id);

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

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _clientService.DeleteClient(ClientUpdateDto!.ClientId!);
            return RedirectToPage("./ReadClients");
        }

    }
}
