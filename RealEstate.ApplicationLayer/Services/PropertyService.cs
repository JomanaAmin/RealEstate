using Microsoft.EntityFrameworkCore;
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
        public async Task<ViewPropertyDetailsDTO> AddPropertyAsync(AddPropertyDTO property)
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

        ///NEEDS TO BE COMPLETED 
        public async Task<ViewPropertyDTO?> DeletePropertyAsync(int id)
        {
            Property? property = await properties.DeleteAsync(id);
            if (property == null) return null;

            return new ViewPropertyDTO { 
                Name=property.Name,
                Description=property.Description,
                CategoryName=property.Category.Name,
            };

        }

        //to be continued, the mapping needs to be completed
        public async Task<IEnumerable<ViewPropertyDTO>> GetAllPropertiesAsync()
        {
            return await properties.GetAllQueryable().Select(
                property=> new ViewPropertyDTO 
                {
                    Name=property.Name,
                    Description=property.Description,
                    CategoryName=property.Category.Name,
                    Price=property.Price,
                    City=property.City,
                    Bathrooms=property.Bathrooms
                }
                ).AsNoTracking().ToListAsync();
        }

        public Task<ViewPropertyDTO?> GetPropertyByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ViewPropertyDTO> UpdatePropertyAsync(int id, UpdatePropertyDTO property)
        {
            throw new NotImplementedException();
        }
    }
}
