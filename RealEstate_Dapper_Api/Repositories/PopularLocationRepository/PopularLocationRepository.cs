using Dapper;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public class PopularLocationRepository : IPopularLocation
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async void CreatePopularLocationAsync(CreatePopularLocationDto popularLocation)
        {
            string query = "insert into PopularLocation (CityName,ImageUrl) values (@cityname,@ımageurl)";
            var parematers = new DynamicParameters();
            parematers.Add("@cityname", popularLocation.CityName);
            parematers.Add("@ımageurl", popularLocation.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parematers);
            }
        }
        public async void DeletePopularLocationAsync(int id)
        {
            string query = "Delete From PopularLocation Where PopularLocationID=@popularlocationID"; 
            var parematers = new DynamicParameters();
            parematers.Add("@@popularlocationID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parematers);
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationsAsync()
        {
            string query = "Select * From PopularLocation ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();

            }
        }

        public async Task<GetByIdPopularLocationDto> GetByIdPopularLocationAsync(int id)
        {
            string query = "Select * From PopularLocation Where PopularLocationID=@popularlocationID ";
            var parematers = new DynamicParameters();
            parematers.Add("@@popularlocationID", id);
            using (var connection = _context.CreateConnection())
            {
               var values= await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query, parematers);
                return values;
            }
        }

        public async void UpdatePopularLocationAsync(UpdatePopularLocationDto popularLocation)
        {
            string query = "Update PopularLocation Set CityName=@cityname,ImageUrl=@ımageurl Where PopularLocationID=@popularlocationID";
            var parematers = new DynamicParameters();
            parematers.Add("@cityname", popularLocation.CityName);
            parematers.Add("@ımageurl", popularLocation.ImageUrl); 
            parematers.Add("@popularlocationID", popularLocation.PopularLocationID); 
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parematers);
            }
        }
    }
}
