using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyModels;
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
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            try
            {
                var b = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
                if( b is null)
                {
                    return NotFound();
                }
                return b;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error get books from database! ");
            }
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<ActionResult<Book>> Post([FromBody] Book book)
        {
            try
            {
                if(book is null)
                {
                    return BadRequest();
                }
                var b = (await context.Books.AddAsync(book)).Entity;
                await context.SaveChangesAsync();
                return CreatedAtAction(nameof(Post), new { id = b.Id }, b);
            }
            catch(Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error insert books to database! ");
            }
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Put(int id, [FromBody] Book book)
        {
            try
            {
                if(id != book.Id)
                {
                    return BadRequest("Id is not the same.");
                }
                var b = await context.Books.FirstOrDefaultAsync(b => b.Id == book.Id);
                if(b is null)
                {
                    return NotFound($"Book id{id} is not found.");
                }
                b.Title = book.Title;
                b.Price = book.Price;
                b.InStock  = book.InStock;
                b.PublishDate = book.PublishDate;
                b.Description = book.Description;
                await context.SaveChangesAsync();
                return b;
            } 
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error! ");
            }
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
