using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardToDoListComponentPartial:ViewComponent
    {  
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardToDoListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        { 
            var client=_httpClientFactory.CreateClient();
            var responssemessage = await client.GetAsync("https://localhost:44307/api/ToDoList");
            if(responssemessage.IsSuccessStatusCode)  
            {
                var jsondata = await responssemessage.Content.ReadAsStringAsync(); 
                var values=JsonConvert.DeserializeObject<List<ResultToDoListDto>>(jsondata); 
                return View(values);
            
            } 
            return View();

        }
    }
}
