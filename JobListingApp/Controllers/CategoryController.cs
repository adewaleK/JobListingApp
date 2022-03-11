using JobListingApp.Models.DTOs;
using JobListingApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("add-category")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryToAddDto model)
        {

            if (!ModelState.IsValid) return BadRequest("Request is invalid,input valid request");
            var result = await _categoryService.AddCategory(model);

            if (!result.Item1) return BadRequest();
            return Ok("Category successfully added");

        }


        [HttpDelete("delete-category")]
        public async Task<IActionResult> DeleteCategory([FromQuery] string CategoryId)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Request");

            var isDeleted = await _categoryService.DeleteCategory(CategoryId);
            if (!isDeleted)
            {
                return BadRequest("Category not Deleted");
            }
            return Ok("Category Successfully Deleted");
        }

        [HttpGet("get-category-by-Id")]
        public async Task<IActionResult> GetCategoryById([FromQuery] string categoryId)
        {

            if (string.IsNullOrWhiteSpace(categoryId))
                return BadRequest("Invalid request parametre");
            var category = await _categoryService.GetCategoryByIdAsync(categoryId);
            if (category == null)
            {
                return BadRequest("Category does not exist");
            }
            return Ok(category);
        }


        [HttpGet("get-all-categories")]

        public async Task<IActionResult> GeAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            if (categories == null) return NotFound("No categories found");
            return Ok(categories);
        }


        [HttpPut("update-category/{id}")]
        public async Task<IActionResult> UpdateCategory(string id, UpdatedCategoryDto model)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Invalid request parameter");

            var category = await _categoryService.UpdateCategoryByIdAsync(id, model);
            if (category == null)
            {
                return BadRequest("Category could not be updated");
            }
            return Ok(category);
        }


    }
}
