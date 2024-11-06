using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.MessageRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    { 
        private readonly IMessageRepository _messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        [HttpGet] 
        public async Task<IActionResult> GetLastInboxMessageLists(int id)
        {
            var values=await _messageRepository.GetLastInboxMessageList(id); 
            return Ok(values);
        }
    }
}
