using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using GiftYourbeloved.Models;

namespace GiftYourbeloved.Controllers
{
    public class ProductBrandController : Controller
    {
        private GiftDBContext db = new GiftDBContext();

        //
        // GET: /ProductBrand/

        public ActionResult Index()
        {
            return View(db.productBrand.ToList());
        }

        //
        // GET: /ProductBrand/Details/5

        public ActionResult Details(int id = 0)
        {
            ProductBrand productbrand = db.productBrand.Find(id);
            if (productbrand == null)
            {
                return HttpNotFound();
            }
            return View(productbrand);
        }

        //
        // GET: /ProductBrand/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ProductBrand/Create

        [HttpPost]
        public ActionResult Create(ProductBrand productbrand)
        {
            if (ModelState.IsValid)
            {
                db.productBrand.Add(productbrand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productbrand);
        }

        //
        // GET: /ProductBrand/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProductBrand productbrand = db.productBrand.Find(id);
            if (productbrand == null)
            {
                return HttpNotFound();
            }
            return View(productbrand);
        }

        //
        // POST: /ProductBrand/Edit/5

        [HttpPost]
        public ActionResult Edit(ProductBrand productbrand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productbrand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productbrand);
        }

        //
        // GET: /ProductBrand/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ProductBrand productbrand = db.productBrand.Find(id);
            if (productbrand == null)
            {
                return HttpNotFound();
            }
            return View(productbrand);
        }

        //
        // POST: /ProductBrand/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductBrand productbrand = db.productBrand.Find(id);
            db.productBrand.Remove(productbrand);
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