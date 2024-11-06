using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    { 
        private readonly IProductRepository _productRepository;

        public ProductDetailController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet("GetProductsDetailByIdAsync")] 
        public async Task<IActionResult> GetProductsDetailByIdAsync(int id)
        {
            var values = await _productRepository.GetProductsDetailByIdAsync(id); 
            return Ok(values);
        }
    }
}
