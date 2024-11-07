using Dapper;
using RealEstate_Dapper_Api.Dtos.PropertyAmenity;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositoreis
{
    public class PropertyAmenityReposiyory : IPropertyAmenityReposiyory
    { 
        private readonly Context _context;

        public PropertyAmenityReposiyory(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPropertyAmenityByStatusTrue>> ResultPropertyAmenityByStatusTrues(int id)
        {
            string query = "Select PropertyAmenityID,Title From PropertyAmenity inner Join Amenity on Amenity.AmenityID=PropertyAmenity.Amenityıd where Propertyıd=@propertıd and Status=1";
            var paremeters = new DynamicParameters();
            paremeters.Add("@propertıd", id); 
            using(var connection=_context.CreateConnection())  
            {  
              var values=await connection.QueryAsync<ResultPropertyAmenityByStatusTrue>(query,paremeters) ;
                return values.ToList();
              
            }
        }
    }
}
