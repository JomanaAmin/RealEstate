using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.ApplicationLayer.Contracts;
using RealEstate.ApplicationLayer.DTOs.PropertyDTO;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService propertyService;
        public PropertyController(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPropertyDTO property)
        {
            var addedProperty = await propertyService.AddPropertyAsync(property);
            return Ok(addedProperty);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id) 
        {
           var property= await propertyService.GetPropertyByIdAsync(id);
            return Ok(property);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            return Ok(await propertyService.DeletePropertyAsync(id));
        }
    }
    
}
