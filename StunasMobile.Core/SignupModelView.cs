namespace StunasMobile.Core
{
    public class SignupModelView
    {
        public string Email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Role { get; set; } = "user";
    }
}