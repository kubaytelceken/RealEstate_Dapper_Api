using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDto;
using RealEstate_Dapper_Api.Dtos.ProductDto;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            string query = "SELECT P.Id,P.Title,P.Price,P.City,P.District,P.ProductCategory,C.Name as CategoryName FROM PRODUCT P INNER JOIN CATEGORY C ON P.ProductCategory = C.Id ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }

            throw new NotImplementedException();
        }
    }
}
