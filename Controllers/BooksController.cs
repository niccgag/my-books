using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var allbooks = _booksService.GetAllBooks();
            return Ok(allbooks);
        }        
        [HttpGet("/{id}")]
        public IActionResult GetBooksById(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }
    }
}
