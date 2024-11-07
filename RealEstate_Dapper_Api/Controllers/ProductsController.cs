using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
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
            var values =await _productRepository.GetProductAdvertsListByEmployeeTrue(id);
            return Ok(values);
        }
        [HttpGet("ProductAdvertsListByEmployeeIdFalse")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeIdFalse(int id)
        {
            var values = await _productRepository.GetProductAdvertsListByEmployeeFalse(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productRepository.CreateProduct(createProductDto);
            return Ok("İşlem başarıyla Eklendi");
        }
        [HttpGet("GetProductByProductıd")] 
        public async Task<IActionResult> GetProductByProductıd(int id)
        {
            var values=await _productRepository.GetProductDetailIdAsync(id);
            return Ok(values);
        }
        [HttpGet("ResultProductWithSearchList")] 
        public async Task<IActionResult> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryıd, string city)
        {
            var values=await _productRepository.ResultProductWithSearchList(searchKeyValue,propertyCategoryıd,city); 
            return Ok(values);
        }
        [HttpGet("GetProductByDealOfTheDayTrueWithCategory")] 
        public async Task<IActionResult> GetProductByDealOfTheDayTrueWithCategory()
        {
            var values = await _productRepository.GetProductByDealOfTheDayTrueWithCategory(); 
            return Ok(values);

        }
    }
}
