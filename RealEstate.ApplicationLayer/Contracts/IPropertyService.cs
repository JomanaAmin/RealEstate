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
        Task<ViewPropertyDTO?> GetPropertyByIdAsync(int id);
        Task<IEnumerable<ViewPropertyDTO>> GetAllPropertiesAsync();
        //Filtering
        Task 

    }
}
