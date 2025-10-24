using Microsoft.EntityFrameworkCore;
using RealEstate.ApplicationLayer.Contracts;
using RealEstate.ApplicationLayer.DTOs.CategoryDTO;
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
    internal class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private ICategoryRepository categories;
        public CategoryService(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
            categories= unitOfWork.Categories;
        }
        public async Task<IEnumerable<ViewCategoryDTO>> GetAllCategoriesAsync()
        {
            return await categories.GetAllQueryable().Select(
                category => new ViewCategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                }).AsNoTracking().ToListAsync();
                
        }

        public async Task<ViewCategoryDTO?> GetCategoryByIdAsync(int id)
        {
            Category? category = await categories.GetByIdAsync(id);
            if (category == null) return null;
            return new ViewCategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }
    }
}
