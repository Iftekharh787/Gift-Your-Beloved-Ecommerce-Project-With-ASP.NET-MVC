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
    public class RecommandProductSearchController : Controller
    {
        private GiftDBContext db = new GiftDBContext();

        //
        // GET: /RecommandProductSearch/

        public ActionResult Index()
        {
            var productinfoes = db.Productinfoes.Include(p => p.ProductBrand).Include(p => p.ProductCategory).Include(p => p.Occasion);
            return View(productinfoes.ToList());
        }

        [HttpPost]
        public ActionResult SearchByName(string SerchProductname)
        {

            return View(db.Productinfoes.Where(v => v.Name.Contains(SerchProductname)));
        }

        [HttpPost]
        public ActionResult SearchByPrice(decimal lowPrice, decimal highPrice)
        {
            if (lowPrice != null && highPrice != null)
            {
                return View(db.Productinfoes.Where(v => (v.Price >= lowPrice) && (v.Price <= highPrice)));
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult SearchByBrand(int Brand)
        {
            //return View();

            return View(db.Productinfoes.Where(v => v.ProductBrandId.Equals(Brand)));

            //return View(db.Productinfoes.Where(v => v.ProductBrand.Contains(Brand)));
        }

        [HttpPost]
        public ActionResult SearchByCatagory(int Catagory)
        {
            return View(db.Productinfoes.Where(v => v.ProductCategoryId.Equals(Catagory)));

        }

        [HttpPost]
        public ActionResult SearchByOccasion(int occasion)
        {

            return View(db.Productinfoes.Where(v => v.OccasionId.Equals(occasion)));

        }




        ////
        //// GET: /RecommandProductSearch/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    Productinfo productinfo = db.Productinfoes.Find(id);
        //    if (productinfo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(productinfo);
        //}

        ////
        //// GET: /RecommandProductSearch/Create

        //public ActionResult Create()
        //{
        //    ViewBag.ProductBrandId = new SelectList(db.productBrand, "Id", "Brand");
        //    ViewBag.ProductCategoryId = new SelectList(db.productCatagory, "Id", "Category");
        //    ViewBag.OccasionId = new SelectList(db.occasion, "Id", "ProductOccasion");
        //    return View();
        //}

        ////
        //// POST: /RecommandProductSearch/Create

        //[HttpPost]
        //public ActionResult Create(Productinfo productinfo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Productinfoes.Add(productinfo);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ProductBrandId = new SelectList(db.productBrand, "Id", "Brand", productinfo.ProductBrandId);
        //    ViewBag.ProductCategoryId = new SelectList(db.productCatagory, "Id", "Category", productinfo.ProductCategoryId);
        //    ViewBag.OccasionId = new SelectList(db.occasion, "Id", "ProductOccasion", productinfo.OccasionId);
        //    return View(productinfo);
        //}

        ////
        //// GET: /RecommandProductSearch/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    Productinfo productinfo = db.Productinfoes.Find(id);
        //    if (productinfo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ProductBrandId = new SelectList(db.productBrand, "Id", "Brand", productinfo.ProductBrandId);
        //    ViewBag.ProductCategoryId = new SelectList(db.productCatagory, "Id", "Category", productinfo.ProductCategoryId);
        //    ViewBag.OccasionId = new SelectList(db.occasion, "Id", "ProductOccasion", productinfo.OccasionId);
        //    return View(productinfo);
        //}

        ////
        //// POST: /RecommandProductSearch/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Productinfo productinfo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(productinfo).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ProductBrandId = new SelectList(db.productBrand, "Id", "Brand", productinfo.ProductBrandId);
        //    ViewBag.ProductCategoryId = new SelectList(db.productCatagory, "Id", "Category", productinfo.ProductCategoryId);
        //    ViewBag.OccasionId = new SelectList(db.occasion, "Id", "ProductOccasion", productinfo.OccasionId);
        //    return View(productinfo);
        //}

        ////
        //// GET: /RecommandProductSearch/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    Productinfo productinfo = db.Productinfoes.Find(id);
        //    if (productinfo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(productinfo);
        //}

        ////
        //// POST: /RecommandProductSearch/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Productinfo productinfo = db.Productinfoes.Find(id);
        //    db.Productinfoes.Remove(productinfo);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}