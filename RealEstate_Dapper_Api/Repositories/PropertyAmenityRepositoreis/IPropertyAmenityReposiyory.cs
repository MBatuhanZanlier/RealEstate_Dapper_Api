using RealEstate_Dapper_Api.Dtos.PropertyAmenity;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositoreis
{
    public interface IPropertyAmenityReposiyory
    {
       Task<List<ResultPropertyAmenityByStatusTrue>> ResultPropertyAmenityByStatusTrues(int id  );
    }
}
