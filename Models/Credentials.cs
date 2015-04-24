namespace FirstsStepsRUI.Models
{
    public class Credential
    {
        public User User { get; set; }
        public string Password { get; set; }

        public Credential(User user, string password)
        {
            User = user;
            Password = password;
        }
    }
}
