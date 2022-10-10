using Microsoft.AspNetCore.Mvc;
using LearnHowToPlayMusic.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace LearnHowToPlayMusic.Controllers
{
    //[Authorize]//You have to be logged in to enter this website
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //[AllowAnonymous] // You can see the homepage without being logged in
        public IActionResult Index()
        {
            return View();
        }

        //This will make it to where you have to be logged in as a student to access this feature
        //[Authorize(Roles = IdentityHelper.Student)]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}