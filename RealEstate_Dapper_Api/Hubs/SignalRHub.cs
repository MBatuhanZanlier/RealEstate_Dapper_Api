using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace RealEstate_Dapper_Api.Hubs
{
    public class SignalRHub:Hub
    { 
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        } 
        public async Task SendCategoryCount()
        {
            var client=_httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:44307/api/Statistics/CategoryCounts"); 
            var jsondata=await responsemessage.Content.ReadAsStringAsync(); 
            await Clients.All.SendAsync("ReceiveCategoryCount", jsondata); 

        }
    }
}
