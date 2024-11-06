namespace RealEstate_Dapper_Api.Dtos.ProductimagesDtos
{
    public class GetProductImageByProductIdDto
    { 
        public int ProductImageId { get; set; } 
        public int ProductID { get; set; } 
        public string ImageUrl { get; set;}
    }
}
