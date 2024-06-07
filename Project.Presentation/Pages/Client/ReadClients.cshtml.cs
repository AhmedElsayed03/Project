using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.Abstractions.Services;
using Project.Application.Models.DTOs;

namespace Project.Presentation.Pages.Clients
{
    public class ReadClientsModel : PageModel
    {
        private readonly IClientService _clientService;
        public ReadClientsModel(IClientService clientService)
        {
            _clientService = clientService;
        }
        public List<ClientReadDto> Clients { get; set; }
        public List<int> PageNumbers { get; set; }
        public int CurrentPage { get; set; }

        public void OnGet(int pageNumber = 1, int elementsPerPage = 2)
        {
            Clients = _clientService.GetAll(pageNumber, elementsPerPage).ToList();
            int allClientsCount = _clientService.GetClientCount();
            int totalPages = (int)Math.Ceiling((double)allClientsCount / elementsPerPage);
            PageNumbers = Enumerable.Range(1, totalPages).ToList();
            CurrentPage = pageNumber;
        }
    }
}
