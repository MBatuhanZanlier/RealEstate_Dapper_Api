using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.SubFeatureDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultSubFeatureComponentPartial:ViewComponent
    {  
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSubFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        { 
            var client=_httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:44307/api/SubFeature");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata= await responsemessage.Content.ReadAsStringAsync(); 
                var values=JsonConvert.DeserializeObject<List<ResultSubFeatureDto>>(jsondata); 
                return View(values);
            }
            return View();
        }
    }
}
