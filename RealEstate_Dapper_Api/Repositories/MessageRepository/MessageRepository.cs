using Dapper;
using RealEstate_Dapper_Api.Dtos.MessageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.MessageRepository
{
    public class MessageRepository : IMessageRepository
    { 
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultInboxMessageDto>> GetLastInboxMessageList(int id)
        {
            string query = "Select Top(3) MessageId,Name,Subject,Detail,SendDate,IsRead,ImageUrl From Message Inner Join AppUser on Message.Sender=AppUser.UserID where Receiver=@reciverıd Order By MessageID DESC";
            var paremeters = new DynamicParameters();
            paremeters.Add("@reciverıd", id); 
            using(var connection=_context.CreateConnection())  
            {  
            var values=await connection.QueryAsync<ResultInboxMessageDto>(query,paremeters);    
            return values.ToList();
                
            }
     
        }
    }
}
