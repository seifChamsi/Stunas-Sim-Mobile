using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StunasMobile.Core;
using StunasMobile.Data.DbContext;
using StunasMobile.Entities.Entitites;

namespace StunasMobile.api.Controllers
{
    [EnableCors("myPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly StunasDBContext _context;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AccountController(StunasDBContext context, IConfiguration config,IMapper mapper)
        {
            _context = context;
            _config = config;
            _mapper = mapper;
        }
        [HttpPost("auth/login")]
        public IActionResult Login([FromBody] LoginModelView user)
        {
            if (user.username == null || user.password == null)
            {
                return BadRequest("Invalid Client request");
            }

            var dbUser = _context.Users.FirstOrDefault(u => u.username == user.username);


            if (user.username == dbUser.username && user.password == dbUser.password)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SOME_RANDOM_KEY_DO_NOT_SHARE"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claimsList = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, dbUser.UserId.ToString()), 
                    new Claim(ClaimTypes.Name, dbUser.username.ToString()),
			new Claim(ClaimTypes.Name, dbUser.Role.ToString()),
                };

                var takeOptions = new SecurityTokenDescriptor {
                    Issuer = "http://localhost:5001",
                    Subject = new ClaimsIdentity(claimsList),
                    Audience = "http://localhost:4200",
                    Expires = DateTime.Now.AddMinutes(15),
                    SigningCredentials=  signinCredentials
                };

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken token = tokenHandler.CreateToken(takeOptions);
                
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new
                {
                    succuess = true,
                    Token = tokenString,
                    userId = claimsList[0].Value,
                    username = claimsList[1].Value,
			role = claimsList[2].Value
                  
                });
            }
            else
            {
                return Unauthorized();
            }
        }
        [HttpPost("auth/Signup")]
        public IActionResult Signup([FromBody] SignupModelView user)
        {
            if (user == null)
            {
                return BadRequest("Invalid Client request");
            }

            var isEmailExist = _context.Users.Where(u => u.Email == user.Email).FirstOrDefault();
            if (isEmailExist != null)
            {
                return BadRequest("l'email existe deja pour un autre utilisateur");
            }

            var userToInsert = _mapper.Map<SignupModelView,User>(user);
            _context.Users.Add(userToInsert);
            _context.SaveChanges();

            
            return Ok(new
            {
                succuess = true,
                message = "le nouveau utilisateur est bien enregistré"
            });
        }

        
    }
}
