using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepositories.StatisticRepositories
{
    public class EstateStatisticRepository : IEstateStatisticRepository
    {
        private readonly Context _context;

        public EstateStatisticRepository(Context context)
        {
            _context = context;
        }

        public int AllProductCount()
        {
            string query = "Select Count(*) From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int productCountByEmployeeId(int id)
        {
            string query = "Select Count(*) From Product where EmployeID=@employeeıd";
            var parameter = new DynamicParameters(); 
            parameter.Add("@employeeıd", id);
            using (var connection = _context.CreateConnection())
            {

                var values = connection.QueryFirstOrDefault<int>(query,parameter);
                return values;
            }
        }

        public int productCountByStatusFalse(int id)
        {
            string query = "Select Count(*) From Product where EmployeID=@employeeıd and ProductStatus=0";
            var parameter = new DynamicParameters();
            parameter.Add("@employeeıd", id);
            using (var connection = _context.CreateConnection())
            {

                var values = connection.QueryFirstOrDefault<int>(query, parameter);
                return values;
            }
        }

        public int productCountByStatusTrue(int id)
        {
            string query = "Select Count(*) From Product where EmployeID=@employeeıd and ProductStatus=1";
            var parameter = new DynamicParameters();
            parameter.Add("@employeeıd", id);
            using (var connection = _context.CreateConnection())
            {

                var values = connection.QueryFirstOrDefault<int>(query, parameter);
                return values;
            }
        }
    }
}
