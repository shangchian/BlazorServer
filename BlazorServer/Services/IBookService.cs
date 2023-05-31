using MyModels;

namespace BlazorServer.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();

        Task<Book?> GetBook(int id);

        Task UpdateBook(Book updatedBook);

        Task CreateBook(Book book);

        Task DeleteBook(int id);
    }
}
