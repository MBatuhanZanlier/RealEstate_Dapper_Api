using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProducimagesDtos;

namespace RealEstate_Dapper_UI.ViewComponents.ProperySingle
{
    public class _PropertySliderComponentPartial:ViewComponent
    { 
        private readonly IHttpClientFactory _httpClientFactory;

        public _PropertySliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        { 
            var client=_httpClientFactory.CreateClient();
            var responsseMessage = await client.GetAsync("https://localhost:44307/api/Productimages?id=2");
            if (responsseMessage.IsSuccessStatusCode)  
            { 
               var jsondata=await responsseMessage.Content.ReadAsStringAsync();  
                var values=JsonConvert.DeserializeObject<List<GetProductImageByProductIdDto>>(jsondata);   
                return View(values);
            }
            return View();
        }
    }
}
