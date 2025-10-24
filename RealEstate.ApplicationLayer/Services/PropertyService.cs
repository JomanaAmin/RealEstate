using Microsoft.EntityFrameworkCore;
using RealEstate.ApplicationLayer.Contracts;
using RealEstate.ApplicationLayer.DTOs.PropertyDTO;
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
        //CREATE
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

        ///DELETE 
        public async Task<ViewPropertyDTO?> DeletePropertyAsync(int id)
        {
            Property? property = await properties.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
            if (property == null) return null;

            return new ViewPropertyDTO { 
                Name=property.Name,
                Description=property.Description,
                CategoryName=property.Category.Name,
            };
        }

        //READ
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

        public async Task<ViewPropertyDTO?> GetPropertyByIdAsync(int id)
        {
            Property? property = await properties.GetByIdAsync(id);
            if (property == null) return null;
            return new ViewPropertyDTO { 
                Name = property.Name,
                Description=property.Description,
                CategoryName=property.Category.Name,
                Price=property.Price,
                City=property.City,
                Bathrooms=property.Bathrooms,
                Rooms=property.Rooms
            };
        }

        //UPDATE
        public async Task<ViewPropertyDTO> UpdatePropertyAsync(int id, UpdatePropertyDTO property)
        {
            Property updatedProperty = new Property { 
                Name= property.Name,
                Description=property.Description,

            };
            properties.Update(updatedProperty);
            await unitOfWork.SaveChangesAsync();
            return new ViewPropertyDTO { 
                Name=updatedProperty.Name,
                Description=updatedProperty.Description,
                Price=updatedProperty.Price,
                Rooms=updatedProperty.Rooms,
                Bathrooms=updatedProperty.Bathrooms,
                CategoryName=updatedProperty.Category.Name

            };
        }
    }
}
