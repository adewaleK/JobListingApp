using JobListingApp.Models;
using JobListingApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Data.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> AddCategory(Category model);
        Task<CategoryWithJobsDto> GetCategoryById(string CategoryId);

        Task<List<Category>> GetAllcategories();
        Task<bool> UpdateCategory(Category newCategory);
        Task<bool> DeleteCategory(Category category);
        Task<Category> GetCategory(string CategoryId);
        Task<bool> SaveChanges();
    }
}
