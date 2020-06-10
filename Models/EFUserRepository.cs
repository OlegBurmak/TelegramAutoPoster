using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TAPoster.Models
{
    public class EFUserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public EFUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<User> Users => _context.Users.Include(s => s.UserSetting).Include(p => p.PostSettings);

        public void Add(User user)
        {
            _context.Add(user);
        }
        
        public void AddPostSettingAsync(User user)
        {
            _context.AttachRange(user.PostSettings);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task EditSettingAsync(User user)
        {
            if(user.UserSetting == null)
            {
                _context.Attach(user.UserSetting);
            }else{
                User currentUser = await _context.Users.FirstOrDefaultAsync(u => u.Name == user.Name);
                currentUser.UserSetting = user.UserSetting;
            }
        }
    }
}