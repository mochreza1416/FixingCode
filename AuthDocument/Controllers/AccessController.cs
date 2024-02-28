using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using AuthDocument.Models;
using AuthDocument.Service;
using Microsoft.EntityFrameworkCore;

namespace AuthDocument.Controllers
{
    public class AccessController : Controller
    {
        IAccessService _accessService = null;
        public AccessController(IAccessService access)
        {
            _accessService = access;
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimsPrincipal = HttpContext.User;
            if(claimsPrincipal.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User login)
        {
            string result = await _accessService.Login(login);
            if (result == "Success")
            {
                List<Claim> claims = new List<Claim>(){
                    new Claim(ClaimTypes.NameIdentifier, login.Email),
                    new Claim("Role","Manager")
                };
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = true
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), properties);
                return RedirectToAction("Index", "Home");
            }
            ViewData["ValidateMessage"] = "User not found";
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User login)
        {
            string result = await _accessService.Register(login);
            if (result == "Success")
                return RedirectToAction("Login", "Access");

            ViewData["ValidateMessage"] = "Password does not meet requirements.";
            return View();
        }
        
    }
}
