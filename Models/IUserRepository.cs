using System.Linq;

namespace TAPoster.Models
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
    }
}