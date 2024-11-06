namespace RealEstate_Dapper_UI.Dtos.ProductDetailsDtos
{
    public class ResultGetProductDetailDto
    {
        public int ProductDetailID { get; set; }
        public int ProductDetailSize { get; set; }
        public int ProductDetailBedroomCount { get; set; }
        public int ProductDetailBathCount { get; set; }
        public int ProductDetailRoomCount { get; set; }
        public int ProductDetailGarage { get; set; }
        public string ProductDetailBuildYear { get; set; }
        public decimal ProductDetailPrice { get; set; }
        public string ProductDetailLocation { get; set; }
        public string ProductDetailVideoUrl { get; set; }
        public int ProductID { get; set; }
        //public DateTime AdvertisementDate { get; set; }
    }
}
