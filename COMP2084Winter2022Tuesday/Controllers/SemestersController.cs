using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COMP2084Winter2022Tuesday.Models;

namespace COMP2084Winter2022Tuesday.Controllers
{
    public class SemestersController : Controller
    {
        private DataContext db = new DataContext();


        public ActionResult Year(int year) {

            return View();
        }

        public ActionResult Term(int year, string term) {

            return View();
        }

        // GET: Semesters
        public ActionResult Index()
        {
            //LINQ
            /* Language
             * INtergrated
             * Queries
             * 
             * lambda expressions to get information
             * 
             */

            var data = new List<string> { 
            "Ben",
            "Benny",
            "Blanc",
            "Mary",
            "Sally-Sally"
            };

            var result = data.Where(s => s.Length > 4).ToList();


            var modelData = new List<Login> { 
                new Login{ Username = "ben@blanc.ca", Password = "helloworld"},
                new Login{ Username = "b@b.ca", Password = "cool"},
                new Login{ Username = "comp2084@gc.ca", Password = "example"},
            };

            var usernamesGreaterThan3Characters = modelData
                .Where(s => s.Username.Trim().Length > 3 & s.Password.Length > 5)
                .Select(s => s.Username)
                .ToList();

            var semesters = db.Semesters
                .Include(s => s.Cours)
                .Include(s => s.Prof)
                .Include(s => s.Student);

            return View(semesters.ToList());
        }

        // GET: Semesters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester semester = db.Semesters.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }
        /*
         * GET
         * POST
         * 
         * 
         * 
         */
        // GET: Semesters/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode");
            ViewBag.ProfID = new SelectList(db.Profs, "ProfID", "ProfName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName");
            return View();
        }

        // POST: Semesters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SemesterID,Term,Year,ProfID,StudentID,CourseID")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                db.Semesters.Add(semester);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", semester.CourseID);
            ViewBag.ProfID = new SelectList(db.Profs, "ProfID", "ProfName", semester.ProfID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", semester.StudentID);
            return View(semester);
        }

        // GET: Semesters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester semester = db.Semesters.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", semester.CourseID);
            ViewBag.ProfID = new SelectList(db.Profs, "ProfID", "ProfName", semester.ProfID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", semester.StudentID);
            return View(semester);
        }

        // POST: Semesters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SemesterID,Term,Year,ProfID,StudentID,CourseID")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semester).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", semester.CourseID);
            ViewBag.ProfID = new SelectList(db.Profs, "ProfID", "ProfName", semester.ProfID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", semester.StudentID);
            return View(semester);
        }

        // GET: Semesters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester semester = db.Semesters.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }

        // POST: Semesters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Semester semester = db.Semesters.Find(id);
            db.Semesters.Remove(semester);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
