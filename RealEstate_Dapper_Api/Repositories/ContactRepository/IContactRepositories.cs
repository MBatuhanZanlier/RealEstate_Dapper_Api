using RealEstate_Dapper_Api.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository
{
    public interface IContactRepositories
    {
        Task<List<ResultContactDto>> GetAllContactAsync(); 
        Task<List<ResultLast4ContactDto>> GetLast4ContactAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task DeleteContactAsync(int id); 
        Task<GetByIdContactDto> GetByIdContactAsync(int id);
    }
}
