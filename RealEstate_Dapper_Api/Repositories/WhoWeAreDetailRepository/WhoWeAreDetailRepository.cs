using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreDetaiRepository
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateWhoWeAreDetailAsync(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            string query = "insert into WhoWeAreDetail(Title,Subtitle,Description1,Description2) values (@title,@subTitle,@description1,@description2)";
            var paramerts = new DynamicParameters();
            paramerts.Add("@title", createWhoWeAreDetailDto.Title);
            paramerts.Add("@subTitle", createWhoWeAreDetailDto.Subtitle);
            paramerts.Add("@description1", createWhoWeAreDetailDto.Description1);
            paramerts.Add("@@description2", createWhoWeAreDetailDto.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramerts);
            }
        }

        public async Task DeleteWhoWeAreDetailAsync(int id)
        {
            string query = "Delete From WhoWeAreDetail Where  WhoWeAreDetailID=@whoWeAreDetailID";
            var paramerts = new DynamicParameters();
            paramerts.Add("@whoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramerts);

            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreAsync()
        {
            string query = "Select * From WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();

            }
        }

        public async Task<GetByIdWhoWeAreDetailDto> GeyByIdWhoAreAsync(int id)
        {
            string query = "Select * From WhoWeAreDetail where WhoWeAreDetailID=@whoWeAreDetailID";
            var paramerts = new DynamicParameters();
            paramerts.Add("@whoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto>(query, paramerts);
                return values;

            }
        }

        public async Task UpdateWhoWeAreDetailAsync(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            string query = "Update WhoWeAreDetail Set Title=@title,Subtitle=@subTitle,Description1=@description1,Description2=@description2 where WhoWeAreDetailID=@whoWeAreDetailID";
            var paramerts = new DynamicParameters();
            paramerts.Add("@whoWeAreDetailID", updateWhoWeAreDetailDto.WhoWeAreDetailID);
            paramerts.Add("@title", updateWhoWeAreDetailDto.Title);
            paramerts.Add("@subTitle", updateWhoWeAreDetailDto.Subtitle);
            paramerts.Add("@description1", updateWhoWeAreDetailDto.Description1);
            paramerts.Add("@@description2", updateWhoWeAreDetailDto.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramerts);
            }
        }
    }
}
