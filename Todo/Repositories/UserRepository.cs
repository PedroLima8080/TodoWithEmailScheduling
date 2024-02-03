using Todo.Application.Context;
using Todo.Data.Models;

namespace Todo.Application.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(DataContext _context) : base(_context)
        {
        }

        public bool IsEmailUnique(string email)
        {
            return !this._context.Set<User>().Any(user => user.Email == email);
        }
    }
}
