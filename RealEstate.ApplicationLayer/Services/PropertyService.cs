using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RealEstate.ApplicationLayer.Contracts;
using RealEstate.ApplicationLayer.DTOs.PropertyDTO;
using RealEstate.DAL.Contracts;
using RealEstate.DAL.Entities;
using RealEstate.DAL.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RealEstate.ApplicationLayer.Services
{
    internal class PropertyService : IPropertyService
    {
        private readonly IUnitOfWork unitOfWork;
        private IPropertyRepository properties;
        private ICategoryRepository categories;
        private IPropertyImageRepository propertyImagesRepo;
        private readonly IImageStorageService imageStorageService;


        public PropertyService(IUnitOfWork unitOfWork, IImageStorageService imageStorageService) 
        {
            this.unitOfWork= unitOfWork;
            this.imageStorageService= imageStorageService;
            properties = unitOfWork.Properties;
            categories = unitOfWork.Categories;
            propertyImagesRepo = unitOfWork.PropertyImages;
        }
        //CREATE
        public async Task<ViewPropertyDetailsDTO> AddPropertyAsync(AddPropertyDTO property)
        {
            Property newProperty = new Property
            {
                Name = property.Name,
                CategoryId = property.CategoryId,
                Description = property.Description,
                Price = property.Price,
                CityId = property.CityId,
                Address = property.Address,
                Rooms = property.Rooms,
                Bathrooms = property.Bathrooms,
                PropertyTypeId = property.PropertyTypeId,
                AreaSize = property.AreaSize,
                Furnished = property.Furnished,
                IsAvailable = property.IsAvailable,
                ContactPhone = property.ContactPhone,
                ContactWhatsapp = property.ContactWhatsapp,
                CreatedAt = DateTime.Now
            };
            await properties.AddAsync(newProperty);
            await unitOfWork.SaveChangesAsync();
            //now it should have an ID
            List<PropertyImage> images = new List<PropertyImage>();
            foreach (IFormFile image in property.Images) 
            {

                string imageURL= await imageStorageService.SaveImageAsync(image, newProperty.Id);
                PropertyImage propertyImage = new PropertyImage
                {
                    ImageUrl = imageURL,
                    PropertyId = newProperty.Id,
                };
                images.Add(propertyImage);
            }
            //here i created a list of propertyImages and using the image storage service i saved the images and get their URLs
            //now i need to save them to the database, i already have the property with its ID, i dont need to update the property again as the images are linked to it via foreign key
            await propertyImagesRepo.AddImagesRangeAsync(images); // now the images have been added to the database context
            await unitOfWork.SaveChangesAsync(); // save changes to persist images


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
                CityId=newProperty.CityId,
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
                CreatedAt=newProperty.CreatedAt,
                Images=newProperty.Images
            };
            return addedProperty;
        }

        ///DELETE 
        public async Task<ViewPropertyDTO?> DeletePropertyAsync(int id)
        {
            Property? property = await properties.DeletePropertyAsync(id);
            if (property == null) return null;
            if (property.Images != null) 
            {
                foreach (var img in  property.Images)
                {
                    await imageStorageService.DeleteImageAsync(img.ImageUrl);
                } //here i deleted every image from storage
            }
            //now i gotta delete from database using propertyImageRepository OR EF will do it automatically because of cascade delete
            ViewPropertyDTO deletedProperty = new ViewPropertyDTO
            {
                Id = property.Id, // Don't forget the ID!
                Name = property.Name,
                Description = property.Description,

                // Mapped from Eager Loaded Navigation Properties
                CategoryName = property.Category.Name, // Category is loaded and available
                PropertyTypeName = property.PropertyType.Name, // PropertyType is loaded and available

                Price = property.Price,
                CityName = property.City.Name,
                Rooms = property.Rooms,
                Bathrooms = property.Bathrooms,
                AreaSize = property.AreaSize,
                Furnished = property.Furnished,
                IsAvailable = property.IsAvailable,
                ContactPhone = property.ContactPhone,
                ContactWhatsapp = property.ContactWhatsapp,

                // Assuming Image is a navigation property on Property
                Image = property.Images.OrderBy(img => img.Id).Select(img => img.ImageUrl).FirstOrDefault()

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
                    CityName = property.City.Name,
                    Rooms = property.Rooms,
                    Bathrooms = property.Bathrooms,
                    AreaSize = property.AreaSize,
                    Furnished = property.Furnished,
                    IsAvailable = property.IsAvailable,
                    ContactPhone = property.ContactPhone,
                    ContactWhatsapp = property.ContactWhatsapp,

                    // Assuming Images is a navigation property on Property
                    Image = property.Images.OrderBy(img => img.Id).Select(img => img.ImageUrl).FirstOrDefault()
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
                CityName = property.City.Name,
                Rooms = property.Rooms,
                Bathrooms = property.Bathrooms,
                AreaSize = property.AreaSize,
                Furnished = property.Furnished,
                IsAvailable = property.IsAvailable,
                ContactPhone = property.ContactPhone,
                ContactWhatsapp = property.ContactWhatsapp,

                // Assuming Images is a navigation property on Property
                Image = property.Images.OrderBy(img => img.Id).Select(img => img.ImageUrl).FirstOrDefault()
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
            oldProperty.CityId = propertyDTO.CityId;
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
                CityName = oldProperty.City.Name,
                Rooms = oldProperty.Rooms,
                Bathrooms = oldProperty.Bathrooms,
                AreaSize = oldProperty.AreaSize,
                Furnished = oldProperty.Furnished,
                IsAvailable = oldProperty.IsAvailable,
                ContactPhone = oldProperty.ContactPhone,
                ContactWhatsapp = oldProperty.ContactWhatsapp,

                // Assuming Images is a navigation property on Property
                Image = oldProperty.Images.OrderBy(img => img.Id).Select(img => img.ImageUrl).FirstOrDefault()
            };
        }
        //filtering
        public async Task<IEnumerable<ViewPropertyDTO>> GetPropertiesByFilterAsync(int? categoryId = null, int? propertyTypeId = null, decimal? maxPrice = null, decimal? minPrice = null, int? cityId = null, int? minBedrooms = null, int? maxBedrooms = null) 
        {
            IEnumerable<ViewPropertyDTO> filteredProperties = await properties.GetFilteredQuery(categoryId, propertyTypeId, maxPrice, minPrice, cityId, minBedrooms, maxBedrooms).Select(
                property=> new ViewPropertyDTO {
                    Id = property.Id, // Don't forget the ID!
                    Name = property.Name,
                    Description = property.Description,

                    // Mapped from Eager Loaded Navigation Properties
                    CategoryName = property.Category.Name, // Category is loaded and available
                    PropertyTypeName = property.PropertyType.Name, // PropertyType is loaded and available

                    Price = property.Price,
                    CityName = property.City.Name,
                    Rooms = property.Rooms,
                    Bathrooms = property.Bathrooms,
                    AreaSize = property.AreaSize,
                    Furnished = property.Furnished,
                    IsAvailable = property.IsAvailable,
                    ContactPhone = property.ContactPhone,
                    ContactWhatsapp = property.ContactWhatsapp,

                    // Assuming Images is a navigation property on Property
                    Image = property.Images.OrderBy(img => img.Id).Select(img => img.ImageUrl).FirstOrDefault()
                })
                .AsNoTracking().ToListAsync();
            return filteredProperties;
            
        }

    }
}
