using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositoreis;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyAmenitiesController : ControllerBase
    {
        private readonly IPropertyAmenityReposiyory _propertyAmenityReposiyory;

        public PropertyAmenitiesController(IPropertyAmenityReposiyory propertyAmenityReposiyory)
        {
            _propertyAmenityReposiyory = propertyAmenityReposiyory;
        }

        [HttpGet] 
        public async Task<IActionResult> GetPropertyAmenityByStatusTrues(int id)
        {
            var values=await _propertyAmenityReposiyory.ResultPropertyAmenityByStatusTrues(id); 
            return Ok(values);
        }
    }
}
