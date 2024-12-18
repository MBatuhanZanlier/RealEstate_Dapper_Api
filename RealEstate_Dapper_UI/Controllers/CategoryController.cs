﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class CategoryController : Controller
    { 
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:44307/api/Categories");
            if (responsemessage.IsSuccessStatusCode) 
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync(); 
                var values=JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View(); 
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {  
            var client= _httpClientFactory.CreateClient();  
            var jsondata=JsonConvert.SerializeObject(createCategoryDto); 
            StringContent stringContent = new StringContent(jsondata,Encoding.UTF8,"Application/json");
            var responseMessage = await client.PostAsync("https://localhost:44307/api/Categories", stringContent); 
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");   
            }
            return View();
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.DeleteAsync($"https://localhost:44307/api/Categories/{id}"); 
            if(responsemessage.IsSuccessStatusCode)  
            {
                return RedirectToAction("Index");
            } 
            return View();
        }
        [HttpGet] 
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://localhost:44307/api/Categories/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client=_httpClientFactory.CreateClient(); 
            var Jsondata=JsonConvert.SerializeObject(updateCategoryDto); 
            StringContent stringContent = new StringContent(Jsondata,Encoding.UTF8, "Application/json"); 
            var responseMessage=await client.PutAsync("https://localhost:44307/api/Categories", stringContent); 
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
     }
}
