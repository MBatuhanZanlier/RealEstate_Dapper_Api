using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public interface IPopularLocation
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationsAsync();
    }
}
