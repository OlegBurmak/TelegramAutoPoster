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
            await AddVkPosItems(wall);
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == User.Identity.Name);
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
            await _context.DeletePostItemAsync(user, countItems);
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