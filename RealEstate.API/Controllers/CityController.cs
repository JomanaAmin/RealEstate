using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.ApplicationLayer.Contracts;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService cityService;
        public CityController(ICityService cityService) 
        {
            this.cityService = cityService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            return Ok(await this.cityService.GetAllCitiesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id) 
        {
            return Ok(await this.cityService.GetCityByIdAsync(id));

        }
    }
}
