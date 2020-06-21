using System;
using System.Collections.Generic;
using System.Linq;
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
            if(_items == null)
            {
                _items = await wall.GetItemsAsync(user);
            }
            return View(_items);
        }

        [HttpPost]
        public IActionResult EditPost(VkPostItem item)
        {
            _items.Remove(item);
            return RedirectToAction(nameof(Posts));
        }

        [HttpPost]
        public async Task<IActionResult> PostTelegram(List<VkPostItem> postItems, TelegramPoster poster)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);
            System.Console.WriteLine("Yes");
            CreateBackgroudJob(user, postItems, poster);
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
                        PostFilter = model.PostFilter,
                        PostDeley = model.PostDeley
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

        [HttpGet]
        public async Task<IActionResult> EditPostSetting(int PostSettingId)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);
            PostSetting postSetting = user.PostSettings.FirstOrDefault(p => p.PostSettingId == PostSettingId);

            return View(postSetting);
        }

        [HttpPost]
        public async Task<IActionResult> EditPostSetting(PostSetting model)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);

            _context.EditPostSetting(user, model);
            await _context.SaveAsync();


            return RedirectToAction("About", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> DeletePostSetting(int PostSettingId)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);
            PostSetting currentPostSetting = user.PostSettings.FirstOrDefault(p => p.PostSettingId == PostSettingId);
            _context.DeletePostSetting(user, currentPostSetting);
            await _context.SaveAsync();

            return RedirectToAction("About", "Home");
        }

        private void CreateBackgroudJob(User user, List<VkPostItem> postItems, TelegramPoster poster)
        {
            var timeDelay = TimeSpan.FromSeconds(0);
            foreach(var item in postItems)
            {
                BackgroundJob.Schedule(() => poster.SendPost(item, user.UserSetting.TelegramToken, 
                    user.UserSetting.TelegramGroup), timeDelay);
                timeDelay += TimeSpan.FromSeconds(30);
            }
        }

    }
}