using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StunasMobile.Core;
using StunasMobile.Data.DbContext;
using StunasMobile.Entities.Entitites;

namespace StunasMobile.api.Controllers
{
    [EnableCors("myPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly StunasDBContext _context;

        public UsersController(StunasDBContext context)
        {
            _context = context;
        }

        [HttpGet("allUsers")]
        public async Task<List<User>> GetAll()
        {
            var Users = await _context.Users.ToListAsync();
            return Users;
        }
        
        [HttpPut("changePrevilege/{id}")]
        public async Task<IActionResult> ChangePriv(int id,PatchUserRole changedRole)
        {
            var userToUpdate = _context.Users.Where(u => u.UserId == id).FirstOrDefault();
            if (userToUpdate == null)
            {
                return BadRequest("il n'y a pas d'utilisateur avec cet id");
            }
            userToUpdate.Role = changedRole.Role;
            _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();

            return Ok("user updated sucuessfully");
        }
        
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteMobile(int id)
        {
            User userToDelete = await _context.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();
            if (userToDelete == null)
            {
                return BadRequest($"le record avec l'id: {id} n'existe pas");

            }

            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
            return Ok(new {message = " user est bien été supprimé"});
        }
    }
}