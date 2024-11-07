using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultHomePageProductListComponentPartial:ViewComponent
    {  
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultHomePageProductListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        { 
            var client=_httpClientFactory.CreateClient();
            var responsseMessage = await client.GetAsync("https://localhost:44307/api/Products/GetProductByDealOfTheDayTrueWithCategory"); 
            if(responsseMessage.IsSuccessStatusCode)  
            {  
                var jsondata=await responsseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProdctDto>>(jsondata); 
                return View(values);
            }
            return View();
        }
    }
}
