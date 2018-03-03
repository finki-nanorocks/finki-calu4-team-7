using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using calu4_t7.Models;

namespace calu4_t7.Controllers
{
    public class RecyclesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Recycles
        public ActionResult Index()
        {
            var recycles = db.Recycles.Include(r => r.RecycleType).Include(r => r.SchoolClass);
            return View(recycles.ToList());
        }

        // GET: Recycles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recycle recycle = db.Recycles.Find(id);
            if (recycle == null)
            {
                return HttpNotFound();
            }
            return View(recycle);
        }

        // GET: Recycles/Create
        public ActionResult Create()
        {
            ViewBag.RecycleTypeId = new SelectList(db.RecycleTypes, "Id", "Name");
            ViewBag.SchoolClassId = new SelectList(db.SchoolClasses, "Id", "Name");
            return View();
        }

        // POST: Recycles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Units,DateStamp,SchoolClassId,RecycleTypeId")] Recycle recycle)
        {
            if (ModelState.IsValid)
            {
                db.Recycles.Add(recycle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecycleTypeId = new SelectList(db.RecycleTypes, "Id", "Name", recycle.RecycleTypeId);
            ViewBag.SchoolClassId = new SelectList(db.SchoolClasses, "Id", "Name", recycle.SchoolClassId);
            return View(recycle);
        }

        // GET: Recycles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recycle recycle = db.Recycles.Find(id);
            if (recycle == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecycleTypeId = new SelectList(db.RecycleTypes, "Id", "Name", recycle.RecycleTypeId);
            ViewBag.SchoolClassId = new SelectList(db.SchoolClasses, "Id", "Name", recycle.SchoolClassId);
            return View(recycle);
        }

        // POST: Recycles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Units,DateStamp,SchoolClassId,RecycleTypeId")] Recycle recycle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recycle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecycleTypeId = new SelectList(db.RecycleTypes, "Id", "Name", recycle.RecycleTypeId);
            ViewBag.SchoolClassId = new SelectList(db.SchoolClasses, "Id", "Name", recycle.SchoolClassId);
            return View(recycle);
        }

        // GET: Recycles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recycle recycle = db.Recycles.Find(id);
            if (recycle == null)
            {
                return HttpNotFound();
            }
            return View(recycle);
        }

        // POST: Recycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recycle recycle = db.Recycles.Find(id);
            db.Recycles.Remove(recycle);
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
