using BooksStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Contracts
{
    public interface IBookDetailsRepository
    {
        Task<IEnumerable<BookDetail>> GetAllBooks();
        Task<bool> SaveBookDetails(BookDetail bookDetail);
        Task<bool> EditBookDetails(BookDetail bookDetail);
        Task<bool> DeleteBookDetails(int id);
        Task<BookDetail> GetBookById(int id);
    }
}
