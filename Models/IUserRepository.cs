using System.Linq;
using System.Threading.Tasks;

namespace TAPoster.Models
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void Add(User user);
        Task SaveAsync();
        Task EditSettingAsync(User user);
    }
}