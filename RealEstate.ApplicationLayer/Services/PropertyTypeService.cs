using Microsoft.EntityFrameworkCore;
using RealEstate.ApplicationLayer.Contracts;
using RealEstate.ApplicationLayer.DTOs.PropertyTypeDTO;
using RealEstate.DAL.Contracts;
using RealEstate.DAL.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.ApplicationLayer.Services
{
    internal class PropertyTypeService : IPropertyTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        private IPropertyTypeRepository propertyTypes;
        public PropertyTypeService(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
            propertyTypes= unitOfWork.PropertyTypes;
        }

        public async Task<IEnumerable<ViewPropertyTypeDTO>> GetAllPropertyTypesAsync() 
        {
            return await propertyTypes.GetAllQueryable().Select(
                propertyType => new ViewPropertyTypeDTO
                {
                    Name = propertyType.Name,
                    Id = propertyType.Id,
                    Description = propertyType.Description
                }).AsNoTracking().ToListAsync();
        }

        public async Task<ViewPropertyTypeDTO> GetPropertyTypeByIdAsync(int id) 
        {
            var propertyType= await propertyTypes.GetByIdAsync(id);
            if (propertyType == null) return null;
            return new ViewPropertyTypeDTO { 
                Name=propertyType.Name,
                Id=propertyType.Id,
                Description=propertyType.Description
            };
        }
    }
}
