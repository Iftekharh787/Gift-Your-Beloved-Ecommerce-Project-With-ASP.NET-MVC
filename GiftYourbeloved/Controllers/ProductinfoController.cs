using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiftYourbeloved.Models;
using System.IO;
using System.Web.UI.WebControls;

namespace GiftYourbeloved.Controllers
{
    public class ProductinfoController : Controller
    {
        private GiftDBContext db = new GiftDBContext();
        //
        // GET: /Productinfo/

        public ActionResult Index()
        {
            var productinfoes = db.Productinfoes.Include(p => p.ProductBrand).Include(p => p.ProductCategory).Include(p => p.Occasion);
            return View(productinfoes.ToList());
        }

        //
        // GET: /Productinfo/Details/5

        public ActionResult Details(int id = 0)
        {
            Productinfo productinfo = db.Productinfoes.Find(id);
            if (productinfo == null)
            {
                return HttpNotFound();
            }
            return View(productinfo);
        }

        //
        // GET: /Productinfo/Create

        public ActionResult Create()
        {
            ViewBag.ProductBrandId = new SelectList(db.productBrand, "Id", "Brand");
            ViewBag.ProductCategoryId = new SelectList(db.productCatagory, "Id", "Category");
            ViewBag.OccasionId = new SelectList(db.occasion, "Id", "ProductOccasion");
            return View();
        }

        //
        // POST: /Productinfo/Create

        [HttpPost]
        public ActionResult Create(Productinfo productinfo)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Name = productinfo.Name;
                db.Productinfoes.Add(productinfo);
                //Session["productinfo_Name_ID"] = productinfo.Name + productinfo.ID; 
                db.SaveChanges();
                Session["productinfo_Name_ID"] = productinfo.Name + db.Productinfoes.Max(x => x.ID);

                return RedirectToAction("PhotoUpload");
            }

            ViewBag.ProductBrandId = new SelectList(db.productBrand, "Id", "Brand", productinfo.ProductBrandId);
            ViewBag.ProductCategoryId = new SelectList(db.productCatagory, "Id", "Category", productinfo.ProductCategoryId);
            ViewBag.OccasionId = new SelectList(db.occasion, "Id", "ProductOccasion", productinfo.OccasionId);
            return View(productinfo);
        }

        public ActionResult PhotoUpload()
        {

            return View();
        }

        [HttpPost]
        public ActionResult PhotoUpload(HttpPostedFileBase file)
        {

            if (file != null && file.ContentLength > 0)
            {

                var fileName = Path.GetFileName(file.FileName);
                var fileType = Path.GetExtension(fileName);
                fileName = Session["productinfo_Name_ID"] + fileType;
                var path = Path.Combine(Server.MapPath("~/Images/Product/"), fileName);
                file.SaveAs(path);
                Session["productinfo_Name_ID"] = null;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }




        //
        // GET: /Productinfo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Productinfo productinfo = db.Productinfoes.Find(id);
            if (productinfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductBrandId = new SelectList(db.productBrand, "Id", "Brand", productinfo.ProductBrandId);
            ViewBag.ProductCategoryId = new SelectList(db.productCatagory, "Id", "Category", productinfo.ProductCategoryId);
            ViewBag.OccasionId = new SelectList(db.occasion, "Id", "ProductOccasion", productinfo.OccasionId);
            return View(productinfo);
        }

        //
        // POST: /Productinfo/Edit/5

        [HttpPost]
        public ActionResult Edit(Productinfo productinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductBrandId = new SelectList(db.productBrand, "Id", "Brand", productinfo.ProductBrandId);
            ViewBag.ProductCategoryId = new SelectList(db.productCatagory, "Id", "Category", productinfo.ProductCategoryId);
            ViewBag.OccasionId = new SelectList(db.occasion, "Id", "ProductOccasion", productinfo.OccasionId);
            return View(productinfo);
        }

        //
        // GET: /Productinfo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Productinfo productinfo = db.Productinfoes.Find(id);
            if (productinfo == null)
            {
                return HttpNotFound();
            }
            return View(productinfo);
        }

        //
        // POST: /Productinfo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Productinfo productinfo = db.Productinfoes.Find(id);
            db.Productinfoes.Remove(productinfo);
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