using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using calu4_t7.Models;
using calu4_t7.ViewModel;

namespace calu4_t7.Controllers
{
    public class SchoolsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Test(int id)
        {
            var school = db.Schools.Where(s => s.Id == id);
            var classes = db.SchoolClasses.Include(s => s.School).Where(c => c.SchoolId == id);

            List<SchoolClassViewModel> lista = new List<SchoolClassViewModel>();
            List<ClassChartViewModel> chart = new List<ClassChartViewModel>();

            foreach(var myClass in classes)
            {
                var recycles = db.Recycles.Include(t => t.RecycleType)
                                            .Where(c => c.SchoolClassId == myClass.Id);

                int finalPoints = 0;
                foreach(var item in recycles)
                {
                    finalPoints += item.Units * item.RecycleType.Points;
                }

                var recyclesMonthly = recycles.Where(c => c.DateStamp.Month.Equals(DateTime.Now.Month - 1));
                int points = 0;
                int plastic = 0;
                int battery = 0;
                int glass = 0;

                foreach (var item in recyclesMonthly)
                {
                    int test = item.DateStamp.Month;
                    points += item.Units * item.RecycleType.Points;
                    switch (item.RecycleTypeId)
                    {
                        case RecycleType.Plastic:
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

                var viewModel = new SchoolClassViewModel
                {
                    SchoolClass = myClass,
                    Points = points,
                    FinalPoints = finalPoints,
                    Plastic = plastic,
                    Glass = glass,
                    Batery = battery

                };
                
                lista.Add(viewModel);
            }

            var viewModel2 = new ClassViewModel
            {
                List = lista,
                School = school.Single(),
                ListChart = Function(id).GetRange(0, 9)
            };

            return View(viewModel2);
        }

        private List<ClassChartViewModel> Function(int id)
        {
            var school = db.Schools.Where(s => s.Id == id);
            var classes = db.SchoolClasses.Include(s => s.School).Where(c => c.SchoolId == id);
            List<Recycle> list = new List<Recycle>();
            List<ClassChartViewModel> listChart = new List<ClassChartViewModel>();
            foreach (var myClass in classes)
            {
                var recycles = db.Recycles.Include(t => t.RecycleType)
                                            .Where(c => c.SchoolClassId == myClass.Id).ToList();
                list.AddRange(recycles);

            }
            bool flag = false;
            int j = 0;
            for (int i = 10; i < 22; i++)
            {
                if (i > 12)
                {
                    if (!flag)
                    {
                        j = 0;
                        flag = true;
                    }
                    j++;
                }
                else
                {
                    j = i;
                }

                int plastika = 0;
                int cans = 0;
                int batteries = 0;
                var listaPla = list.Where(r => r.DateStamp.Month == j && r.RecycleTypeId == RecycleType.Plastic).ToList();
                foreach(var item in listaPla)
                {
                    plastika += item.Units;
                }

                var listaCan = list.Where(r => r.DateStamp.Month == j && r.RecycleTypeId == RecycleType.Battery).ToList();
                foreach (var item in listaCan)
                {
                    cans += item.Units;
                }

                var listaBat = list.Where(r => r.DateStamp.Month == j && r.RecycleTypeId == RecycleType.Glass).ToList();
                foreach (var item in listaBat)
                {
                    batteries += item.Units;
                }

                var viewModel = new ClassChartViewModel
                {
                    Month = j,
                    Plastic = plastika,
                    Cans = cans,
                    Battery = batteries
                };

                listChart.Add(viewModel);
            }
            
            return listChart;
        }

        public ActionResult SchoolTest()
        {
            var schools = db.Schools.ToList();
            List<SchoolViewModel> lista = new List<SchoolViewModel>();
            foreach (var school in schools)
            {
                int points = 0;

                var classes = db.SchoolClasses.Where(c => c.SchoolId == school.Id).ToList();
                foreach (var myClass in classes)
                {
                    var recycles = db.Recycles.Include(t => t.RecycleType)
                                            .Where(c => c.SchoolClassId == myClass.Id);
                    

                    foreach(var item in recycles)
                    {
                        points += item.Units * item.RecycleType.Points;
                    }
                }

                var viewModel = new SchoolViewModel
                {
                    School = school,
                    Points = points
                };
                lista.Add(viewModel);
            }

            return View(lista);
        }

        // GET: Schools
        public ActionResult Index()
        {

            return View(db.Schools.ToList());
        }

        // GET: Schools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // GET: Schools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Address,Name,Municiplaity")] School school)
        {
            if (ModelState.IsValid)
            {
                db.Schools.Add(school);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(school);
        }

        // GET: Schools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // POST: Schools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address,Name,Municiplaity")] School school)
        {
            if (ModelState.IsValid)
            {
                db.Entry(school).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(school);
        }

        // GET: Schools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // POST: Schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            School school = db.Schools.Find(id);
            db.Schools.Remove(school);
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
