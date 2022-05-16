using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ArtSkill_03._2.Models;
using Microsoft.EntityFrameworkCore;
using ArtSkill_03._2.Domain;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ArtSkill_03._2.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
    
        private readonly UserManager<IdentityUser> userManager;
            private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signinMgr)
            {
                userManager = userMgr;
                signInManager = signinMgr;
            }

        [AllowAnonymous]
        public IActionResult Register(string returnUrl)
        {
             ViewBag.returnUrl = returnUrl;
                return View(new RegisterViewModel());
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser identityUser = new IdentityUser { Email = model.Email, UserName = model.Email };
                // добавляем пользователя
                var result = await userManager.CreateAsync(identityUser, model.userPassword);
                if (result.Succeeded)
                {
                    // установка куки
                    await signInManager.SignInAsync(identityUser, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [AllowAnonymous]
            public IActionResult Login(string returnUrl)
            {
                ViewBag.returnUrl = returnUrl;
                return View(new LoginViewModel());
            }
            [HttpPost]
            [AllowAnonymous]
            public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
            {
                if (ModelState.IsValid)
                {
                    IdentityUser identityUser = await userManager.FindByNameAsync(model.UserName);
                    if (identityUser != null)
                    {
                        await signInManager.SignOutAsync();
                        Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(identityUser, model.userPassword, model.RememberMe, false);
                        if (result.Succeeded)
                        {
                            return Redirect(returnUrl ?? "/");
                        }
                    }
                    ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль");
                }
                return View(model);
            }

        [Authorize]
            public async Task<IActionResult> Logout()
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
        }
    }
}
