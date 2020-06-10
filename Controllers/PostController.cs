using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAPoster.Models;

namespace TAPoster.Controllers
{
    public class PostController : Controller
    {
        
        private IUserRepository _context;

        public PostController(IUserRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AddPostSetting() => View();

        [HttpPost]
        public async Task<IActionResult> AddPostSetting(PostSettingModel model)
        {
            if(ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);

                try
                {
                    user.PostSettings.Add(new PostSetting 
                    { 
                        GroupUrl = model.GroupUrl,
                        PostCount = model.PostCount,
                        PostFilter = model.PostFilter
                    });

                    _context.AddPostSettingAsync(user);
                    await _context.SaveAsync();
                }
                catch (System.Exception)
                {
                    
                    //TODO exception
                }

                return RedirectToAction("About", "Home");
                
            }
            return View(model);
        }

    }
}