using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepositories.LastProductRepositories
{
    public interface ILastProductRepository
    {
        Task<List<ResultLast5ProductWithCategoryDto>> GetLast5productAsync(int id);
    }
}
