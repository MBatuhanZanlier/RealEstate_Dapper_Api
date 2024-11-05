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

        [HttpGet("ProductsDealOfTheDayStatusChangeToTrue/{id}")] 
        public async Task<IActionResult> ProductsDealOfTheDayStatusChangeToTrue(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToTrue(id); 
            return Ok("İlan Durumu Güncellendi");
        }
        [HttpGet("ProductsDealOfTheDayStatusChangeToFalse/{id}")]
        public async Task<IActionResult> ProductsDealOfTheDayStatusChangeToFalse(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
            return Ok("İlan Durumu Güncellendi");
        }
        [HttpGet("GetLast5Products")] 
        public async Task<IActionResult> GetLast5Products()
        {
            var values=await _productRepository.GetLast5ProductAsync();
            return Ok(values);
        }
        [HttpGet("ProductAdvertsListByEmployeeId")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeId(int id)
        {
            var values =await _productRepository.GetProductAdvertsListByEmployee(id);
            return Ok(values);
        }
    }
}
