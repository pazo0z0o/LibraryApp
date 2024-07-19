using DataModels.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        // GET: api/<BookController>
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {


            return Ok();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult>Post([FromBody] Book book)
        {
            return Ok(book);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {

            return Ok();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {


            return Ok();
        }
    }
}
