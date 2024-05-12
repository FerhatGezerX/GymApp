using GymApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Web.Controllers {
    public class MemberController : Controller {
        GymDbContext db = new GymDbContext();
        //üyelik
        public IActionResult Index() {
            //kayıt formu
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(User model) {
            //kayıt formu
            //todo: kullanıcı üyeliği alınacak
            return View();
        }

        //paketler
        public IActionResult Pricing() {
            var pricings = db.Pricings
                .Where(c => c.Deleted == false && c.Status).ToList();
            return View(pricings);
        }
    }
}
