using System.Threading.Tasks;
using FormApp.API.Models;

namespace FormApp.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Rejestracja(User user, string password);
         Task<User> Logowanie(string username, string password);
         Task<bool> UserExists(string username);
    }
}