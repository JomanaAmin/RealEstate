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
            return await properties.GetAllWithDetailsQueryable().Select(
                property=> new ViewPropertyDTO 
                {
                    Id=property.Id,
                    Name=property.Name,
                    Description=property.Description,
                    CategoryName=property.Category.Name,
                    Price=property.Price,
                    City=property.City,
                    Bathrooms=property.Bathrooms,
                    PropertyTypeName=property.PropertyType.Name
                }
                ).AsNoTracking().ToListAsync();
        }

        public async Task<ViewPropertyDTO?> GetPropertyByIdAsync(int id)
        {
            Property? property = await properties.GetPropertyAsync(id);
            if (property == null) return null;
            return new ViewPropertyDTO { 
                Id = property.Id,
                Name = property.Name,
                Description=property.Description,
                CategoryName=property.Category.Name,
                Price=property.Price,
                City=property.City,
                Bathrooms=property.Bathrooms,
                Rooms=property.Rooms,
                PropertyTypeName= property.PropertyType.Name
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

                Name=oldProperty.Name,
                Description=oldProperty.Description,
                Price=oldProperty.Price,
                Rooms=oldProperty.Rooms,
                Bathrooms= oldProperty.Bathrooms,
                CategoryName= oldProperty.Category.Name

            };
        }
    }
}
