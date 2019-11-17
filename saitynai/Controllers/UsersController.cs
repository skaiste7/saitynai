using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using saitynai.Models;

namespace saitynai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;
        private readonly WorkerContext _context2;
        private readonly AdminContext _context3;

        public UsersController(UserContext context, WorkerContext context2, AdminContext context3)
        {
            _context = context;
            _context2 = context2;
            _context3 = context3;
        }


        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // GET: api/Users/5
        [HttpGet("{id}/orders")]
        public async Task<IActionResult> GetItemOrders([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = await _context.Users.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            var orders = _context.Orders.Where(l => l.UserId == id);
            return Ok(orders);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int exist = doExist(user);

            if (exist != 0)
            {
                return BadRequest("somethink went wrong");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmin", new { id = user.Id }, user);

        }

        public int doExist(User users)
        {
            var pass = _context3.Admins.Where(l => l.Password == users.Password).Select(x => x.Id).FirstOrDefault();
            var user = _context3.Admins.Where(l => l.Email == users.Email).Select(x => x.Id).FirstOrDefault();
            pass = pass + _context2.Workers.Where(l => l.Password == users.Password).Select(x => x.Id).FirstOrDefault();
            user = user + _context2.Workers.Where(l => l.Email == users.Email).Select(x => x.Id).FirstOrDefault();
            pass = pass + _context.Users.Where(l => l.Password == users.Password).Select(x => x.Id).FirstOrDefault();
            user = user + _context.Users.Where(l => l.Email == users.Email).Select(x => x.Id).FirstOrDefault();

            return pass + user;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}