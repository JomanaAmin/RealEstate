using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.ApplicationLayer.Contracts;
using RealEstate.ApplicationLayer.DTOs.Property;

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
    }
}
