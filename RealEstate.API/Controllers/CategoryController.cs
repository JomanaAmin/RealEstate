using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.ApplicationLayer.Contracts;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService) 
        {
            this.categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await categoryService.GetAllCategoriesAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            return Ok(await categoryService.GetCategoryByIdAsync(id));
        }
    }
}
