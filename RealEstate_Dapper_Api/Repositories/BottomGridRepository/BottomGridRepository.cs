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

        public async void CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto)
        {
            string query = "insert into BottomGrid (Icon,Title,Description) values (@icon,@title,@description)";
            var parameters = new DynamicParameters();  
            parameters.Add("@icon",createBottomGridDto.Icon); 
            parameters.Add("@title",createBottomGridDto.Title); 
            parameters.Add("@description", createBottomGridDto.Description); 
            using(var connection=_context.CreateConnection())  
            {  
               await connection.ExecuteAsync(query,parameters);
            
            }
        }

        public async void DeleteBottomGridAsync(int id)
        {
            string query = "Delete From BottomGrid where BottomGridID=@bottomgridID"; 
            var parameters=new DynamicParameters();
            parameters.Add("@bottomgridID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
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

        public async Task<GetByIdBottomGridDto> GetByIdBottomGridAsync(int id)
        {
            string query = "Select * From BottomGrid where BottomGridID=@bottomgridID";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomgridID", id);
            using (var connection = _context.CreateConnection())
            {
               var values= await connection.QueryFirstOrDefaultAsync<GetByIdBottomGridDto>(query, parameters);
                return values;

            }
        }

        public async void UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto)
        {
            string query = "Update BottomGrid Set Icon=@icon,Title=@title,Description=@description where BottomGridID=@bottomgridID ";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", updateBottomGridDto.Icon);
            parameters.Add("@title", updateBottomGridDto.Title);
            parameters.Add("@description", updateBottomGridDto.Description);
            parameters.Add("@bottomgridID ", updateBottomGridDto.BottomGridID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }
    }
}
