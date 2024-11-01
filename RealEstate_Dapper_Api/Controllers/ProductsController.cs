using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    { 
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet] 
        public async Task<IActionResult> ProductList()
        {
            var values= await _productRepository.GetAllProductAsync(); 
            return Ok(values);
        }
        [HttpGet("ProductListWihtCategory")] 
        public async Task<IActionResult> ProductListWihtCategory()
        {
            var values=await _productRepository.GetAllProductWithCategoryAsync(); 
            return Ok(values);
        }
    }
}
