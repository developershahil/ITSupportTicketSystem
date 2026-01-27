using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ITSupport.Models;

namespace ITSupport.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // 🔐 Check login
            var role = HttpContext.Session.GetString("UserRole");

            if (string.IsNullOrEmpty(role))
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Role = role;
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
