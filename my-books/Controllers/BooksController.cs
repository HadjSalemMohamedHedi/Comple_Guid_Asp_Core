using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;

        public BooksController(BooksService BooksService)
        {
            _booksService= BooksService;
        }



        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }
   
    
        [HttpGet]
        public IActionResult GetAllBook()
        {
            var allBooks = _booksService.GetAllBook();
            return Ok(allBooks);
        }



        [HttpGet("get-book-by-id/{BookId}")]
        public IActionResult GetBookById(int BookId)
        {
            var Book = _booksService.GetBookById(BookId);
            return Ok(Book);
        }



        [HttpPut("update-book/{id}")]
        public IActionResult UpdateBookById(int id,[FromBody] BookVM book)
        {
            _booksService.UpdateBookById(id,book);
            return Ok();
        }


        [HttpDelete("delete-book/{id}")]
        public IActionResult DeletingBookByid(int id)
        {
            _booksService.DeletingBookByid(id);
            return Ok();
        }




    }
}
