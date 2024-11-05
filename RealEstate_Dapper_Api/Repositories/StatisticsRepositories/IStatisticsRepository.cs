namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public interface IStatisticsRepository
    {
        int CategoryCount();
        int ActiveCategoryCount(); 
        int PassiveCategoryCount(); 
        int productCount();  
        int ProductCategoryCount(); 
        int ApertmentCount();
        string EmployeeNameByMaxProductCount();
        decimal AverageProductPriceByRent(); 
        decimal AverageProductPriceBySale(); 
        string CityNameByMaxProductCount(); 
        int DifferentCityCount();
        decimal LastProductPrice();
        string NewestBuildingYear(); 
        string OldestBuildingYear();
        string CategoryNameByMaxProductCounts();
        int AvergageRoomCount();
        int ActiveEmployeCount();

    }
}
