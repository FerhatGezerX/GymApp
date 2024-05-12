using GymApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Web.Controllers {
    public class LectureController : Controller {
        GymDbContext db = new GymDbContext();
        //kurslar
        public IActionResult Index() {
            var courses = db.Courses
                .Include("Trainer").Include("Category")
                .Where(c => c.Status && c.Deleted == false).ToList();
            return View(courses);
        }

        public IActionResult Trainer() {
            var trainers = db.Trainers.Where(c => c.Status && c.Deleted == false)
                .ToList();
            return View(trainers);
        }
    }
}
