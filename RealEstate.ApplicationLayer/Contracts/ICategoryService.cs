using RealEstate.ApplicationLayer.DTOs.CategoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.ApplicationLayer.Contracts
{
    public interface ICategoryService
    {
        //Create
        //Task<ViewCategoryDetailsDTO> AddCategoryAsync(AddCategoryDTO property);
        ////Update
        //Task<ViewCategoryDTO> UpdateCategoryAsync(int id, UpdateCategoryDTO property);
        ////Delete
        //Task<ViewCategoryDTO?> DeleteCategoryAsync(int id);
        //Read
        Task<ViewCategoryDTO?> GetCategoryByIdAsync(int id);
        Task<IEnumerable<ViewCategoryDTO>> GetAllCategoriesAsync();
    }
}
