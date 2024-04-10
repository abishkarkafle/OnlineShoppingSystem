using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Interface
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task PutUser(int id, User user);
        Task<User> PostUser(User user);
        Task DeleteUser(int id);
        bool UserExists(int id);
    }
}
