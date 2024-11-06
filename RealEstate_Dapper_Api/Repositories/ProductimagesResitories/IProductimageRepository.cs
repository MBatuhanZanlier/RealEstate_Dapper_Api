using RealEstate_Dapper_Api.Dtos.ProductimagesDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductimagesResitories
{
    public interface IProductimageRepository
    {
        Task<List<GetProductImageByProductIdDto>> GetProductImageByProductId(int id);
    }
}
