using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepositories.StatisticRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentStatisticController : ControllerBase
    {
        private readonly IEstateStatisticRepository _statisticRepository;

        public EstateAgentStatisticController(IEstateStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        [HttpGet("productsCountByEmployeeId")]
        public IActionResult productsCountByEmployeeId(int id)
        {
            return Ok(_statisticRepository.productCountByEmployeeId(id));
        }
        [HttpGet("productsCountByStatusTrue")]
        public IActionResult productsCountByStatusTrue(int id)
        {
            return Ok(_statisticRepository.productCountByStatusTrue(id));
        }
        [HttpGet("productsCountByStatusFalse")]
        public IActionResult ActivePersonCount(int id)
        {
            return Ok(_statisticRepository.productCountByStatusFalse(id));
        }
        [HttpGet("AllProductCounts")]
        public IActionResult AllProductCounts()
        {
            return Ok(_statisticRepository.AllProductCount());
        }
    }
}
