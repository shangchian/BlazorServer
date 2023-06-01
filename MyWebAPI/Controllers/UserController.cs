using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyModels;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly BookContext context;
        public UserController(BookContext context)
        {
            this.context = context;
        }
        [HttpPost]
        [Route("loginuser")]
        public async Task<IActionResult> Login(WebUser user)
        {
            WebUser? loginUser = await context.WebUsers
              .Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefaultAsync();
            if (loginUser == null) return Unauthorized();
            return Ok(loginUser);
        }
    }
}
