using JSB.Contracts.DTO;
using JSB.Contracts.InterfaceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSB.Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
     public async Task<IActionResult> ListOfAllBooks()
        {
            var books = await _bookService.GetAllBooks();
            if (books.ModelList == null || books.IsValid==false)
            {
                return NotFound("No books found.");
            }
            return Ok(books.ModelList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _bookService.GetBookById(id);
            if (book.Model == null || book.IsValid == false)
            {
                return NotFound("Book not found.");
            }
            return Ok(book.Model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewBook([FromBody] BookDTO bookDTO)
        {
            if (bookDTO == null)
            {
                return BadRequest("Invalid book data.");
            }
            var result = await _bookService.AddBook(bookDTO);
            if (!result.IsValid)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] BookDTO bookDTO)
        {
            if (bookDTO == null)
            {
                return BadRequest("Invalid book data.");
            }
            var result = await _bookService.UpdateBook(bookDTO);
            if (!result.IsValid)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var result = await _bookService.DeleteBook(id);
            if (!result.IsValid)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }
    }
}
