using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAPoster.Models;

namespace TAPoster.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _context;

        public AccountController(IUserRepository context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Login() => View();


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                User user = await  _context.Users.FirstOrDefaultAsync(u => u.Name == model.Name && u.Password == model.Password);
                if(user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");

                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == model.Name);
                if(user == null)
                {
                    user = new User
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Password = model.Password
                    };

                    _context.Add(user);
                    await _context.SaveAsync();

                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                else{
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> EditSetting(UserSettingAddModel model)
        {
            if(ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => 
                    u.Name == User.Identity.Name);
                
                user.UserSetting = new UserSetting
                {
                    VkToken = model.VkToken,
                    VkApiVersion = model.VkApiVersion,
                    TelegramGroup = model.TelegramGroup,
                    TelegramToken = model.TelegramToken
                };

                await _context.EditSettingAsync(user);
                await _context.SaveAsync();
                
                return RedirectToAction("About", "Home");

            }
            return View(model);
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim> 
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, 
            ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    }
}