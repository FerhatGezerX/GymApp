using GymApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GymApp.Web.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        GymDbContext db = new GymDbContext();

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            var mainpage = db.MainPages.FirstOrDefault();
            return View(mainpage);
        }

        public IActionResult About() {
            var about = db.Abouts.FirstOrDefault();
            return View(about);
        }

        public IActionResult Contact() {
            var contact = db.Contacts.FirstOrDefault();
            return View(contact);
        }



        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
