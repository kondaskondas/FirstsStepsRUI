using System.Collections.Generic;
using System.Threading.Tasks;
using FirstsStepsRUI.Models;

namespace FirstsStepsRUI.Repositories
{
    public interface IUserRepository
    {
        Task<User> Login(string userName, string unsecurePassword);
        Task<IList<Menu>> GetMenuByUser(User user);
    }
}
