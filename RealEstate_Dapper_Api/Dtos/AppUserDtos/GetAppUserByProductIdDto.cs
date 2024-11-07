namespace RealEstate_Dapper_Api.Dtos.AppUserDtos
{
    public class GetAppUserByProductIdDto
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string PhoneNumber { get; set; }

    }
}
