using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using DTOs;
using static DTOs.CategoryDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860//

namespace PetsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //clean code writing meaningful function names
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CategoryController>//
        [HttpGet]
        public async Task<List<CategoryDto>> Get()
        {
            return await _categoryService.GetAll();
        }

       

    }
}
