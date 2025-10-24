using RealEstate.ApplicationLayer.DTOs.Property;
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
        Task<ViewPropertyDetailsDTO> AddProperty(AddPropertyDTO property);
        //Update
        Task<ViewPropertyDTO> UpdateProperty(int id, UpdatePropertyDTO property);
        //Delete
        Task<ViewPropertyDTO?> DeleteProperty(int id);
        //Read
        Task<ViewPropertyDTO?> GetPropertyById(int id);
        Task<List<ViewPropertyDTO>> GetAllProperties();
    }
}
