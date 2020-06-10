using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TAPoster.Models
{
    public class EFProductRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public EFProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<User> Users => _context.Users.Include(s => s.UserSetting).Include(p => p.PostSettings);
    }
}