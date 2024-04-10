using Microsoft.EntityFrameworkCore;
using OnlineShoppingSystem.Data;
using OnlineShoppingSystem.Interface;
using OnlineShoppingSystem.Models;
namespace OnlineShoppingSystem.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly OnlineShoppingSystemContext _context;

        public UsersRepository(OnlineShoppingSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task PutUser(int id, User User)
        {
            if (id != User.Id)
            {
                throw new ArgumentException("Id mismatch");
            }

            _context.Entry(User).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<User> PostUser(User User)
        {
            _context.User.Add(User);
            await _context.SaveChangesAsync();
            return User;
        }

        public async Task DeleteUser(int id)
        {
            var User = await _context.User.FindAsync(id);
            _context.User.Remove(User);
            await _context.SaveChangesAsync();
        }

        public bool UserExists(int id) // Implemented method
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
