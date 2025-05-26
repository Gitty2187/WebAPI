using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using DTOs;
using static DTOs.ProductDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetsShop.Controllers
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

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<List<ProductDto>> Get()
        {
            return await _productService.GetAll();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            return await _productService.getById(id);
        }

        
    }
}
