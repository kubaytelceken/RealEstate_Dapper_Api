using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDto;
using RealEstate_Dapper_Api.Dtos.ResponseDto;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public ResponseResultModel CreateCategory(CreateCategoryDto createCategoryDto)
        {
            ResponseResultModel responseResultModel = new ResponseResultModel();
            createCategoryDto.Status = true;
            string query = "INSERT INTO CATEGORY (NAME,STATUS) VALUES ('" + createCategoryDto.Name + "','" + createCategoryDto.Status + "')";

            try
            {
                using (var connection = _context.CreateConnection())
                {

                    connection.ExecuteAsync(query);
                    responseResultModel.STATU = 1;
                    responseResultModel.MESSAGE = "The category has been successfully added.";
                }
            }
            catch (Exception ex)
            {
                responseResultModel.STATU = 0;
                responseResultModel.MESSAGE = $"Error : {ex.ToString}";
            }

            return responseResultModel;
        }

        public ResponseResultModel DeleteCategory(int id)
        {
            ResponseResultModel responseResultModel = new ResponseResultModel();
            string query = "DELETE FROM CATEGORY WHERE Id = " + id + "";
            try
            {
                using (var connection = _context.CreateConnection())
                {

                    connection.ExecuteAsync(query);
                    responseResultModel.STATU = 1;
                    responseResultModel.MESSAGE = "The category has been successfully deleted.";
                }
            }
            catch (Exception ex)
            {
                responseResultModel.STATU = 0;
                responseResultModel.MESSAGE = $"Error : {ex.ToString}";
            }

            return responseResultModel;
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "SELECT * FROM CATEGORY WITH (NOLOCK)";
            using(var connection = _context.CreateConnection())
            {
                connection.Open();

                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                
                return values.ToList();
            }
        }

        public async Task<ResultCategoryDto> GetCategory(int id)
        {
            string query = "SELECT * FROM CATEGORY WHERE Id =@Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<ResultCategoryDto>(query,parameters);
            }
        }

        public ResponseResultModel UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            ResponseResultModel responseResultModel = new ResponseResultModel();
            string query = "UPDATE CATEGORY SET NAME = '"+updateCategoryDto.Name+"',STATUS = '"+updateCategoryDto.Status+"' WHERE Id = "+updateCategoryDto.Id+"";

            try
            {
                using (var connection = _context.CreateConnection())
                {

                    connection.ExecuteAsync(query);
                    responseResultModel.STATU = 1;
                    responseResultModel.MESSAGE = "The category has been successfully updated.";
                }
            }
            catch (Exception ex)
            {
                responseResultModel.STATU = 0;
                responseResultModel.MESSAGE = $"Error : {ex.ToString}";
            }

            return responseResultModel;
        }
    }
}
