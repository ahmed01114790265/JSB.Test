using JSB.Contracts.DTO;
using JSB.Contracts.InterfaceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSB.Presentation.Controller
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

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            if (categories.ModelList == null || categories.IsValid == false)
            {
                return NotFound("No categories found.");
            }
            return Ok(categories.ModelList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category.Model == null || category.IsValid == false)
            {
                return NotFound("Category not found.");
            }
            return Ok(category.Model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return BadRequest("Invalid category data.");
            }
           
            if (!ModelState.IsValid)
            {
                var errorMessage = ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToList();
                return BadRequest(new { Errors = errorMessage });

            }
            var result = await _categoryService.AddCategory(categoryDTO);
            if (!result.IsValid)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody]CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return BadRequest("Invalid category data.");
            }
            if (!ModelState.IsValid)
            {
                var errorMessage = ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToList();
                return BadRequest(new { Errors = errorMessage });
            }
            var result = await _categoryService.UpdateCategory(categoryDTO);
            if (!result.IsValid)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var result = await _categoryService.DeleteCategory(id);
            if (!result.IsValid)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);

        }
    }
}
