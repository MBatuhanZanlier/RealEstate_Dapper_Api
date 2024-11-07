using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.AppUserReposiyories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    { 
        private readonly IAppUserRepository _userRepository;

        public AppUsersController(IAppUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]    
        public async Task<IActionResult> GetAppuserByProductId(int id)
        {
            var values=await _userRepository.GetAppUserByProductIdAsync(id); 
            return Ok(values);
        }
    }
}
