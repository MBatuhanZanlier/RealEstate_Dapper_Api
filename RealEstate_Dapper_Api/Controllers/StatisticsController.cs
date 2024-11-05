using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _repository;

        public StatisticsController(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("ActiveCategoryCount")] 
        public IActionResult ActiveCategoryCount()  
        {   
              return Ok(_repository.ActiveCategoryCount());
        }
        [HttpGet("ActiveEmployeeCount")]
        public IActionResult ActiveEmployeeCount()
        {
            return Ok(_repository.ActiveEmployeCount    ());
        }
        [HttpGet("ApermentCount")] 
        public IActionResult ActivePersonCount()  
        {  
           return Ok(_repository.ApertmentCount());
        }
        [HttpGet("AvgProductPriceRent")]
        public IActionResult AvgProductPriceRent()
        {
            return Ok(_repository.AverageProductPriceByRent());
        }
        [HttpGet("AvgProductPriceSale")]
        public IActionResult AvgProductPriceSale()
        {
            return Ok(_repository.AverageProductPriceBySale());
        }
        [HttpGet("CategoryCounts")] 
        public IActionResult CategoryCounts()
        {
            return Ok(_repository.CategoryCount());
        }
        [HttpGet("CategoryNameByMaxProductCounts")] 
        public IActionResult CategoryNameByMaxProductCounts()
        {
            return Ok(_repository.CategoryNameByMaxProductCounts());
        }

        [HttpGet("CityNameByMaxProductCounts")]
        public IActionResult CityNameByMaxProductCounts()
        {
            return Ok(_repository.CityNameByMaxProductCount());
        }   
        [HttpGet("DifferentCityCounts")]
        public IActionResult DifferentCityCounts()
        {
            return Ok(_repository.DifferentCityCount());
        }  
        [HttpGet("EmployeeNameByMaxProductCounts")]
        public IActionResult EmployeeNameByMaxProductCounts()
        {
            return Ok(_repository.EmployeeNameByMaxProductCount());
        }   
        [HttpGet("LastProductPrices")]
        public IActionResult LastProductPrices()
        {
            return Ok(_repository.LastProductPrice());
        }   
        [HttpGet("NewestBuildingYears")]
        public IActionResult NewestBuildingYears()
        {
            return Ok(_repository.NewestBuildingYear());
        } 
        [HttpGet("OldestBuildingYears")]
        public IActionResult OldestBuildingYears()
        {
            return Ok(_repository.OldestBuildingYear());
        }   
        [HttpGet("PassiveCategoryCounts")]
        public IActionResult PassiveCategoryCounts()
        {
            return Ok(_repository.PassiveCategoryCount());
        } 
        [HttpGet("ProductCategoryCounts")]
        public IActionResult ProductCategoryCounts()
        {
            return Ok(_repository.ProductCategoryCount());
        }   
        [HttpGet("productCounts")]
        public IActionResult productCounts()
        {
            return Ok(_repository.productCount());
        } 
    }
}
