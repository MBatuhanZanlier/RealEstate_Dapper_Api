﻿namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int ProductID { get; set; }
        public string ProductTitle { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCity { get; set; }
        public string ProductDistrict { get; set; }
        public int ProductCategory { get; set; }
        public bool DealOfTheDay { get; set; }
    }
}
