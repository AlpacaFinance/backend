using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlpacaFinanceApp.Data;
using AlpacaFinanceApp.Entities;
using AlpacaFinanceApp.Web.Models.User;

namespace AlpacaFinanceApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AlpacaDbContext _context;

        public UsersController(AlpacaDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            var userList = await _context.Users.ToListAsync();

            return userList.Select(u => new UserModel
            {
                UserId = u.UserId,
                FirstName = u.FirstName,
                LastName = u.LastName,
                DocumentType = u.DocumentType,
                DocumentNumber = u.DocumentNumber,
                Email = u.Email,
                Country = u.Country,
                RegisterDate = u.RegisterDate
            }).ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(new UserModel
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DocumentType = user.DocumentType,
                DocumentNumber = user.DocumentNumber,
                Email = user.Email,
                Country = user.Country,
                RegisterDate = user.RegisterDate
            });
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] UpdateUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id < 0)
                return BadRequest();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
                return NotFound();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.DocumentType = model.DocumentType;
            user.DocumentNumber = model.DocumentNumber;
            user.Email = model.Email;
            user.Country = model.Country;
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody]UserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            User user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DocumentType = model.DocumentType,
                DocumentNumber = model.DocumentNumber,
                Email = model.Email,
                Country = model.Country,
                RegisterDate = DateTime.Now
            };

            _context.Users.Add(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // DELETE: api/Users/5
        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }        
        
    }
}
