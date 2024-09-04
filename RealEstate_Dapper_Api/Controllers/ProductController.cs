using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _repository.GetAllProductsAsync();
            return Ok(values);
        }

        [HttpGet("GetAllProductsWithCategoryAsync")]
        public async Task<IActionResult> GetAllProductsWithCategoryAsync()
        {
            var values = await _repository.GetAllProductsWithCategoryAsync();
            return Ok(values);
        }
    }
}
