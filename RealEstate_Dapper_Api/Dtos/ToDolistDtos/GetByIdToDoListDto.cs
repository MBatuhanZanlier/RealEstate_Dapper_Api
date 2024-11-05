namespace RealEstate_Dapper_Api.Dtos.ToDolistDtos
{
    public class GetByIdToDoListDto
    {
        public int ToDoListID { get; set; }
        public string Description { get; set; }
        public bool ToDoListStatus { get; set; }
    }
}
