using MyModels;

namespace BlazorServer.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
