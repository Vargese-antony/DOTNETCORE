using BooksApi;
using BooksApi.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Services
{
    public class BooksRepository : IBooksRepository, IDisposable
    {
        private BooksContext _context;
        public BooksRepository(BooksContext booksContext)
        {
            _context = booksContext;
        }

        public async Task<Entities.Book> GetBookAsync(Guid Id)
        {
            return await _context.Books.Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == Id);
        }

        public async Task<IEnumerable<Entities.Book>> GetBooksAsync()
        {
            return await _context.Books.Include(b => b.Author)
                .ToListAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
