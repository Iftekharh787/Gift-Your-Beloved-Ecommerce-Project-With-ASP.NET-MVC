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
    public class ProductSoldController : Controller
    {
        private GiftDBContext db = new GiftDBContext();

         //
        // GET: /ProductSold/

        public ActionResult Index()
        {
            var carts = db.carts.Include(c => c.productinfo);
            return View(carts.ToList());
        }

        //
        // GET: /ProductSold/Details/5

        public ActionResult Details(int id = 0)
        {
            Cart cart = db.carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        //
        // GET: /ProductSold/Create

        public ActionResult Create()
        {
            ViewBag.ProductinfoId = new SelectList(db.Productinfoes, "ID", "Name");
            return View();
        }

        //
        // POST: /ProductSold/Create

        [HttpPost]
        public ActionResult Create(Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductinfoId = new SelectList(db.Productinfoes, "ID", "Name", cart.ProductinfoId);
            return View(cart);
        }

        //
        // GET: /ProductSold/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cart cart = db.carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductinfoId = new SelectList(db.Productinfoes, "ID", "Name", cart.ProductinfoId);
            return View(cart);
        }

        //
        // POST: /ProductSold/Edit/5

        [HttpPost]
        public ActionResult Edit(Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductinfoId = new SelectList(db.Productinfoes, "ID", "Name", cart.ProductinfoId);
            return View(cart);
        }

        //
        // GET: /ProductSold/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cart cart = db.carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        //
        // POST: /ProductSold/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.carts.Find(id);
            db.carts.Remove(cart);
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