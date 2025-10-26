using RealEstate.ApplicationLayer.DTOs.PropertyDTO;
using RealEstate.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.ApplicationLayer.Contracts
{
    public interface IPropertyService
    {
        //im going to add basic CRUD operations here 

        //Create
        Task<ViewPropertyDetailsDTO> AddPropertyAsync(AddPropertyDTO property);
        //Update
        Task<ViewPropertyDTO> UpdatePropertyAsync(UpdatePropertyDTO property);
        //Delete
        Task<ViewPropertyDTO?> DeletePropertyAsync(int id);
        //Read
        Task<ViewPropertyDTO?> GetPropertyByIdAsync(int id); //read 1 property by id
        Task<IEnumerable<ViewPropertyDTO>> GetAllPropertiesAsync(); //get all properties
        //Filtering
        Task <IEnumerable<ViewPropertyDTO>> GetPropertiesByFilterAsync(int? categoryId = null, int? propertyTypeId = null, decimal? maxPrice = null, decimal? minPrice = null, int? cityId = null, int? minBedrooms = null, int? maxBedrooms = null);

    }
}
