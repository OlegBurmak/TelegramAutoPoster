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
        

        [Authorize]
        public IActionResult Index() => View();

        public IActionResult About()
        {
            return Content("For All");
        }
    }
}
