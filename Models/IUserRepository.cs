using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAPoster.Models
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void Add(User user);
        Task SaveAsync();

        Task AddPostItem(User user, VkPostItem item);
        Task EditSettingAsync(User user);
        Task AddPostItemRange(User user, List<VkPostItem> items);
        Task EditPostItem(User user, VkPostItem item);
        Task DeletePostItem(User user, VkPostItem item);
        Task DeletePostItemsAsync(User user, int countItems);

        void DeletePostSetting(User user, PostSetting postSetting);
        void EditPostSetting(User user, PostSetting postSetting);
        void AddPostSettingAsync(User user);
    }
}