using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductimagesResitories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductimagesController : ControllerBase
    { 
        private readonly IProductimageRepository _productimageRepository;

        public ProductimagesController(IProductimageRepository productimageRepository)
        {
            _productimageRepository = productimageRepository;
        }

        [HttpGet] 
        public async Task<IActionResult> GetProductImageByıd(int id)
        {
            var values=await _productimageRepository.GetProductImageByProductId(id); 
            return Ok(values);
        }
    }
}
