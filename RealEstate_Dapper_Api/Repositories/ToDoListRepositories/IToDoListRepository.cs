using RealEstate_Dapper_Api.Dtos.ToDolistDtos;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetAllToDoListAsync();
        Task CreateToDoListAsync(CreateToDoListDto dto);
        Task UpdateToDoListAsync(UpdateToDoList updateToDoList);
        Task DeleteToDoListAsync(int id); 

    }
}
