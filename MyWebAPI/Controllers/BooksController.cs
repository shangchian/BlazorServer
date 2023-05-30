using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookContext context;
        public BooksController(BookContext context)
        {
            this.context = context;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<ActionResult> Get()   // 如果 try 與 catch 的回傳型別不一樣，就要用 ActionResult
        {
            try
            {
                return Ok(await context.Books.ToListAsync());   // Ok 會自動送 200 狀態碼
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error get books from database! ");
            }
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
