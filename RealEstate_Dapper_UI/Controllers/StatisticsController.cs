using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            #region  
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44307/api/Statistics/ActiveCategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.activeCategoryCount = jsonData;
            #endregion 
            #region  
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("https://localhost:44307/api/Statistics/ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.activeEmployeeCount = jsonData2;
            #endregion 
            #region  
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44307/api/Statistics/ApermentCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.apermentCount = jsonData3;
            #endregion
            #region 
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44307/api/Statistics/AvgProductPriceRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.avgProductPriceRent = jsonData4;
            #endregion
            #region 
            var client5 = _httpClientFactory.CreateClient();
            var responseMessage5 = await client5.GetAsync("https://localhost:44307/api/Statistics/AvgProductPriceSale");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.avgProductPriceSale = jsonData5;
            #endregion 
            #region 
            var client6 = _httpClientFactory.CreateClient();
            var responseMessage6 = await client6.GetAsync("https://localhost:44307/api/Statistics/CategoryCounts");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.categorycount = jsonData6;
            #endregion 
            #region 
            var client7 = _httpClientFactory.CreateClient();
            var responseMessage7 = await client7.GetAsync("https://localhost:44307/api/Statistics/CategoryNameByMaxProductCounts");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.nameByMaxProductCounts = jsonData7;
            #endregion
            #region 
            var client8 = _httpClientFactory.CreateClient();
            var responseMessage8 = await client8.GetAsync("https://localhost:44307/api/Statistics/CityNameByMaxProductCounts");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.cityNameByMaxProductCounts = jsonData8;
            #endregion
            #region 
            var client9 = _httpClientFactory.CreateClient();
            var responseMessage9 = await client9.GetAsync("https://localhost:44307/api/Statistics/DifferentCityCounts");
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCounts = jsonData9;
            #endregion  
            #region 
            var client10 = _httpClientFactory.CreateClient();
            var responseMessage10 = await client.GetAsync("https://localhost:44307/api/Statistics/EmployeeNameByMaxProductCounts");
            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCounts = jsonData10;
            #endregion
            #region 
            var client11 = _httpClientFactory.CreateClient();
            var responseMessage11 = await client.GetAsync("https://localhost:44307/api/Statistics/LastProductPrices");
            var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.LastProductPrices = jsonData11;
            #endregion   
            #region 
            var client12 = _httpClientFactory.CreateClient();
            var responseMessage12 = await client.GetAsync("https://localhost:44307/api/Statistics/NewestBuildingYears");
            var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
            ViewBag.newestBuildingYears = jsonData12;
            #endregion
            #region 
            var client13 = _httpClientFactory.CreateClient();
            var responseMessage13 = await client.GetAsync("https://localhost:44307/api/Statistics/OldestBuildingYears");
            var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
            int nowyear = DateTime.Now.Year;
            var values=JsonConvert.DeserializeObject<int> (jsonData13); 
            ViewBag.oldestBuildingYears = nowyear - values;
            #endregion
            #region 
            var client14 = _httpClientFactory.CreateClient();
            var responseMessage14 = await client.GetAsync("https://localhost:44307/api/Statistics/PassiveCategoryCounts");
            var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
            ViewBag.passiveCategoryCounts = jsonData14;
            #endregion 
            #region 
            var client16 = _httpClientFactory.CreateClient();
            var responseMessage16 = await client.GetAsync("https://localhost:44307/api/Statistics/productCounts");
            var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.productCounts = jsonData16;
            #endregion  

            return View();
        }
    }
}
  