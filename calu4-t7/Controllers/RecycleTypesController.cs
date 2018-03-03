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
    public class RecycleTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RecycleTypes
        public ActionResult Index()
        {
            return View(db.RecycleTypes.ToList());
        }

        // GET: RecycleTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecycleType recycleType = db.RecycleTypes.Find(id);
            if (recycleType == null)
            {
                return HttpNotFound();
            }
            return View(recycleType);
        }

        // GET: RecycleTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecycleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Points")] RecycleType recycleType)
        {
            if (ModelState.IsValid)
            {
                db.RecycleTypes.Add(recycleType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recycleType);
        }

        // GET: RecycleTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecycleType recycleType = db.RecycleTypes.Find(id);
            if (recycleType == null)
            {
                return HttpNotFound();
            }
            return View(recycleType);
        }

        // POST: RecycleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Points")] RecycleType recycleType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recycleType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recycleType);
        }

        // GET: RecycleTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecycleType recycleType = db.RecycleTypes.Find(id);
            if (recycleType == null)
            {
                return HttpNotFound();
            }
            return View(recycleType);
        }

        // POST: RecycleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecycleType recycleType = db.RecycleTypes.Find(id);
            db.RecycleTypes.Remove(recycleType);
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
