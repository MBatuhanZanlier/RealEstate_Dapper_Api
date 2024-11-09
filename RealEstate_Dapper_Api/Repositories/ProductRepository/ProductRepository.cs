using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
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
            string query = "Select ProductID,ProductTitle,ProductCity,ProductDistrict,CategoryName,ProductCoverImage,Type,ProductAddress,DealOfTheDay,ProductPrice,SlugUrl From Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductProductWithCategoryDto>(query);
                return values.ToList();

            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "Select Top(5) ProductID,ProductTitle,ProductCity,ProductDistrict,ProductCategory,CategoryName,AdvertisementDate From Product Inner Join Category on Product.ProductCategory=Category.CategoryID Where Type='Kiralık' Order By ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();

            }
        }

        public async Task<List<ResultProductWithCategoryEmployee>> GetProductAdvertsListByEmployeeTrue(int id)
        {
            string query = "Select ProductID,ProductTitle,ProductCity,ProductDistrict,CategoryName,ProductCoverImage,Type,ProductAddress,DealOfTheDay,ProductStatus From Product inner join Category on Product.ProductCategory=Category.CategoryID Where EmployeID=@employeeıd and ProductStatus=1";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeıd", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryEmployee>(query, parameters);
                return values.ToList();

            }
        }
        public async Task<List<ResultProductWithCategoryEmployee>> GetProductAdvertsListByEmployeeFalse(int id)
        {
            string query = "Select ProductID,ProductTitle,ProductCity,ProductDistrict,CategoryName,ProductCoverImage,Type,ProductAddress,DealOfTheDay,ProductStatus From Product inner join Category on Product.ProductCategory=Category.CategoryID Where EmployeID=@employeeıd and ProductStatus=0";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeıd", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryEmployee>(query, parameters);
                return values.ToList();

            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product Set DealOfTheDay=0 where ProductID=@productıd";
            var parameters = new DynamicParameters();
            parameters.Add("@productıd", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product Set DealOfTheDay=1 where ProductID=@productıd";
            var parameters = new DynamicParameters();
            parameters.Add("@productıd", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            string query = "insert into Product (ProductTitle,ProductPrice,ProductCity,ProductDistrict,ProductCategory,ProductCoverImage,Type,ProductAddress,ProductDescription,AdvertisementDate,ProductStatus,EmployeID,DealOfTheDay) values (@producttitle,@productprice,@productcity,@productdistrict,@productcategory,@productcoverımage,@type,@address,@decription,@advertdate,@status,@employeeıd,@deloftheday)";
            var parameters = new DynamicParameters();
            parameters.Add("@producttitle", createProductDto.ProductTitle);
            parameters.Add("@productdistrict", createProductDto.ProductDistrict);
            parameters.Add("@productprice", createProductDto.ProductPrice);
            parameters.Add("@productcity", createProductDto.ProductCity);
            parameters.Add("@productcategory", createProductDto.ProductCategory);
            parameters.Add("@productcoverımage", createProductDto.ProductCoverImage);
            parameters.Add("@type", createProductDto.Type);
            parameters.Add("@address", createProductDto.ProductAddress);
            parameters.Add("@decription", createProductDto.ProductDescription);
            parameters.Add("@status", createProductDto.ProductStatus);
            parameters.Add("@advertdate", createProductDto.AdvertisementDate);
            parameters.Add("@employeeıd", createProductDto.EmployeID);
            parameters.Add("@deloftheday", createProductDto.DealOfTheDay);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<ResultGetProductDetailIdDto> GetProductDetailIdAsync(int id)
        {
            string query = "Select ProductID,ProductTitle,ProductCity,ProductDistrict,CategoryName,ProductCoverImage,Type,ProductAddress,DealOfTheDay,ProductStatus,AdvertisementDate,ProductDescription,SlugUrl From Product inner join Category on Product.ProductCategory=Category.CategoryID where ProductID=@productıd";
            var parameters = new DynamicParameters();
            parameters.Add("@productıd", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultGetProductDetailIdDto>(query, parameters);
                return values.FirstOrDefault();
            }
        }

        public async Task<GetProductDetailByIdDto> GetProductsDetailByIdAsync(int id)
        {
            string query = "Select * From ProductDetails Where ProductID=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductDetailByIdDto>(query, parameters);
                return values.FirstOrDefault();
            }
        }

        public async Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryıd, string city)
        {
            string query = "Select * From Product Where ProductTitle like '%" + searchKeyValue + "%'  And ProductCategory=@propertyCategoryıd And ProductCity=@city";
            var parameters = new DynamicParameters();
            //parameters.Add("@searchKeyValue", searchKeyValue);
            parameters.Add("@propertyCategoryıd", propertyCategoryıd);
            parameters.Add("@city", city);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithSearchListDto>(query, parameters);
                return values.ToList();
            }

        }

        public async Task<List<ResultProductProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategory()
        {
            string query = "Select ProductID,ProductTitle,ProductCity,ProductDistrict,CategoryName,ProductCoverImage,ProductPrice,Type,ProductAddress,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID where DealOfTheDay=1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductProductWithCategoryDto>(query);
                return values.ToList();

            }
        }

        public async Task<List<ResultLast3ProductWithCategoryDto>> GetLast3ProductAsync()
        {
            string query = "Select Top(3) ProductID,ProductTitle,ProductDescription,ProductCity,ProductCoverImage,ProductDistrict,ProductCategory,CategoryName,AdvertisementDate From Product Inner Join Category on Product.ProductCategory=Category.CategoryID  Order By ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast3ProductWithCategoryDto>(query);
                return values.ToList();

            }
        }
    }
}

