using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;

namespace Greenwich.WebService.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<bool> CreateCategoryAsync(CreateCategoryRequest model);

        Task<bool> UpdateCategoryAsync(Category model);

        Task<bool> DeleteCategoryAsync(int id);
    }
}
