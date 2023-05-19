using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // /api/Users

    public class UsersController : ControllerBase
    {
        private readonly DataContext _contetxt;
        public UsersController(DataContext contetxt)
        {
            _contetxt = contetxt;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {

            var users = await _contetxt.Users.ToListAsync();
            if (users != null)
            {
                return users;
            }
            else
            {
                return NotFound();

            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _contetxt.Users.FindAsync(id);

        }

    }
}