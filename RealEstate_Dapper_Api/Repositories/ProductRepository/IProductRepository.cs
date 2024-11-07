using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        void ProductDealOfTheDayStatusChangeToTrue(int id);
        void ProductDealOfTheDayStatusChangeToFalse(int id);
        Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync();
        Task<List<ResultProductWithCategoryEmployee>> GetProductAdvertsListByEmployeeTrue(int id);
        Task<List<ResultProductWithCategoryEmployee>> GetProductAdvertsListByEmployeeFalse(int id); 
        Task CreateProduct(CreateProductDto createProductDto); 
        Task<ResultGetProductDetailIdDto> GetProductDetailIdAsync(int id); 
        Task<GetProductDetailByIdDto> GetProductsDetailByIdAsync(int id);
        Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryıd, string city);

        Task<List<ResultProductProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategory();
    } 
}
