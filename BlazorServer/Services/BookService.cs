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

        public async Task<Book?> GetBook(int id)
        {
            try
            {
                return await client.GetFromJsonAsync<Book>($"api/Books/{id}");
            }
            catch(Exception)
            {
                return default;
            }
        }

        public async Task UpdateBook(Book updatedBook)
        {
            await client.PutAsJsonAsync($"api/Books/{updatedBook.Id}", updatedBook);
        }

        public async Task CreateBook(Book book)
        {
            await client.PostAsJsonAsync($"api/Books/", book);
        }
    }
}
