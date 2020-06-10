using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TAPoster.Models;

namespace TAPoster.Controllers
{
    public class HomeController : Controller
    {
        
        
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index() => View();

        [Authorize]
        public IActionResult About()
        {
            User currentUser = _context.Users.FirstOrDefault(u => u.Name == User.Identity.Name);
            return View(currentUser);
        }
    }
}
