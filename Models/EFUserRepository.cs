using System.Collections.Generic;
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

        public IQueryable<User> Users => _context.Users.Include(s => s.UserSetting).Include(p => p.PostSettings)
                .Include(v => v.VkPostItems);

        public void Add(User user)
        {
            _context.Add(user);
        }
        
        public void AddPostSettingAsync(User user)
        {
            _context.AttachRange(user.PostSettings);
        }

        public void EditPostSetting(User user, PostSetting postSetting)
        {
            User currentUser = _context.Users.FirstOrDefault(u => u.Name == user.Name);
            PostSetting currentPostSetting = currentUser.PostSettings.FirstOrDefault(p => p.PostSettingId == postSetting.PostSettingId);
            currentPostSetting.UpdateModel(postSetting);
        }

        public void DeletePostSetting(User user, PostSetting postSetting)
        {
            User currentUser = _context.Users.FirstOrDefault(u => u.Name == user.Name);
            PostSetting currentPostSetting = currentUser.PostSettings.FirstOrDefault(p => p.PostSettingId == postSetting.PostSettingId);
            currentUser.PostSettings.Remove(currentPostSetting);
        }

        public async Task AddPostItemRange(User user, List<VkPostItem> items)
        {
            User currentUser = await _context.Users.FirstOrDefaultAsync(u => u.Name == user.Name);
            currentUser.VkPostItems.AddRange(items);
        }


        public async Task DeletePostItemAsync(User user, int countItems)
        {
            User currentUser = await _context.Users.FirstOrDefaultAsync(u => u.Name == user.Name);
            currentUser.VkPostItems.RemoveRange(0, countItems);
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