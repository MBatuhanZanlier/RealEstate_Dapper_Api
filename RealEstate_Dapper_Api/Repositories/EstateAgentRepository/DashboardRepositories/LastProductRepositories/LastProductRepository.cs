using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepositories.LastProductRepositories
{
    public class LastProductRepository : ILastProductRepository
    {
        private readonly Context _context;

        public LastProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5productAsync(int id)
        {
            string query = "Select Top(5) ProductID,ProductTitle,ProductCity,ProductDistrict,ProductCategory,CategoryName,AdvertisementDate From Product Inner Join Category on Product.ProductCategory=Category.CategoryID Where EmployeID=@emloyeıd Order By ProductID Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@emloyeıd", id);
            using (var connection = _context.CreateConnection())
            {  
               var values=await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query, parameters); 
                return values.ToList();
            }
        }
    }
}
