namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepositories.StatisticRepositories
{
    public interface IEstateStatisticRepository
    {

        int productCountByEmployeeId(int id);
        int productCountByStatusTrue(int id);
        int productCountByStatusFalse(int id);
        int AllProductCount();

    }
}
