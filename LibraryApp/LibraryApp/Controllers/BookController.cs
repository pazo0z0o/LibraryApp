using DataAccess.Interfaces;
using DataModels.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IBookRepo<Book> _bookRepo;

        public BookController(IConfiguration configuration,ILogger logger, IBookRepo<Book> bookRepo)
        {
            _logger = logger;
            _configuration = configuration;
            _bookRepo = bookRepo;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            IEnumerable<Book> bookList  = null;
            try
            {
                bookList = await _bookRepo.GetAll();
                bookList.ToList();
            }
            catch (Exception ex)
            {

                _logger.Information("Failure to procure the full booklist!" ,ex.Message);
                return StatusCode(500, "Internal Error");
            }

            if (bookList == null || !bookList.Any())
            {
                return NotFound("No books found.");
            }

            return Ok();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = new Book();
            try
            {
                book = await _bookRepo.GetById(id);

            }
            catch (Exception ex)
            {
                _logger.Information($"Failure to procure the book with {id}!", ex.Message);
                return StatusCode(500, "Internal Error");
            }

            if (book == null )
            {
                return NotFound("Book not found.");
            }

            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult>Post([FromBody] Book createdBook)
        {
            var newBook = new Book();
            try
            {
                newBook = await _bookRepo.Add(createdBook);
                _logger.Information($"Book Created Successfully");
            }
            catch (Exception ex)
            {
                _logger.Information($"Failure to create book.", ex.Message);
                return StatusCode(500, "Internal Error");
            }

            return Ok(newBook);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CancellationToken cancel)
        {
            var updatedBook = new Book();
            try
            {
                var tempBook = await _bookRepo.GetById(id);
                updatedBook = await _bookRepo.Update(tempBook);
                _logger.Information($"Book updated successfully");
            }
            catch (Exception ex)
            {
                _logger.Information($"Failure to update book with title: {updatedBook}.", ex.Message);
                return StatusCode(500, "Internal Error");
            }

            if (updatedBook == null)
            {
                return Ok("Failed to update book");
            }

            return Ok(updatedBook);

            
        }

        // DELETE api/<BookController>/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id,CancellationToken cancel)
        {
         
            try
            {
                await _bookRepo.Delete(id);
                _logger.Information($"Book with id: {id} deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.Information($"Failure to delete book with id: {id}", ex.Message);
                return StatusCode(500, "Internal Error");
            }

            return Ok("Book deleted successfully");
        }
    }
}
