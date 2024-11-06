using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductimagesDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductimagesResitories
{ 
  
    public class ProductimageRepository:IProductimageRepository
    {
        private readonly Context _context;

        public ProductimageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<GetProductImageByProductIdDto>> GetProductImageByProductId(int id)
        {
            string query = "Select * From Productimage where ProductID=@productıd";
            var parameters = new DynamicParameters(); 
            parameters.Add("@productıd",id ); 
            using(var connection=_context.CreateConnection())  
            {  
              var values=await connection.QueryAsync<GetProductImageByProductIdDto>(query, parameters);
                return values.ToList();
            
            }
        }
    }
}
