using Microsoft.AspNetCore.Mvc;
using MyModels;

namespace BlazorServer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient client;
        public CategoryService(HttpClient client)
        {
            this.client = client;
        }


        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await client.GetFromJsonAsync<List<Category>>("api/Categories") ?? Enumerable.Empty<Category>();
        }
    }
}
