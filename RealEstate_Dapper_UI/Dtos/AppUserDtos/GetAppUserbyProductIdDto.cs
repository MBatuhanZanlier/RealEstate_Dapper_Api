namespace RealEstate_Dapper_UI.Dtos.AppUserDtos
{
    public class GetAppUserbyProductIdDto
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; } 
        public string PhoneNumber { get; set; }
    }
}
