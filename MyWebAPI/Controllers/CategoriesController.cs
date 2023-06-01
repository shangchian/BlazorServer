using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyModels;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly BookContext context;
        public CategoriesController(BookContext context)
        {
            this.context = context;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult> Get()   // 如果 try 與 catch 的回傳型別不一樣，就要用 ActionResult
        {
            try
            {
                return Ok(await context.Categories.ToListAsync());   // Ok 會自動送 200 狀態碼
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error get books from database! ");
            }
        }
    }
}
