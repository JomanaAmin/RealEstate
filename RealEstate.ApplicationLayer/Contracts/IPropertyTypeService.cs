using RealEstate.ApplicationLayer.DTOs.PropertyTypeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.ApplicationLayer.Contracts
{
    public interface IPropertyTypeService
    {
        Task<IEnumerable<ViewPropertyTypeDTO>> GetAllPropertyTypesAsync();
        Task<ViewPropertyTypeDTO> GetPropertyTypeByIdAsync(int id);
    }
}
