using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using calu4_t7.Enum;
using calu4_t7.Models;
using calu4_t7.ViewModel;

namespace calu4_t7.Controllers
{
    public class SchoolClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Test(int id)
        {
            var schoolClass = db.SchoolClasses.Include(s => s.School).Where(s => s.Id == id).Single();
            var recycles = db.Recycles.Include(t => t.RecycleType).Where(c => c.SchoolClassId == id).ToList();

            int points = 0;
            int plastic = 0;
            int battery = 0;
            int glass = 0;
            foreach (var item in recycles)
            {
                points += item.Units * item.RecycleType.Points;
                switch (item.RecycleTypeId)
                {
                    case (int)RecycleTypeEnum.Type.Plastic:
                        plastic += item.Units;
                        break;
                    case RecycleType.Battery:
                        battery += item.Units;
                        break;
                    case RecycleType.Glass:
                        glass += item.Units;
                        break;

                    default:
                        break;

                }                
            }

            Console.WriteLine(String.Format("{0} {1} {2} {3}",points, glass, plastic, battery));

            var viewModel = new RecycleClassViewModel
            {
                SchoolClass = schoolClass,
                //Recycles = recycles,
                Points = points

            };

            return View();
        }

        // GET: SchoolClasses
        public ActionResult Index()
        {
            var schoolClasses = db.SchoolClasses.Include(s => s.School);
            return View(schoolClasses.ToList());
        }

        // GET: SchoolClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolClass schoolClass = db.SchoolClasses.Find(id);
            if (schoolClass == null)
            {
                return HttpNotFound();
            }
            return View(schoolClass);
        }

        // GET: SchoolClasses/Create
        public ActionResult Create()
        {
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "Address");
            return View();
        }

        // POST: SchoolClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SchoolId")] SchoolClass schoolClass)
        {
            if (ModelState.IsValid)
            {
                db.SchoolClasses.Add(schoolClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "Address", schoolClass.SchoolId);
            return View(schoolClass);
        }

        // GET: SchoolClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolClass schoolClass = db.SchoolClasses.Find(id);
            if (schoolClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "Address", schoolClass.SchoolId);
            return View(schoolClass);
        }

        // POST: SchoolClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SchoolId")] SchoolClass schoolClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schoolClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "Address", schoolClass.SchoolId);
            return View(schoolClass);
        }

        // GET: SchoolClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolClass schoolClass = db.SchoolClasses.Find(id);
            if (schoolClass == null)
            {
                return HttpNotFound();
            }
            return View(schoolClass);
        }

        // POST: SchoolClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SchoolClass schoolClass = db.SchoolClasses.Find(id);
            db.SchoolClasses.Remove(schoolClass);
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
