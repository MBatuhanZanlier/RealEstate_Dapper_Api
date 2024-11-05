using Dapper;
using RealEstate_Dapper_Api.Dtos.ToDolistDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public class ToDoListRepository : IToDoListRepository
    { 
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public void CreateToDoListAsync(CreateToDoListDto dto)
        {
            throw new NotImplementedException();
        }

        public void DeleteToDoListAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoListAsync()
        {
            string query = "Select * From ToDoList"; 
            using (var connection=_context.CreateConnection())  
            {  
                var values=await connection.QueryAsync<ResultToDoListDto>(query);
                return values.ToList();
            }
        }

        public void UpdateToDoListAsync(UpdateToDoList updateToDoList)
        {
            throw new NotImplementedException();
        }
    }
}
