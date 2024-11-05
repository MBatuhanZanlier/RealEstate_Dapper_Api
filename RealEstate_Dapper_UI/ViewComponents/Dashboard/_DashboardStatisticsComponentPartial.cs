using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatisticsComponentPartial:ViewComponent
    {  
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public  async Task<IViewComponentResult> InvokeAsync()
        {
            var client8 = _httpClientFactory.CreateClient();
            var responseMessage8 = await client8.GetAsync("https://localhost:44307/api/Statistics/CityNameByMaxProductCounts");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.cityNameByMaxProductCounts = jsonData8;
            #region 
            var client10 = _httpClientFactory.CreateClient();
            var responseMessage10 = await client10.GetAsync("https://localhost:44307/api/Statistics/EmployeeNameByMaxProductCounts");
            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCounts = jsonData10;
            #endregion
            #region 
            var client9 = _httpClientFactory.CreateClient();
            var responseMessage9 = await client9.GetAsync("https://localhost:44307/api/Statistics/DifferentCityCounts");
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCounts = jsonData9;
            #endregion  
            #region 
            var client16 = _httpClientFactory.CreateClient();
            var responseMessage16 = await client16.GetAsync("https://localhost:44307/api/Statistics/productCounts");
            var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.productCounts = jsonData16;
            #endregion  
            return View();  
        }
    }
}
