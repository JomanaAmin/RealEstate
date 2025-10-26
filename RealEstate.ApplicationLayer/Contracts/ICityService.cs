using RealEstate.ApplicationLayer.DTOs.CityDTO;
using RealEstate.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.ApplicationLayer.Contracts
{
    public interface ICityService
    {
        Task <IEnumerable<CityDTO>> GetAllCitiesAsync();
        Task <CityDTO> GetCityByIdAsync(int id);
    }
}
