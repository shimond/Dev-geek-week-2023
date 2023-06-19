using FirstWebApp.Models;
using FirstWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Net.Http.Headers;

namespace FirstWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            this._productsRepository = productsRepository;
        }


        [HttpGet]
        [OutputCache(Duration = 20)]
        [ProducesResponseType(200, Type = typeof(List<Product>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productsRepository.GetAllProducts();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Product))]
        public async Task<IActionResult> AddNewProduct(Product p)
        {
            var newProduct = await _productsRepository.AddNewProduct(p);
            return Created($"api/products/{newProduct.Id}", newProduct);
        }
    }
}
