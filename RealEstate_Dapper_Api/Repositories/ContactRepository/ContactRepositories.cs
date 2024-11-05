using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository
{
    public class ContactRepositories : IContactRepositories
    { 
        private readonly Context _context;

        public ContactRepositories(Context context)
        {
            _context = context;
        }

        public void CreateContactAsync(CreateContactDto createContactDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteContactAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultContactDto>> GetAllContactAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdContactDto> GetByIdContactAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultLast4ContactDto>> GetLast4ContactAsync()
        {
            string query = "Select Top(4) *From Contact Order By SendDate Desc"; 
            using(var connection=_context.CreateConnection())  
            {  
               var values=await connection.QueryAsync<ResultLast4ContactDto>(query); 
                return values.ToList();
              
            }
        }
    }
}
