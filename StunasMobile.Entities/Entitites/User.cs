using System.ComponentModel.DataAnnotations;

namespace StunasMobile.Entities.Entitites
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Role { get; set; } = "user";
    }
}