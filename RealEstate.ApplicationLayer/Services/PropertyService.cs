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
        private ICategoryRepository categories;

        public PropertyService(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork= unitOfWork;
            properties = unitOfWork.Properties;
            categories = unitOfWork.Categories;
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

            newProperty = await properties.GetPropertyAsync(newProperty.Id);
            ViewPropertyDetailsDTO addedProperty = new ViewPropertyDetailsDTO
            {
                Id=newProperty.Id,
                Name=newProperty.Name,
                Category=newProperty.Category,
                CategoryId=newProperty.CategoryId,
                Description=newProperty.Description,
                Price=newProperty.Price,
                City=newProperty.City,
                Address=newProperty.Address,
                Rooms=newProperty.Rooms,
                Bathrooms=newProperty.Bathrooms,
                PropertyTypeId=newProperty.PropertyTypeId,
                PropertyType=newProperty.PropertyType,
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
            Property? property = await properties.DeletePropertyAsync(id);
            if (property == null) return null;
            ViewPropertyDTO deletedProperty = new ViewPropertyDTO
            {
                Id = property.Id, // Don't forget the ID!
                Name = property.Name,
                Description = property.Description,

                // Mapped from Eager Loaded Navigation Properties
                CategoryName = property.Category.Name, // Category is loaded and available
                PropertyTypeName = property.PropertyType.Name, // PropertyType is loaded and available

                Price = property.Price,
                City = property.City,
                Rooms = property.Rooms,
                Bathrooms = property.Bathrooms,
                AreaSize = property.AreaSize,
                Furnished = property.Furnished,
                IsAvailable = property.IsAvailable,
                ContactPhone = property.ContactPhone,
                ContactWhatsapp = property.ContactWhatsapp,

                // Assuming Images is a navigation property on Property
                Images = property.Images
            };
            await unitOfWork.SaveChangesAsync();
            return deletedProperty;
        }

        //READ
        //to be continued, the mapping needs to be completed
        public async Task<IEnumerable<ViewPropertyDTO>> GetAllPropertiesAsync()
        {
            return await properties.GetAllWithDetailsQueryable().Select(
                property=> new ViewPropertyDTO 
                {
                    Id = property.Id, // Don't forget the ID!
                    Name = property.Name,
                    Description = property.Description,

                    // Mapped from Eager Loaded Navigation Properties
                    CategoryName = property.Category.Name, // Category is loaded and available
                    PropertyTypeName = property.PropertyType.Name, // PropertyType is loaded and available

                    Price = property.Price,
                    City = property.City,
                    Rooms = property.Rooms,
                    Bathrooms = property.Bathrooms,
                    AreaSize = property.AreaSize,
                    Furnished = property.Furnished,
                    IsAvailable = property.IsAvailable,
                    ContactPhone = property.ContactPhone,
                    ContactWhatsapp = property.ContactWhatsapp,

                    // Assuming Images is a navigation property on Property
                    Images = property.Images
                }
                ).AsNoTracking().ToListAsync();
        }

        public async Task<ViewPropertyDTO?> GetPropertyByIdAsync(int id)
        {
            Property? property = await properties.GetPropertyAsync(id);
            if (property == null) return null;
            return new ViewPropertyDTO {
                Id = property.Id, // Don't forget the ID!
                Name = property.Name,
                Description = property.Description,

                // Mapped from Eager Loaded Navigation Properties
                CategoryName = property.Category.Name, // Category is loaded and available
                PropertyTypeName = property.PropertyType.Name, // PropertyType is loaded and available

                Price = property.Price,
                City = property.City,
                Rooms = property.Rooms,
                Bathrooms = property.Bathrooms,
                AreaSize = property.AreaSize,
                Furnished = property.Furnished,
                IsAvailable = property.IsAvailable,
                ContactPhone = property.ContactPhone,
                ContactWhatsapp = property.ContactWhatsapp,

                // Assuming Images is a navigation property on Property
                Images = property.Images
            };
        }

        //UPDATE
        public async Task<ViewPropertyDTO> UpdatePropertyAsync(UpdatePropertyDTO propertyDTO)
        {
            Property? oldProperty = await properties.GetPropertyAsync(propertyDTO.Id);
            if (oldProperty == null) throw new KeyNotFoundException($"Property with ID {propertyDTO.Id} not found.");
            //it does not exist to be updated
            /////
            //it exists, update
            oldProperty.Name = propertyDTO.Name;
            oldProperty.Description = propertyDTO.Description;
            oldProperty.Price = propertyDTO.Price;
            oldProperty.City = propertyDTO.City;
            oldProperty.Address = propertyDTO.Address; 
            oldProperty.Rooms = propertyDTO.Rooms;
            oldProperty.Bathrooms = propertyDTO.Bathrooms;
            oldProperty.CategoryId = propertyDTO.CategoryId;
            oldProperty.PropertyTypeId = propertyDTO.PropertyTypeId;
            oldProperty.AreaSize = propertyDTO.AreaSize;
            oldProperty.Furnished = propertyDTO.Furnished;
            oldProperty.IsAvailable = propertyDTO.IsAvailable;
            oldProperty.ContactPhone = propertyDTO.ContactPhone;
            oldProperty.ContactWhatsapp = propertyDTO.ContactWhatsapp;

            properties.Update(oldProperty);
            await unitOfWork.SaveChangesAsync();
            oldProperty = await properties.GetPropertyAsync(propertyDTO.Id);//to get the updated property with navigation properties
            return new ViewPropertyDTO {
                Id = oldProperty.Id, // Don't forget the ID!
                Name = oldProperty.Name,
                Description = oldProperty.Description,

                // Mapped from Eager Loaded Navigation Properties
                CategoryName = oldProperty.Category.Name, // Category is loaded and available
                PropertyTypeName = oldProperty.PropertyType.Name, // PropertyType is loaded and available

                Price = oldProperty.Price,
                City = oldProperty.City,
                Rooms = oldProperty.Rooms,
                Bathrooms = oldProperty.Bathrooms,
                AreaSize = oldProperty.AreaSize,
                Furnished = oldProperty.Furnished,
                IsAvailable = oldProperty.IsAvailable,
                ContactPhone = oldProperty.ContactPhone,
                ContactWhatsapp = oldProperty.ContactWhatsapp,

                // Assuming Images is a navigation property on Property
                Images = oldProperty.Images
            };
        }
    }
}
