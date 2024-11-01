using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();  
        void CreateServiceAsync(CreateServiceDto createServiceDto); 
        void UpdateServiceAsync(UpdateServiceDto updateServiceDto);
        void DeleteServiceAsync(int id); 
        Task<GetByIdServiceDto> GetByIdServiceAsync(int id);

    }
}
