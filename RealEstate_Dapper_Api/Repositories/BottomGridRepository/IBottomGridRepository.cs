using RealEstate_Dapper_Api.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync(); 
        Task CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto);
        Task UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto);
        Task DeleteBottomGridAsync(int id); 
        Task <GetByIdBottomGridDto> GetByIdBottomGridAsync(int id);

    }
}
