using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAPoster.Models;

namespace TAPoster.Components
{

    public class NavigationTopMenuViewComponent : ViewComponent
    {
        private IUserRepository _context;

        public NavigationTopMenuViewComponent(IUserRepository context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            User currentUser = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);
            return View(currentUser);
        }
    }
}