using DataAccess.Interfaces;
using DataModels.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Microsoft.Extensions.Logging;
using System.Drawing.Printing;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<BookController> _logger;
        private readonly IBookRepo<Book> _bookRepo;

        public BookController(IConfiguration configuration,ILogger<BookController> logger, IBookRepo<Book> bookRepo)
        {
            _logger = logger;
            _configuration = configuration;
            _bookRepo = bookRepo;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken ,int pageNumber = 1, int pageSize = 10)
        {
            
            try
            {
                var bookList = await Task.Run(() => _bookRepo.GetAll());

                bookList.ToList();
                var totalCount = bookList.Count();
                if (bookList == null || !bookList.Any())
                {
                    return NotFound("No books found.");
                }
                //(pageNumber -1 )* pageSize = 0 always):
                //used to set it from the start while also giving concrete values to our 2 parameters
                //pageNumber and pageSize at the function signature
                var paginatedList = bookList.Skip((pageNumber-1)* pageSize).Take(pageSize).ToList();
                Response.Headers.Add("X-Total-Count", totalCount.ToString());

                return Ok(paginatedList);
            }
            catch (Exception ex)
            {

                _logger.LogError("Failure to procure the full booklist!" ,ex.Message);
                return StatusCode(500, "Internal Error");
            }
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
                _logger.LogError($"Failure to procure the book with {id}!", ex.Message);
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
           
            try
            {
                 await _bookRepo.Add(createdBook);
                _logger.LogInformation($"Book Created Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failure to create book.", ex.Message);
                return StatusCode(500, "Internal Error");
            }

            return Ok();
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] Book updatedBook, CancellationToken cancel)
        {
            if (updatedBook == null || updatedBook.Id != id)
            {
                return BadRequest("Invalid book");
            }
            try
            {   
            //    tempBook = await _bookRepo.GetById(id);
                await _bookRepo.Update(updatedBook);
                _logger.LogInformation($"Book updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failure to update book with title: {updatedBook.Id}.", ex.Message);
                return StatusCode(500, "Internal Error");
            }
            return Ok(updatedBook);   
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id,CancellationToken cancel)
        {
         
            try
            {
                await _bookRepo.Delete(id);
                _logger.LogInformation($"Book with id: {id} deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failure to delete book with id: {id}", ex.Message);
                return StatusCode(500, "Internal Error");
            }

            return Ok("Book deleted successfully");
        }
    }
}
