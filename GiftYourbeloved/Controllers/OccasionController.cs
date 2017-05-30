using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiftYourbeloved.Models;

namespace GiftYourbeloved.Controllers
{
    public class OccasionController : Controller
    {
        private GiftDBContext db = new GiftDBContext();

        //
        // GET: /Occasion/

        public ActionResult Index()
        {
            return View(db.occasion.ToList());
        }

        //
        // GET: /Occasion/Details/5

        public ActionResult Details(int id = 0)
        {
            Occasion occasion = db.occasion.Find(id);
            if (occasion == null)
            {
                return HttpNotFound();
            }
            return View(occasion);
        }

        //
        // GET: /Occasion/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Occasion/Create

        [HttpPost]
        public ActionResult Create(Occasion occasion)
        {
            if (ModelState.IsValid)
            {
                db.occasion.Add(occasion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(occasion);
        }

        //
        // GET: /Occasion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Occasion occasion = db.occasion.Find(id);
            if (occasion == null)
            {
                return HttpNotFound();
            }
            return View(occasion);
        }

        //
        // POST: /Occasion/Edit/5

        [HttpPost]
        public ActionResult Edit(Occasion occasion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(occasion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(occasion);
        }

        //
        // GET: /Occasion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Occasion occasion = db.occasion.Find(id);
            if (occasion == null)
            {
                return HttpNotFound();
            }
            return View(occasion);
        }

        //
        // POST: /Occasion/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Occasion occasion = db.occasion.Find(id);
            db.occasion.Remove(occasion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}