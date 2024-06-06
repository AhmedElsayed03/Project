using Microsoft.AspNetCore.Mvc;
using Project.Application.Abstractions.Services;
using Project.Application.Models.DTOs;
using Project.Infrastructure.Services;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("Add-Product")]
        public ActionResult AddProduct(ProductAddDto newProduct)
        {
            _productService.AddProduct(newProduct);
            return Ok("Product Added!");
        }
    }
}
