using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAPoster.Models;
using TAPoster.PosterLogic;

namespace TAPoster.Controllers
{
    public class PostController : Controller
    {
        
        private IUserRepository _context;

        public PostController(IUserRepository context)
        {
            _context = context;
        }

        public async Task<IActionResult> Posts(VkWall wall)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);
            List<VkPostItem> items = await wall.GetItemsAsync(user);

            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> PostTelegram(VkPostItem postItem, TelegramPoster poster)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);
            await poster.SendPost(postItem, user.UserSetting.TelegramToken, user.UserSetting.TelegramGroup);

            return RedirectToAction(nameof(Posts));
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