using JobListingApp.Data.Repositories.Interfaces;
using JobListingApp.Models;
using JobListingApp.Models.DTOs;
using JobListingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<(bool, string, CategoryToReturnDto)> AddCategory(CategoryToAddDto model)
        {
            var foundCategory = await _categoryRepository.GetCategoryById(model.CategoryName);
            if (foundCategory != null)
            {
                return (false, "Category already exists", null);
            }

            var categoryToadd = new Category();
            categoryToadd.CategoryName = model.CategoryName;
            var response = await _categoryRepository.AddCategory(categoryToadd);
            if (!response)
                return (false, "Not Found", null);
            var data = new CategoryToReturnDto()
            {
                CategoryName = categoryToadd.CategoryName
            };
            return (true, "Category Succesfully Added", data);
        }

        public async Task<bool> DeleteCategory(string id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category == null) return false;

            var deleteCategory = _categoryRepository.DeleteCategory(category);
            if (deleteCategory == null) return false;

            return true;
        }

        public async Task<List<CategoryToReturnDto>> GetAllCategoriesAsync()
        {
            var allCategories = await _categoryRepository.GetAllcategories();
            return allCategories.Select(c => new CategoryToReturnDto()
            {
                Id = c.Id,
                CategoryName = c.CategoryName
            }).ToList();

        }


        public async Task<CategoryWithJobsDto> GetCategoryByIdAsync(string categoryId)
        {
            var category = await _categoryRepository.GetCategoryById(categoryId);

            if (category == null) return null;

            return category;

        }

        public async Task<CategoryToReturnDto> UpdateCategoryByIdAsync(string categoryId, UpdatedCategoryDto newCategory)
        {
            var catToUpdate = await _categoryRepository.GetCategory(categoryId);

            catToUpdate.CategoryName = newCategory.CategoryName;
            var response = await _categoryRepository.UpdateCategory(catToUpdate);

            if (!response) return null;

            var updatedcategory = new CategoryToReturnDto{ Id = catToUpdate.Id, CategoryName= catToUpdate.CategoryName };

            return updatedcategory;
        }
    }
}
