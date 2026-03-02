using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDotNetApplication.Models;
using WebDotNetApplication.Data;

namespace WebDotNetApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly WebAppContext _context;

        public UsersController(WebAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            // Lấy danh sách user thực tế từ bảng Users trong app.db
            var users = await _context.Users.ToListAsync();
            var roles = await _context.Roles.ToListAsync();
            return Ok(new { Users = users, Roles = roles });
        }
    }
}