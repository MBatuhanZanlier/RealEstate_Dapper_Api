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

        [HttpPost]
        public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue, int propertyCategoryıd, string city)
        {
            var client = _httpClientFactory.CreateClient();
            var responsseMessage = await client.GetAsync($"https://localhost:44307/api/Products/ResultProductWithSearchList?searchKeyValue={searchKeyValue}&propertyCategoryıd={propertyCategoryıd}&city={city}");
            if (responsseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responsseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpGet("property/{slug}/{id}")]
        public async Task<IActionResult> PropertySingle(string slug,int id)
        {
            ViewBag.i = id;
            var client = _httpClientFactory.CreateClient();
            var responsseMessage = await client.GetAsync("https://localhost:44307/api/Products/GetProductByProductıd?id=2");
            var jsondata = await responsseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultProdctDto>(jsondata);

            var client1 = _httpClientFactory.CreateClient();
            var responsseMessage1 = await client1.GetAsync("https://localhost:44307/api/ProductDetail/GetProductsDetailByIdAsync?id=2");
            var jsondata1 = await responsseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<ResultGetProductDetailDto>(jsondata1);

            ViewBag.title1 = values.ProductTitle;
            ViewBag.productıd = values.ProductID;

            ViewBag.price = values.ProductPrice;
            ViewBag.city = values.ProductCity;
            ViewBag.district = values.ProductDistrict;
            ViewBag.addres = values.ProductAddress;
            ViewBag.type = values.Type;
            ViewBag.description = values.ProductDescription;
            ViewBag.slugUrl = values.SlugUrl;

            ViewBag.size = values1.ProductDetailSize;
            ViewBag.roomcount = values1.ProductDetailRoomCount;
            ViewBag.bedcount = values1.ProductDetailBedroomCount;
            ViewBag.bathCount = values1.ProductDetailBathCount;
            ViewBag.garage = values1.ProductDetailGarage;
            ViewBag.bedcount = values1.ProductDetailBedroomCount;
            ViewBag.price = values1.ProductDetailPrice;
            ViewBag.buildyear = values1.ProductDetailBuildYear;
            ViewBag.date = values.AdvertisementDate;
            ViewBag.location = values1.ProductDetailLocation;

            DateTime date1 = DateTime.Now;
            DateTime date2 = values.AdvertisementDate;

            TimeSpan timespan = date1 - date2;
            int month = timespan.Days;

            ViewBag.datediff = 30 / month; 

            string slugFromTitle=CreateSlug(values.ProductTitle);
            ViewBag.slugUrl = slugFromTitle;

            return View();


        }

        private string CreateSlug(string title)
        {
            title = title.ToLowerInvariant(); // Küçük harfe çevir
            title = title.Replace(" ", "-"); // Boşlukları tire ile değiştir
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]", ""); // Geçersiz karakterleri kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", " ").Trim(); // Birden fazla boşluğu tek boşluğa indir ve kenar boşluklarını kaldır
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-"); // Boşlukları tire ile değiştir

            return title;
        }
    }
}
