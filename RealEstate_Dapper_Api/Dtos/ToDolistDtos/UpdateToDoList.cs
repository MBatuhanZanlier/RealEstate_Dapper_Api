namespace RealEstate_Dapper_Api.Dtos.ToDolistDtos
{
    public class UpdateToDoList
    {
        public int ToDoListID { get; set; }
        public string Description { get; set; }
        public bool ToDoListStatus { get; set; }
    }
}
