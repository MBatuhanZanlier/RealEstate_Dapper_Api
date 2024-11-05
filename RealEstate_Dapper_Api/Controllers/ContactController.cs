using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ContactRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepositories _contactrepo;

        public ContactController(IContactRepositories contactrepo)
        {
            _contactrepo = contactrepo;
        }
        [HttpGet("GetLast4ContactList")]
        public async Task<IActionResult> GetLast4ContactList()
        {
            var values = await _contactrepo.GetLast4ContactAsync(); 
            return Ok(values);
        }
    }
}
