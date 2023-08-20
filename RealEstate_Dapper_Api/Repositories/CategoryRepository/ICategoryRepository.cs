using RealEstate_Dapper_Api.Dtos.CategoryDto;
using RealEstate_Dapper_Api.Dtos.ResponseDto;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        ResponseResultModel CreateCategory(CreateCategoryDto createCategoryDto);
        ResponseResultModel UpdateCategory(UpdateCategoryDto updateCategoryDto);
        ResponseResultModel DeleteCategory(int id);
        Task<ResultCategoryDto> GetCategory(int id);
    }
}
