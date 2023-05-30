using MyModels;

namespace BlazorServer.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
    }
}
