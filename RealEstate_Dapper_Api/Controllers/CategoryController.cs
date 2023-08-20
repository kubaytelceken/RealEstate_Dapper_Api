using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDto;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var categoryList = await _categoryRepository.GetAllCategoryAsync();
            return Ok(categoryList);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var responseModel = _categoryRepository.CreateCategory(createCategoryDto);
            return Ok(responseModel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var responseModel = _categoryRepository.UpdateCategory(updateCategoryDto);
            return Ok(responseModel);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var responseModel = _categoryRepository.DeleteCategory(id);
            return Ok(responseModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            return Ok(category);
        }
    }
}
