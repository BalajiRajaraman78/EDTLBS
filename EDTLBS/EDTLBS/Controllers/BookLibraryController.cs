using EDTLBS.Common.Model;
using EDTLBS.Repository;
using EDTLBS.Services;
using Microsoft.AspNetCore.Mvc;


namespace EDTLBS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookLibraryController : ControllerBase
    {
        private readonly IBookServices _bookServices;
        public BookLibraryController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }
        // GET: api/<BookLibraryController>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<IEnumerable<Book>>))]
        public IActionResult GetBooks()
        {
            return Ok(_bookServices.GetBooks());
        }

        // GET api/<BookLibraryController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Book))]
        public IActionResult GetBook(int id)
        {
            var book = _bookServices.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST api/<BookLibraryController>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Book))]
        public IActionResult AddBook(Book book)
        {
            var createdBook = _bookServices.AddBook(book);
            return Ok(createdBook);
            //return CreatedAtAction(nameof(GetBook(createdBook.Id)), new { id = createdBook.Id }, createdBook);
        }

        // PUT api/<BookLibraryController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(Book))]
        public IActionResult UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            var updatedBook = _bookServices.UpdateBook(book);
            return Ok(updatedBook);
        }

        // DELETE api/<BookLibraryController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult DeleteBook(int id)
        {
            var book = _bookServices.GetBook(id);
            if(book == null) 
                return NotFound(false);
            if (book.Id != id)
                return NotFound(false);
            var isDeleted = _bookServices.DeleteBook(id);
            return Ok(isDeleted);
        }
    }
}
