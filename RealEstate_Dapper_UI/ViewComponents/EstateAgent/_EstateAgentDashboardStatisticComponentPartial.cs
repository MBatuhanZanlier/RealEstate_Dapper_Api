using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory; 
        private readonly ILoginService _loginService;
        public _EstateAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            #region
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44307/api/EstateAgentStatistic/productsCountByEmployeeId?id="+id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCounts = jsonData;
            #endregion
            #region 
            var client10 = _httpClientFactory.CreateClient();
            var responseMessage10 = await client10.GetAsync("https://localhost:44307/api/EstateAgentStatistic/productsCountByStatusFalse?id="+id);
            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.producountByemployeeBystatusFalse = jsonData10;
            #endregion
            #region 
            var client9 = _httpClientFactory.CreateClient();
            var responseMessage9 = await client9.GetAsync("https://localhost:44307/api/EstateAgentStatistic/productsCountByStatusTrue?id="+id);
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.producountByemployeeBystatusTrue = jsonData9;
            #endregion  
         
            var client16 = _httpClientFactory.CreateClient();
            var responseMessage16 = await client16.GetAsync("https://localhost:44307/api/EstateAgentStatistic/AllProductCounts");
            var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.productCounts = jsonData16;
            return View();
        }
    }
} 
