using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _repository.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto request)
        {
            _repository.CreateCategory(request);
            return Ok("Successful");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _repository.DeleteCategory(id);
            return Ok("Successful");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto request)
        {
            _repository.UpdateCategory(request);
            return Ok("Successful");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await _repository.GetByIdCategoryAsync(id);
            return Ok(value);
        }
    }
}
