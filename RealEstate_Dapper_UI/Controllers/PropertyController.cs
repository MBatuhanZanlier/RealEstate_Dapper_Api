using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDetailsDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using System.Net.Http;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsseMessage = await client.GetAsync("https://localhost:44307/api/Products/ProductListWihtCategory");
            if (responsseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responsseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProdctDto>>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> PropertySingle(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsseMessage = await client.GetAsync("https://localhost:44307/api/Products/GetProductByProductıd?id=2");
            var jsondata = await responsseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultProdctDto>(jsondata);

            var client1 = _httpClientFactory.CreateClient();
            var responsseMessage1 = await client1.GetAsync("https://localhost:44307/api/ProductDetail/GetProductsDetailByIdAsync?id=2");
            var jsondata1 = await responsseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<ResultGetProductDetailDto>(jsondata1);

            ViewBag.title1 = values.ProductTitle;
            ViewBag.price = values.ProductPrice;
            ViewBag.city = values.ProductCity;
            ViewBag.district = values.ProductDistrict;
            ViewBag.addres = values.ProductAddress;
            ViewBag.type = values.Type;

          
            ViewBag.bathCount = values1.ProductDetailBathCount;
            ViewBag.bedcount = values1.ProductDetailBedroomCount; 
            ViewBag.size = values1.ProductDetailSize;

            DateTime date1=DateTime.Now;
            DateTime date2 = values.AdvertisementDate; 
            
            TimeSpan timespan=date1 - date2; 
            int month=timespan.Days;

            ViewBag.datediff = 30 / month;
      
            return View();


        }
    }
}
