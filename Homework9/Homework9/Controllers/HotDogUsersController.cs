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
    public class HotDogUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HotDogUsers
        public ActionResult Index()
        {

            IEnumerable<SelectListItem> pastdogs = db.PastDogs
             .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.DogName
                });
            ViewBag.PastDogs = pastdogs;
            return View(db.HotDogUsers.ToList());
        }

        // GET: HotDogUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotDogUser hotDogUser = db.HotDogUsers.Find(id);
            if (hotDogUser == null)
            {
                return HttpNotFound();
            }
            return View(hotDogUser);
        }

        // GET: HotDogUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotDogUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Bio,FavoriteDog,PastDog")] HotDogUser hotDogUser)
        {
            IEnumerable<SelectListItem> pastdogs = db.PastDogs
            .Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.DogName
            });
            ViewBag.PastDogs = pastdogs;
            if (ModelState.IsValid)
            {
                db.HotDogUsers.Add(hotDogUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotDogUser);
        }

        // GET: HotDogUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotDogUser hotDogUser = db.HotDogUsers.Find(id);
            if (hotDogUser == null)
            {
                return HttpNotFound();
            }
            return View(hotDogUser);
        }

        // POST: HotDogUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Bio,FavoriteDog,PastDog")] HotDogUser hotDogUser)
        {
            IEnumerable<SelectListItem> pastdogs = db.PastDogs
             .Select(d => new SelectListItem
             {
                 Value = d.Id.ToString(),
                 Text = d.DogName
             });
            ViewBag.PastDogs = pastdogs;
            if (ModelState.IsValid)
            {
                db.Entry(hotDogUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotDogUser);
        }

        // GET: HotDogUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotDogUser hotDogUser = db.HotDogUsers.Find(id);
            if (hotDogUser == null)
            {
                return HttpNotFound();
            }
            return View(hotDogUser);
        }

        // POST: HotDogUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotDogUser hotDogUser = db.HotDogUsers.Find(id);
            db.HotDogUsers.Remove(hotDogUser);
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
