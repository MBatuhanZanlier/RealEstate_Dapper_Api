﻿namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class CreatePrdocutDto
    {
      
        public string ProductTitle { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCity { get; set; }
        public string ProductDistrict { get; set; }
        public string CategoryID{ get; set; }
        public string ProductCoverImage { get; set; }
        public string Type { get; set; }
        public string ProductAddress { get; set; }
    }
}
