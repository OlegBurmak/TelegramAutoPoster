using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAPoster.Models;
using TAPoster.PosterLogic;

namespace TAPoster.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        
        private IUserRepository _context;

        public PostController(IUserRepository context)
        {
            _context = context;
            
        }

        public async Task<IActionResult> Posts(VkWall wall)
        {
            List<VkPostItem> items = new List<VkPostItem>();
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);
            if(user.VkPostItems.Count() <= 0)
            {
                await AddVkPosItems(wall);
            }
            return View(user.VkPostItems);
        }

        public async Task<IActionResult> PostTelegram(TelegramPoster poster)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);
            System.Console.WriteLine("Yes");
            await CreateBackgroudJob(user, poster);
            return RedirectToAction("About", "Home");
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

        [HttpGet]
        public IActionResult AddPostItem() => View();

        [HttpPost]
        public async Task<IActionResult> AddPostItem(VkPostItem item)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);
            await _context.AddPostItem(user, item);
            await _context.SaveAsync();
            return RedirectToAction(nameof(Posts));
        }

        [HttpGet]
        public async Task<IActionResult> EditPostItem(int postItemId)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);
            VkPostItem currentPostItem = user.VkPostItems.FirstOrDefault(p => p.VkPostItemId == postItemId);

            return View(currentPostItem);
        }

        [HttpPost]
        public async Task<IActionResult> EditPostItem(VkPostItem item)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);
            await _context.EditPostItem(user, item);
            await _context.SaveAsync();
            return RedirectToAction(nameof(Posts));
        }

        public async Task<IActionResult> DeletePostItem(int postItemId)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);
            VkPostItem currentPostItem = user.VkPostItems.FirstOrDefault(p => p.VkPostItemId == postItemId);
            await _context.DeletePostItem(user, currentPostItem);
            await _context.SaveAsync();
            return RedirectToAction(nameof(Posts));
        }

        public async Task<IActionResult> DeletePostItemAll()
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);
            await _context.DeletePostItemsAsync(user, user.VkPostItems.Count());
            await _context.SaveAsync();

            return RedirectToAction("About", "Home");
        }

        private async Task CreateBackgroudJob(User user, TelegramPoster poster)
        {
            var timeDelay = TimeSpan.FromMinutes(0);
            int countItems = 0;
            foreach(var item in user.VkPostItems)
            {
                System.Console.WriteLine(item.Text);
                BackgroundJob.Schedule(() => poster.SendPost(item, user.UserSetting), timeDelay);
                timeDelay += TimeSpan.FromMinutes(user.UserSetting.Deley);
                countItems++;
            }
            await _context.DeletePostItemsAsync(user, countItems);
            await _context.SaveAsync();
        }

        private async Task AddVkPosItems(VkWall wall)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);
            List<VkPostItem> items = await wall.GetItemsAsync(user);
            await _context.AddPostItemRange(user, items);
            await _context.SaveAsync();
        }

    }
}