using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositoreies
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async void CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            string query = "insert into Employee(EmployeeName,EmployeeTitle,EmployeeMail,EmployeePhoneNumber,EmployeeImageUrl,EmployeeStatus) values (@employeename,@employeetitle,@employeemail,@employeephonenumber,@employeımageurl,@employestatus)";
            var paremerts = new DynamicParameters();
            paremerts.Add("@employeename", createEmployeeDto.EmployeeName);
            paremerts.Add("@employeetitle", createEmployeeDto.EmployeeTitle);
            paremerts.Add("@employeemail", createEmployeeDto.EmployeeMail);
            paremerts.Add("@employeephonenumber", createEmployeeDto.EmployeePhoneNumber);
            paremerts.Add("@employeımageurl", createEmployeeDto.EmployeeTitle);
            paremerts.Add("@employestatus", true);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.ExecuteAsync(query, paremerts);

            }
        }

        public async void DeleteEmployeeAsync(int id)
        {
            string query = "Delete From Employee where EmployeeID=@employeeıd";
            var paramerts = new DynamicParameters();
            paramerts.Add("@employeeıd", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramerts);

            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "Select * From Employee";
            using (var connection = _context.CreateConnection())
            {

                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdEmployeeDto> GetbyIdEmployeeAsync(int id)
        {
            string query = "Select * From Employee where EmployeeID=@employeeıd"; 
            var parameters = new DynamicParameters();
            parameters.Add("@employeeıd", id);
            using (var connection = _context.CreateConnection())
            {

                var values = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query,parameters);
                return values;
            }

        }

        public async void UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = "Update Employee Set EmployeeName=@employeename,EmployeeTitle=@employeetitle,EmployeeMail=@employeemail,EmployeePhoneNumber =@employeephonenumber,EmployeeImageUrl=@employeımageurl,EmployeeStatus=@employestatus where EmployeeID=@employeeıd";
            var paremerts = new DynamicParameters();
            paremerts.Add("@employeeıd", updateEmployeeDto.EmployeeID);
            paremerts.Add("@employeename", updateEmployeeDto.EmployeeName);
            paremerts.Add("@employeetitle", updateEmployeeDto.EmployeeTitle);
            paremerts.Add("@employeemail", updateEmployeeDto.EmployeeMail);
            paremerts.Add("@employeephonenumber", updateEmployeeDto.EmployeePhoneNumber);
            paremerts.Add("@employeımageurl", updateEmployeeDto.EmployeeImageUrl);
            paremerts.Add("@employestatus", true);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.ExecuteAsync(query, paremerts);

            }

        }
    }
}
