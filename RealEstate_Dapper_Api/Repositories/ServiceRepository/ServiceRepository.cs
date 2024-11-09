using Dapper;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateServiceAsync(CreateServiceDto createServiceDto)
        {
            string query = "insert into Service (ServiceName,ServiceStatus) values (@servicename,@servicestatus)";
            var parematers = new DynamicParameters();
            parematers.Add("@servicename", createServiceDto.ServiceName);
            parematers.Add("@servicestatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parematers);

            }
        }
        public async Task DeleteServiceAsync(int id)
        {
            string query = "Delete From Service where ServiceID=@serviceıd"; 
            var parematers = new DynamicParameters();
            parematers.Add("@serviceıd", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parematers);

            }
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            string query = "Select * From Service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();

            }
        }

        public async Task<GetByIdServiceDto> GetByIdServiceAsync(int id)
        {
            string query = "Select * From Service Where ServiceID=@serviceıd"; 
            var parematers = new DynamicParameters();
            parematers.Add("@serviceıd", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdServiceDto>(query,parematers);
                return values;

            }
        }

        public async Task UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            string query = "Update Service Set ServiceName=@servicename,ServiceStatus=@servicestatus where ServiceID=@serviceıd"; 
            var parematers = new DynamicParameters();
            parematers.Add("@servicename", updateServiceDto.ServiceName); 
            parematers.Add("@servicestatus", updateServiceDto.ServiceStatus); 
            parematers.Add("@serviceıd", updateServiceDto.ServiceID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parematers);

            }
        }
    }
}
