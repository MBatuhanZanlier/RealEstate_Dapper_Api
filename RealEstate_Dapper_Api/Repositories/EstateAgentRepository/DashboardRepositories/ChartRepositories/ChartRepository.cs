using Dapper;
using RealEstate_Dapper_Api.Dtos.ChartDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepositories.ChartRepositories
{
    public class ChartRepository : IChartRepository
    { 
        private readonly Context _context;

        public ChartRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultChartDto>> Get5CityForChart()
        {
            string query = "Select ProductCity,COUNT(*) as 'CityCount' From Product Group By ProductCity order By CityCount Desc"; 
            using(var connection=_context.CreateConnection())  
            {  
              var values=await connection.QueryAsync<ResultChartDto>(query); 
                return values.ToList();
            }
        }
    }
}
