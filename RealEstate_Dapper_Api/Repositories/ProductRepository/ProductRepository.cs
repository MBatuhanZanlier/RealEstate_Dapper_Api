using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();

            }
        }
        public async Task<List<ResultProductProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID,ProductTitle,ProductCity,ProductDistrict,CategoryName,ProductCoverImage,Type,ProductAddress,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductProductWithCategoryDto>(query);
                return values.ToList();

            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "Select Top(5) ProductID,ProductTitle,ProductCity,ProductDistrict,ProductCategory,CategoryName,AdvertisementDate From Product Inner Join Category on Product.ProductCategory=Category.CategoryID \r\nWhere Type='Kiralık' Order By ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();

            }
        }

        public async Task<List<ResultProductWithCategoryEmployee>> GetProductAdvertsListByEmployee(int id)
        {
            string query = "Select ProductID,ProductTitle,ProductCity,ProductDistrict,CategoryName,ProductCoverImage,Type,ProductAddress,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID where EmployeeID=@employeeıd";
            var parameters = new DynamicParameters(); 
            parameters.Add("@employeeıd", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryEmployee>(query,parameters);
                return values.ToList();

            }
        }

        public async void ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product Set DealOfTheDay=0 where ProductID=@productıd";
            var parameters = new DynamicParameters(); 
            parameters.Add("@productıd", id); 
            using(var connection = _context.CreateConnection())  
            {  
             await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product Set DealOfTheDay=1 where ProductID=@productıd";
            var parameters = new DynamicParameters();
            parameters.Add("@productıd", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
