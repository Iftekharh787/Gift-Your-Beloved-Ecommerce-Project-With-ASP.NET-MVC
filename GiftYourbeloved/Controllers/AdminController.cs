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
    public class AdminController : Controller
    {
        private GiftDBContext db = new GiftDBContext();

        //
        // GET: /Admin/
        public ActionResult Index()
        {
            if (Session["AdminUserName"] != null)
            {
                return View(db.admin.ToList());
            }
            else
            {
                return RedirectToAction("loginView", "Account");
            }
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id = 0)
        {
            Admin admin = db.admin.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin); 
        }

        // GET : Admin LogIn 

        public ActionResult Adminlogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adminlogin(Admin admin)
        {

            GiftDBContext db = new GiftDBContext();

            var check = db.admin.Any(u => u.UserName == admin.UserName && u.Password == admin.Password);
            if (check)
            {
                var admins = db.admin.SingleOrDefault(u => u.UserName == admin.UserName && u.Password == admin.Password);
                Session["AdminUserName"] = admins.UserName.ToString();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Incorrect user name or password!!!";
                return View();
            }
            return View();
        }



        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            if (Session["AdminUserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("loginView", "Account");
            }
            
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.admin.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (Session["AdminUserName"] != null)
            {
                Admin admin = db.admin.Find(id);
                if (admin == null)
                {
                    return HttpNotFound();
                }
                return View(admin);
            }
            else
            {
                return RedirectToAction("loginView", "Account");
            }

            
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Admin admin = db.admin.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.admin.Find(id);
            db.admin.Remove(admin);
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