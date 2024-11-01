using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
    public class BottomGridRepository : IBottomGridRepository
    { 
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public void CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteBottomGridAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "Select * From BottomGrid"; 
            using(var connection=_context.CreateConnection())  
            {  
                var values=await connection.QueryAsync<ResultBottomGridDto>(query); 
                return values.ToList();
            
            }
        }

        public Task<GetByIdBottomGridDto> GetByIdBottomGridAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto)
        {
            throw new NotImplementedException();
        }
    }
}
