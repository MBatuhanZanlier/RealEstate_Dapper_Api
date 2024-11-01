using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
