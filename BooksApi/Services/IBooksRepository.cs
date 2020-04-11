using BooksApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Services
{
    public interface IBooksRepository
    {
        //IEnumerable<Entities.Book> GetBooks();

        //Entities.Book GetBook(Guid Id);

        Task<IEnumerable<Entities.Book>> GetBooksAsync();

        Task<Entities.Book> GetBookAsync(Guid Id);
    }
}
