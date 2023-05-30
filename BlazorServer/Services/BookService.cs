using MyModels;

namespace BlazorServer.Services
{
    public class BookService : IBookService
    {
        private static List<Book> books = new()
        {
            new Book()
            {
                Id = 1,
                Title = " Essential Programming Language ",
                Price = 250,
                PublishDate = new DateTime(2019,1,2),
                InStock = true,
                Description = " Essential Programming Language "
            },
            new Book()
            {
                Id = 2,
                Title = " Telling Arts ",
                Price = 245,
                PublishDate = new DateTime(2019,4,15),
                InStock = true,
                Description = " Telling Arts "
            },
            new Book()
            {
                Id = 3,
                Title = " Marvel ",
                Price = 150,
                PublishDate = new DateTime(2019,2,21),
                InStock = true,
                Description = " Marvel "
            },
            new Book()
            {
                Id = 4,
                Title = " The beauty of cook ",
                Price = 450,
                PublishDate = new DateTime(2019,12,2),
                InStock = true,
                Description = " The beauty of cook "
            },
            new Book()
            {
                Id = 5,
                Title = " Learning how to cook ",
                Price = 450,
                PublishDate = new DateTime(2019,1,20),
                InStock = true,
                Description = " Learning how to cook "
            }
        };

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await Task.Run(() =>  books );
        }
    }
}
