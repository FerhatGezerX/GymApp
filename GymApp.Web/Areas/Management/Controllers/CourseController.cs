using GymApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Web.Areas.Management.Controllers; 
public class CourseController : Controller {
    GymDbContext db = new GymDbContext();
    // GET: CourseController
    public ActionResult Index() {
        var courses = db.Courses
            .Where(c => c.Deleted == false)
            .Include(x => x.Trainer).Include("Category")
            .ToList();
        return View(courses);
    }

    // GET: CourseController/Details/5
    public ActionResult Details(int id) {
        return View();
    }

    // GET: CourseController/Create
    public ActionResult Create() {
        ViewBag.TrainerId = new SelectList(db.Trainers
            .Where(x => x.Deleted == false && x.Status), "Id", "FullName", null);
        ViewBag.CategoryId = new SelectList(db.Categories
            .Where(x => x.Deleted == false && x.Status), "Id", "Title", null); 
        return View();
    }

    // POST: CourseController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Course model) {
        try {
            if (ModelState.IsValid) {
                model.Status = true;
                model.Deleted = false;
                model.CreatedDate = DateTime.Now;
                model.CreatedBy = 0;
                db.Courses.Add(model);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.TrainerId = new SelectList(db.Trainers
            .Where(x => x.Deleted == false && x.Status), "Id", "FullName", model.TrainerId);
            ViewBag.CategoryId = new SelectList(db.Categories
                .Where(x => x.Deleted == false && x.Status), "Id", "Title", model.CategoryId);
            return View(model);
        }
        catch {
            return View(model);
        }
    }

    // GET: CourseController/Edit/5
    public ActionResult Edit(int id) {
        var course = db.Courses.Find(id);
        if (course == null) {
            return RedirectToAction(nameof(Index));
        }
        ViewBag.TrainerId = new SelectList(db.Trainers
          .Where(x => x.Deleted == false && x.Status), "Id", "FullName", course.TrainerId);
        ViewBag.CategoryId = new SelectList(db.Categories
            .Where(x => x.Deleted == false && x.Status), "Id", "Title", course.CategoryId);

        return View(course);
    }

    // POST: CourseController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Course model) {
        try {
            if (ModelState.IsValid) {
                var editCourse = db.Courses.Find(model.Id);
                if (editCourse == null) {
                    return View(model);
                }
                editCourse.UpdatedDate = DateTime.Now;
                editCourse.UpdatedBy = 0;
                editCourse.EndTime = model.EndTime;
                editCourse.CategoryId = model.CategoryId;
                editCourse.Status = model.Status;
                editCourse.TrainerId = model.TrainerId;
                editCourse.StartTime = model.StartTime;
                editCourse.UserCount = model.UserCount;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TrainerId = new SelectList(db.Trainers
          .Where(x => x.Deleted == false && x.Status), "Id", "FullName", model.TrainerId);
            ViewBag.CategoryId = new SelectList(db.Categories
                .Where(x => x.Deleted == false && x.Status), "Id", "Title", model.CategoryId);

            return View(model);
        }
        catch {
            return View(model);
        }
    }

    // GET: CourseController/Delete/5
    public ActionResult Delete(int id) {
        return View();
    }

    // POST: CourseController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection) {
        try {
            return RedirectToAction(nameof(Index));
        }
        catch {
            return View();
        }
    }
}
