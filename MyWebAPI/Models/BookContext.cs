using Microsoft.EntityFrameworkCore;
using MyModels;

namespace MyWebAPI.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) 
        { 
        
        }

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<WebUser> WebUsers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WebUser>().HasData(
                new WebUser { Id = 1, UserName = "admin", Password = "111", Role = "Administrator" },
                new WebUser { Id = 2, UserName = "user", Password = "111", Role = "User" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Computers" },
                new Category { CategoryId = 2, CategoryName = "Arts" },
                new Category { CategoryId = 3, CategoryName = "Commics" },
                new Category { CategoryId = 4, CategoryName = "Cooking" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = 1,
                    Title = " Essential Programming Language ",
                    Price = 250,
                    PublishDate = new DateTime(2019, 1, 2),
                    InStock = true,
                    Description = " Essential Programming Language ",
                    CategoryId = 1
                },
                new Book()
                {
                    Id = 2,
                    Title = " Telling Arts ",
                    Price = 245,
                    PublishDate = new DateTime(2019, 4, 15),
                    InStock = true,
                    Description = " Telling Arts ",
                    CategoryId = 1
                },
                new Book()
                {
                    Id = 3,
                    Title = " Marvel ",
                    Price = 150,
                    PublishDate = new DateTime(2019, 2, 21),
                    InStock = true,
                    Description = " Marvel ",
                    CategoryId = 1
                },
                new Book()
                {
                    Id = 4,
                    Title = " The beauty of cook ",
                    Price = 450,
                    PublishDate = new DateTime(2019, 12, 2),
                    InStock = true,
                    Description = " The beauty of cook ",
                    CategoryId = 1
                },
                new Book()
                {
                    Id = 5,
                    Title = " Learning how to cook ",
                    Price = 450,
                    PublishDate = new DateTime(2019, 1, 20),
                    InStock = true,
                    Description = " Learning how to cook ",
                    CategoryId = 1
                }
            );
        }
    }
}
