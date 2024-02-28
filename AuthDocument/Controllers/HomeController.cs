using AuthDocument.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using AuthDocument.Service;

namespace AuthDocument.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IHomeService _homeService = null;

        private readonly ILogger<HomeController> _logger;

        public HomeController(IHomeService home,ILogger<HomeController> logger)
        {
            _logger = logger;
            _homeService = home;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _homeService.GetListDocument();
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","Access");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            // Validate file type and size
            if (file == null || file.Length <= 0)
            {
                ViewData["ValidateMessage"] = "Invalid file.";
            }
            var result = await _homeService.Upload(file);
            if (result == "Success")
                ViewData["ValidateMessage"] = "Document uploaded successfully.";
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Download(int DocumentId)
        {
            var result = await _homeService.GetDocument(DocumentId);
            return File(result.FileData, result.FileType, result.FileName);
        }
    }
}
