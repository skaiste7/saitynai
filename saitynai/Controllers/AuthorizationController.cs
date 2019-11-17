using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using saitynai.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace saitynai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly UserContext _context;
        private readonly WorkerContext _context2;
        private readonly AdminContext _context3;

        public AuthorizationController(UserContext context, WorkerContext context2, AdminContext context3)
        {
            _context = context;
            _context2 = context2;
            _context3 = context3;
        }

        //[HttpPost("{username}/{password}")]
        [HttpPost("login")]
        //public async Task<IActionResult> GetAuthorization([FromRoute]string username, [FromRoute] string password)
        public IActionResult GetAuthorization([FromBody] Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


        int exist = doExistLogin(admin);

        if (exist == 0)
        {
            return BadRequest("Here is no such user");
        }
        else if (exist - 3000 > 0) { int id = exist - 3000; return Ok(new JwtSecurityTokenHandler().WriteToken(UserToken(id))); }
        else if (exist - 2000 > 0) { int id = exist - 2000; return Ok(new JwtSecurityTokenHandler().WriteToken(WorkerToken(id))); }
        else { int id = exist - 1000; return Ok(new JwtSecurityTokenHandler().WriteToken(AdminToken(id))); }
          // return Ok("testas");
         } 
        
        public int doExist(Admin admin)
        {
            var pass = _context3.Admins.Where(l => l.Password == admin.Password).Select(x => x.Id).FirstOrDefault();
            var user = _context3.Admins.Where(l => l.Email == admin.Email).Select(x => x.Id).FirstOrDefault();
            pass = pass + _context2.Workers.Where(l => l.Password == admin.Password).Select(x => x.Id).FirstOrDefault();
            user = user + _context2.Workers.Where(l => l.Email == admin.Email).Select(x => x.Id).FirstOrDefault();
            pass = pass + _context.Users.Where(l => l.Password == admin.Password).Select(x => x.Id).FirstOrDefault();
            user = user + _context.Users.Where(l => l.Email == admin.Email).Select(x => x.Id).FirstOrDefault();
            return pass + user;
        }

        public int doExistLogin(Admin admin)
        {
            int pass = 0;
            int user = 0;
            pass = _context3.Admins.Where(l => l.Password == admin.Password).Select(x => x.Id).FirstOrDefault();
            user = _context3.Admins.Where(l => l.Email == admin.Email).Select(x => x.Id).FirstOrDefault();
            if (pass > 0 && user > 0)
            {
                return pass + 1000;
            }
            pass = pass + _context2.Workers.Where(l => l.Password == admin.Password).Select(x => x.Id).FirstOrDefault();
            user = user + _context2.Workers.Where(l => l.Email == admin.Email).Select(x => x.Id).FirstOrDefault();
            if (pass > 0 && user > 0)
            {
                return pass + 2000;
            }
            pass = pass + _context.Users.Where(l => l.Password == admin.Password).Select(x => x.Id).FirstOrDefault();
            user = user + _context.Users.Where(l => l.Email == admin.Email).Select(x => x.Id).FirstOrDefault();
            if (pass > 0 && user > 0)
            {
                return pass + 3000;
            }
            else { return 0; }
        }

        public JwtSecurityToken AdminToken(int id)
        {
            Environment.SetEnvironmentVariable("TestAdmin", "this_is_Admin_key");

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("TestAdmin")));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            // add claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));

            //create token
            var token = new JwtSecurityToken(
                issuer: "gift.lt",
                audience: "readers",
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signingCredentials,
                //Id: admin.Id,
                claims: claims

                );
            return token;
            // return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public JwtSecurityToken WorkerToken(int id)
        {
            Environment.SetEnvironmentVariable("TestWorker", "this_is_Worker_key");

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("TestWorker")));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            // add claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Worker"));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));

            //create token
            var token = new JwtSecurityToken(
                issuer: "gift.lt",
                audience: "readers",
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signingCredentials,
                claims: claims
                );
            return token;
            // return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public JwtSecurityToken UserToken(int id)
        {
            Environment.SetEnvironmentVariable("TestUser", "this_is_User_key");

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("TestUser")));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            // add claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "User"));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));

            //create token
            var token = new JwtSecurityToken(
                issuer: "gift.lt",
                audience: "readers",
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signingCredentials,
                claims: claims
                );
            return token;
            // return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

        [HttpGet("token")]
        public IActionResult Token()
        {
            string tokenString = "test";
            return Ok(tokenString);
           // return View();
        }
    }
}