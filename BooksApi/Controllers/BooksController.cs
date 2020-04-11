using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _booksRepository.GetBooksAsync();
            return Ok(books);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _booksRepository.GetBookAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}