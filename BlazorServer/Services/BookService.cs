using MyModels;

namespace BlazorServer.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient client;
        public BookService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await client.GetFromJsonAsync<List<Book>>("api/Books") ?? Enumerable.Empty<Book>();
        }
    }
}
