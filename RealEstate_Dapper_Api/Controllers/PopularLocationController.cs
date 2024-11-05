using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationController : ControllerBase
    {
        private readonly IPopularLocation _popularLocation;

        public PopularLocationController(IPopularLocation popularLocation)
        {
            _popularLocation = popularLocation;
        }
        [HttpGet]
        public async Task<IActionResult> ListPopularLocation()
        {
            var values=await _popularLocation.GetAllPopularLocationsAsync(); 
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddPopularLocation(CreatePopularLocationDto PopularLocation)
        {
            _popularLocation.CreatePopularLocationAsync(PopularLocation);
            return Ok("Başarıyla Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            _popularLocation.DeletePopularLocationAsync(id);
            return Ok("Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto PopularLocation)
        {
            _popularLocation.UpdatePopularLocationAsync(PopularLocation);
            return Ok("Başarıyla Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyIdPopularLocation(int id)
        {
            var value = await _popularLocation.GetByIdPopularLocationAsync(id);
            return Ok(value);
        }
    }
}
