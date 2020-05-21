using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.IRepo;
using Repository.Models;

namespace CRUDOProject.Controllers
{
    public class AdvertisementsController : Controller
    {
        private readonly IAdvertisementRepo _repo;

        public AdvertisementsController(IAdvertisementRepo repo)
        {
            _repo = repo;
        }

        // GET: Advertisements
        public ActionResult Index()
        {
            var advertisements = _repo.GetAdvertisements();
            return View(advertisements.ToList());
        }
        /*
        // GET: Advertisements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        // GET: Advertisements/Create
        public ActionResult Create()
        {
            ViewBag.InternalUserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Advertisements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,AddTime,InternalUserId")] Advertisement advertisement)
        {
            if (ModelState.IsValid)
            {
                db.Advertisements.Add(advertisement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InternalUserId = new SelectList(db.Users, "Id", "Email", advertisement.InternalUserId);
            return View(advertisement);
        }

        // GET: Advertisements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            ViewBag.InternalUserId = new SelectList(db.Users, "Id", "Email", advertisement.InternalUserId);
            return View(advertisement);
        }

        // POST: Advertisements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,AddTime,InternalUserId")] Advertisement advertisement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advertisement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InternalUserId = new SelectList(db.Users, "Id", "Email", advertisement.InternalUserId);
            return View(advertisement);
        }

        // GET: Advertisements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        // POST: Advertisements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertisement advertisement = db.Advertisements.Find(id);
            db.Advertisements.Remove(advertisement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
        */
    }
}
