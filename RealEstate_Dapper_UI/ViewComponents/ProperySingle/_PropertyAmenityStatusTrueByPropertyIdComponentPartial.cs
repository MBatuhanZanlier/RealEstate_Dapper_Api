using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PropertyAmenity;

namespace RealEstate_Dapper_UI.ViewComponents.ProperySingle
{
    public class _PropertyAmenityStatusTrueByPropertyIdComponentPartial:ViewComponent
    { 
        private readonly IHttpClientFactory _httpClientFactory;

        public _PropertyAmenityStatusTrueByPropertyIdComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:44307/api/PropertyAmenities?id=2");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync(); 
                var values=JsonConvert.DeserializeObject<List<ResultPropertyAmenityByStatusTrue>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
