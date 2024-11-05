using RealEstate_Dapper_Api.Dtos.ToDolistDtos;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetAllToDoListAsync(); 
        void CreateToDoListAsync(CreateToDoListDto dto); 
        void UpdateToDoListAsync(UpdateToDoList updateToDoList); 
        void DeleteToDoListAsync(int id); 

    }
}
