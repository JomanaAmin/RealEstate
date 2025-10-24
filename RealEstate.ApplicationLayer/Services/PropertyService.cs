using RealEstate.ApplicationLayer.Contracts;
using RealEstate.ApplicationLayer.DTOs.Property;
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
    internal class PropertyService : IPropertyService
    {
        private readonly IUnitOfWork unitOfWork;
        private IPropertyRepository properties;

        public PropertyService(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork= unitOfWork;
            properties = unitOfWork.Properties;
        }
        public async Task<ViewPropertyDetailsDTO> AddProperty(AddPropertyDTO property)
        {
            Property newProperty = new Property
            {
                Name=property.Name,
                CategoryId=property.CategoryId,
                Description=property.Description,
                Price=property.Price,
                City=property.City,
                Address=property.Address,
                Rooms=property.Rooms,
                Bathrooms=property.Bathrooms,
                PropertyTypeId=property.PropertyTypeId,
                AreaSize=property.AreaSize,
                Furnished=property.Furnished,
                IsAvailable=property.IsAvailable,
                ContactPhone=property.ContactPhone,
                ContactWhatsapp=property.ContactWhatsapp,
                CreatedAt=DateTime.Now
                //Images=property.Images
            };
            await properties.AddAsync(newProperty);
            await unitOfWork.SaveChangesAsync();
            ViewPropertyDetailsDTO addedProperty = new ViewPropertyDetailsDTO
            {
                Id=newProperty.Id,
                Name=newProperty.Name,
                CategoryId=newProperty.CategoryId,
                Description=newProperty.Description,
                Price=newProperty.Price,
                City=newProperty.City,
                Address=newProperty.Address,
                Rooms=newProperty.Rooms,
                Bathrooms=newProperty.Bathrooms,
                PropertyTypeId=newProperty.PropertyTypeId,
                AreaSize=newProperty.AreaSize,
                Furnished=newProperty.Furnished,
                IsAvailable=newProperty.IsAvailable,
                ContactPhone=newProperty.ContactPhone,
                ContactWhatsapp=newProperty.ContactWhatsapp,
                CreatedAt=newProperty.CreatedAt
            };
            return addedProperty;
        }

        public Task<ViewPropertyDTO?> DeleteProperty(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ViewPropertyDTO>> GetAllProperties()
        {
            throw new NotImplementedException();
        }

        public Task<ViewPropertyDTO?> GetPropertyById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ViewPropertyDTO> UpdateProperty(int id, UpdatePropertyDTO property)
        {
            throw new NotImplementedException();
        }
    }
}
