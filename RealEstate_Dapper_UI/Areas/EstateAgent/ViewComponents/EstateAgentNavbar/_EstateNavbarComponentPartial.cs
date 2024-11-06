using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.MessageDtos;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.ViewComponents.EstateAgentNavbar
{
    public class _EstateNavbarComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpclientFactory;
        private readonly ILoginService _loginservice;
        public _EstateNavbarComponentPartial(IHttpClientFactory httpclientFactory, ILoginService loginservice)
        {
            _httpclientFactory = httpclientFactory;
            _loginservice = loginservice;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginservice.GetUserId; 
            var client=_httpclientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44307/api/Message?id=" + id);
            if(responseMessage.IsSuccessStatusCode)  
            {  
               var jsondata=await responseMessage.Content.ReadAsStringAsync(); 
                var values=JsonConvert.DeserializeObject<List<ResultMessageInboxDto>>(jsondata); 
                return View(values);
            
            }
            return View();
        }
    }
}
