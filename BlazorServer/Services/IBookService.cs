﻿using MyModels;

namespace BlazorServer.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();

        Task<Book?> GetBook(int id);
    }
}
