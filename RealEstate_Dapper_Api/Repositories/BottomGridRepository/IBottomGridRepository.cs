using RealEstate_Dapper_Api.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync(); 
        void CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto); 
        void UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto); 
        void DeleteBottomGridAsync(int id); 
        Task <GetByIdBottomGridDto> GetByIdBottomGridAsync(int id);

    }
}
