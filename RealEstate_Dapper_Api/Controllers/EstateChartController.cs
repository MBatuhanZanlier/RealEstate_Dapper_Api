using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepositories.ChartRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateChartController : ControllerBase
    { 
        private readonly IChartRepository _chartRepository;

        public EstateChartController(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }

        [HttpGet] 
        public async Task<IActionResult> Get5cityForChart()
        {
            return Ok(await _chartRepository.Get5CityForChart());
        }
    }
}
