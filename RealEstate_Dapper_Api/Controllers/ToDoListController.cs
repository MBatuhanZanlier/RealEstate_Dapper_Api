using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    { 
        private readonly IToDoListRepository _repository;

        public ToDoListController(IToDoListRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]    
        public async Task<IActionResult> GetListTodolist()
        {
            var values=await _repository.GetAllToDoListAsync(); 
            return Ok(values);
        }
    }
}
