using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.ApplicationLayer.Contracts;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyTypeController : ControllerBase
    {
        private readonly IPropertyTypeService propertyTypeService;
        public PropertyTypeController(IPropertyTypeService propertyTypeService) {
            this.propertyTypeService = propertyTypeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTypes() {
            return Ok(await propertyTypeService.GetAllPropertyTypesAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            return Ok(await propertyTypeService.GetPropertyTypeByIdAsync(id));
        }
    }
}
