using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.CustomAttribute;
using RealEstate.ApplicationLayer.Contracts;
using RealEstate.ApplicationLayer.DTOs.PropertyDTO;
using RealEstate.DAL.Entities;

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
        [ApiKey]
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
        //[HttpGet]
        //public async Task<IActionResult> GetAll() 
        //{
        //    return Ok(await propertyService.GetAllPropertiesAsync());
        //}

        [HttpDelete("{id}")]
        [ApiKey]
        public async Task<IActionResult> Delete(int id) 
        {
            return Ok(await propertyService.DeletePropertyAsync(id));
        }

        [HttpPut]
        [ApiKey]
        public async Task<IActionResult> Update(UpdatePropertyDTO property) 
        {
            var updatedProperty = await propertyService.UpdatePropertyAsync(property);
            return Ok(updatedProperty);
        }

        [HttpGet] //int? categoryId = null, int? propertyTypeId = null, decimal? maxPrice = null, decimal? minPrice = null, int? cityId = null, int? minBedrooms = null, int? maxBedrooms = null
        public async Task<IActionResult> GetFilteredProperties(int? categoryId = null, int? propertyTypeId = null, decimal? maxPrice = null, decimal? minPrice = null, int? cityId = null, int? minBedrooms = null, int? maxBedrooms = null) 
        {
            var properties =await propertyService.GetPropertiesByFilterAsync(categoryId, propertyTypeId, maxPrice, minPrice, cityId, minBedrooms, maxBedrooms);
            return Ok(properties);
        }
    
    }
    
}
