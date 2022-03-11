using JobListingApp.Data.Repositories.Interfaces;
using JobListingApp.Models;
using JobListingApp.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Data.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCategory(Category model)
        {
            await _context.Categories.AddAsync(model);

            return await SaveChanges();
        }

        public Task<bool> DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            return  SaveChanges();
        }

        public async Task<Category> GetCategory(string CategoryId)
        {
            return await _context.Categories.Where(c => c.Id == CategoryId).FirstOrDefaultAsync();

        }

        public async Task<CategoryWithJobsDto> GetCategoryById(string CategoryId)
        {

            var response = await _context.Categories
                .Where(c => c.Id == CategoryId)
                .Select(cat => new CategoryWithJobsDto()
                {
                    Id = cat.Id,
                    CategoryName = cat.CategoryName,
                    CategoryJobs = cat.Jobs.Select(j => new JobsInCategory()
                    {
                        CompanyName = j.CompanyName,
                        JobTitle = j.JobTitle,
                        Location = j.Location,
                        MinimumSalary = j.MinimumSalary,
                        MaximumSalary = j.MaximumSalary,
                    }

                  ).ToList()


                }).FirstOrDefaultAsync();

            return response;

        }
                

        public async Task<bool> SaveChanges()
        {
            return await  _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCategory(Category newCategory)
        {
            _context.Categories.Update(newCategory);
            return await SaveChanges();
        }

        public async Task<List<Category>> GetAllcategories()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
