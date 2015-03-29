using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework9.Models;

namespace Homework9.Controllers
{
    public class PastDogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PastDogs
        public ActionResult Index()
        {
            return View(db.PastDogs.ToList());
        }

        // GET: PastDogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PastDogs pastDogs = db.PastDogs.Find(id);
            if (pastDogs == null)
            {
                return HttpNotFound();
            }
            return View(pastDogs);
        }

        // GET: PastDogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PastDogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DogName,Date")] PastDogs pastDogs)
        {
            if (ModelState.IsValid)
            {
                db.PastDogs.Add(pastDogs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pastDogs);
        }

        // GET: PastDogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PastDogs pastDogs = db.PastDogs.Find(id);
            if (pastDogs == null)
            {
                return HttpNotFound();
            }
            return View(pastDogs);
        }

        // POST: PastDogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DogName,Date")] PastDogs pastDogs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pastDogs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pastDogs);
        }

        // GET: PastDogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PastDogs pastDogs = db.PastDogs.Find(id);
            if (pastDogs == null)
            {
                return HttpNotFound();
            }
            return View(pastDogs);
        }

        // POST: PastDogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PastDogs pastDogs = db.PastDogs.Find(id);
            db.PastDogs.Remove(pastDogs);
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
