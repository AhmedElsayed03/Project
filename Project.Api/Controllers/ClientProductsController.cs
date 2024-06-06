using Microsoft.AspNetCore.Mvc;
using Project.Application.Abstractions.Services;
using Project.Application.Models.DTOs;
using Project.Infrastructure.Services;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientProductsController : ControllerBase
    {
        private readonly IClientProductService _clientProductService;
        public ClientProductsController(IClientProductService clientProductService)
        {
            _clientProductService = clientProductService;
        }

        [HttpPost]
        [Route("Add-Client-Product")]
        public ActionResult AddClientProduct(ClientProductAddDto newClientProduct)
        {
            _clientProductService.AddClientProduct(newClientProduct);
            return Ok("Client Product Added!");
        }

    }
}
