using Microsoft.AspNetCore.Mvc;
using Project.Application.Abstractions.Services;
using Project.Application.Models.DTOs;
using Project.Infrastructure.Services;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _ClientService;
        public ClientsController(IClientService clientService)
        {
            _ClientService = clientService;
        }

        [HttpPost]
        [Route("Add-Client")]
        public ActionResult AddClient(ClientAddDto newClient)
        {
            _ClientService.AddClient(newClient);
            return Ok("Client Added!");
        }
    }
}
