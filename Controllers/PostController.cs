using System.Collections.Generic;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAPoster.Models;
using TAPoster.PosterLogic;

namespace TAPoster.Controllers
{
    public class PostController : Controller
    {
        
        private IUserRepository _context;
        private List<VkPostItem> _items;

        public PostController(IUserRepository context)
        {
            _context = context;
            
        }

        public async Task<IActionResult> Posts(VkWall wall)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);
            _items = await wall.GetItemsAsync(user);

            return View(_items);
        } 

        [HttpPost]
        public async Task<IActionResult> PostTelegram(List<VkPostItem> postItems, TelegramPoster poster)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);
            System.Console.WriteLine("Yes");
            foreach(var item in postItems)
            {
                BackgroundJob.Enqueue(() => poster.SendPost(item, user.UserSetting.TelegramToken, user.UserSetting.TelegramGroup));
            }

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