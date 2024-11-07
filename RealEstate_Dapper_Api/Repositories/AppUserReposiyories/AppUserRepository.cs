using Dapper;
using RealEstate_Dapper_Api.Dtos.AppUserDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Runtime.InteropServices;

namespace RealEstate_Dapper_Api.Repositories.AppUserReposiyories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }

        public async Task<GetAppUserByProductIdDto> GetAppUserByProductIdAsync(int id)
        {

            string query = "Select * From AppUser Where UserID=@appuserıd";
            var parameters = new DynamicParameters();
            parameters.Add("@appuserıd", id);
            using (var connection = _context.CreateConnection())
            {

                var values = await connection.QueryFirstOrDefaultAsync<GetAppUserByProductIdDto>(query, parameters);
                return values;
            }
        }
    }
}
