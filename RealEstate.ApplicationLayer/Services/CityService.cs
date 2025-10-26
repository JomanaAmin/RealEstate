using Microsoft.EntityFrameworkCore;
using RealEstate.ApplicationLayer.Contracts;
using RealEstate.ApplicationLayer.DTOs.CityDTO;
using RealEstate.DAL.Contracts;
using RealEstate.DAL.Entities;
using RealEstate.DAL.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.ApplicationLayer.Services
{
    internal class CityService : ICityService
    {
        private readonly IUnitOfWork unitOfWork;
        private ICityRepository cities;
        public CityService(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
            this.cities = unitOfWork.Cities;
        }
        public async Task<IEnumerable<CityDTO>> GetAllCitiesAsync() 
        {
            return await cities.GetAllQueryable().Select(city=>new CityDTO { Name=city.Name , Id= city.Id}).AsNoTracking().ToListAsync();
        }
        public async Task<CityDTO> GetCityByIdAsync(int id) 
        {
            City? city= await cities.GetByIdAsync(id); //will return null if not found
            if (city == null) 
            {
                throw new FileNotFoundException("This ID doesnt exist");
            }
            return new CityDTO
            {
                Name = city.Name,
                Id = city.Id
            };
        }
    }
}
