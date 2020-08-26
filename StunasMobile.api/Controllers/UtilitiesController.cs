using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using StunasMobile.Core;
using StunasMobile.Data.DbContext;
using StunasMobile.Entities.Entitites;

namespace StunasMobile.api.Controllers
{
    [EnableCors("myPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class UtilitiesController : ControllerBase
    {
        private readonly StunasDBContext _context;

        public UtilitiesController(StunasDBContext context)
        {
            _context = context;
        }
        
        [HttpGet("GetAllCodeClient")]
        public async Task<Object> AllCodeClients()
        {
            var codeClientList = _context.Mobiles.Select(m => m.Codeclient).ToHashSet().ToList();

            return new {
                succues = true,
                codeC = codeClientList
            };
        }
        
        [HttpGet("GetAllSociete")]
        public async Task<Object> AllSociete()
        {
            var Societe = _context.Mobiles.Select(m => m.Societe).ToHashSet().ToList();

            return new{
                succuess= true,
                Socite = Societe
            };
        }
        
        [HttpGet("GetAllSite")]
        public async Task<Object> AllSite()
        {
            var codeClientList = _context.Mobiles.Select(m => m.Site).ToHashSet().ToList();

            return new{
                succuess=true,
                sites = codeClientList

            };
        }
        
        [HttpGet("GetAllForfait")]
        public async Task<List<string>> AllForfait()
        {
            var codeClientList = _context.Mobiles.Select(m => m.Forfait).ToHashSet().ToList();

            return codeClientList;
        }

        [HttpGet("GetHistory/{id}")]
        public async Task<object> HistoryListing(int id)
        {
            var history = _context.Mobiles.Where(m=>m.Id == id).Select(m => m.Historiques).ToList();

            return history;
        }
        
        [HttpGet("GetAllHandset")]
        public async Task<Object> AllHandset()
        {
            var handsets = _context.Mobiles.Select(m => m.Handset).ToHashSet().ToList();

            return new {
                succuess = true,
                handsets = handsets
            };
        }

        [HttpPost("forgetPassword")]
        public  Object SendPasswordMail(ForgotPasswordViewModel model)
        {

            User userCrendentials =  _context.Users.FirstOrDefault(u => u.Email == model.email);

            if(userCrendentials == null){
                return BadRequest();
            }

            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse("joosoormobile@gmail.com");
            email.To.Add(MailboxAddress.Parse(model.email));
            email.Subject = "Password Reset";
            email.Body = new TextPart(TextFormat.Html) { Text = $"<h1>Salut Mr {userCrendentials.username}</h1><br><br> You seem like you forget your password.<br>YOUR PASSWORD : <b>{userCrendentials.password}</b><br><br> Best Regards." };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("JoosoorMobile", "Passer00$");
            smtp.Send(email);
            smtp.Disconnect(true);
            return new {
                succues = true,
                message = "l'email est bien envoyé"
            };
        }

       
    }
}