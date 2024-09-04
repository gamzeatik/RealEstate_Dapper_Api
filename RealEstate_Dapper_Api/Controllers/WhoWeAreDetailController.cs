using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDtos;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {
        private readonly IWhoWeAreRepository _repository;

        public WhoWeAreDetailController(IWhoWeAreRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> WhoWeAreList()
        {
            var values = await _repository.GetAllWhoWeAreDetailAsync();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateWhoWeAre(CreateWhoWeAreDetailDto request)
        {
            _repository.CreateWhoWeAreDetail(request);
            return Ok("Successful");
        }
        [HttpDelete]
        public IActionResult DeleteWhoWeAre(int id)
        {
            _repository.DeleteWhoWeAreDetail(id);
            return Ok("Successful");
        }
        [HttpPut]
        public IActionResult UpdateWhoWeAre(UpdateWhoWeAreDetailDto request)
        {
            _repository.UpdateWhoWeAreDetail(request);
            return Ok("Successful");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAre(int id)
        {
            var value = await _repository.GetByIdWhoWeAreDetail(id);
            return Ok(value);
        }
    }
}
