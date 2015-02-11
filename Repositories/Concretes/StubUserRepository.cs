using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirstsStepsRUI.Models;

namespace FirstsStepsRUI.Repositories
{
    public class StubUserRepository : IUserRepository
    {
        public async Task<User> Login(string userName, string unsecurePassword)
        {
            User result;
            if (userName.IsInvalid())
                throw new ArgumentException("userName");
            if (unsecurePassword.IsInvalid())
                throw new ArgumentException("unsecurePassword");
            // TODO real call to DB
            if (userName == "admin")
            {
                if (unsecurePassword == "correct horse battery staple")
                    result = new User(1, "1337", true, UserGroup.Admin);
                else
                    throw new Exception("Invalid credentials.");
            }
            else
                result = new User(2, "Generic", true, UserGroup.Worker);

            return await Task.FromResult(result);
        }

        public async Task<IList<Menu>> GetMenuByUser(User user)
        {
            List<Menu> result;
            if (user == null)
                return new List<Menu> {new Menu(MenuOption.Login)};
            // TODO real call to DB
            result = user.Group == UserGroup.Admin
                ? new List<Menu>
                {
                    new Menu(MenuOption.Login),
                    new Menu(MenuOption.User),
                    new Menu(MenuOption.Placeholder)
                }
                : new List<Menu>
                {
                    new Menu(MenuOption.User),
                    new Menu(MenuOption.Placeholder)
                };

            return await Task.FromResult(result);
        }
    }
}