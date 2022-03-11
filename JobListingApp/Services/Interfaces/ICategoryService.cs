using JobListingApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<(bool, string, CategoryToReturnDto)> AddCategory(CategoryToAddDto model);
        Task<CategoryWithJobsDto> GetCategoryByIdAsync(string categoryId);
        Task<List<CategoryToReturnDto>> GetAllCategoriesAsync();
        Task<bool> DeleteCategory(string id);
        Task<CategoryToReturnDto> UpdateCategoryByIdAsync(string categoryId, UpdatedCategoryDto newCategory);
    }
}
