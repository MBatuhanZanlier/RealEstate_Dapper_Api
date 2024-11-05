using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public interface IPopularLocation
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationsAsync(); 
        void CreatePopularLocationAsync(CreatePopularLocationDto popularLocation); 
        void UpdatePopularLocationAsync(UpdatePopularLocationDto popularLocation);
        void DeletePopularLocationAsync(int id);
        Task<GetByIdPopularLocationDto> GetByIdPopularLocationAsync(int id);
    }
}
