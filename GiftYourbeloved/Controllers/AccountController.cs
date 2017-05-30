using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiftYourbeloved.Models;
using PagedList;
using PagedList.Mvc;

namespace GiftYourbeloved.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index(int? page)
        {


            using (GiftDBContext db = new GiftDBContext())
            {
                if (Session["UserId"] != null)
                {

                    //return View(db.userAccount.ToList().ToPagedList(page ?? 1, 2));
                }

                return RedirectToAction("RegisterView", "Account");

            }       

           // return RedirectToAction("RegisterView", "Account");




           
        }

        public ActionResult RegisterView()
        {       
            return View();
        }
        [HttpPost]
        public ActionResult RegisterView(UserAccount account)
        {
            if (ModelState.IsValid) 
            {
                using (GiftDBContext db = new GiftDBContext()) {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                //ModelState.Clear();
                //ViewBag.message = account.Name+""+ "Save Succcessfully ";
                return RedirectToAction("Index","Productinfo");
            
            }
            return View();
        }
        public ActionResult logoutview() 
        {
            //ViewData["CartCount"] = 0;
            //Session["RedirectCheckoutPage"] = null;
            ViewData["CartCount"] = 0;
            Session.Clear(); 
            return RedirectToAction("Index", "Productinfo");
        }

        public ActionResult loginView()
        {
            ViewBag.message = "";
            return View();
        }
        [HttpPost]
        public ActionResult loginView(UserAccount user)
        {

            //using( GiftDBContext db = new GiftDBContext() )
            //{
            // //   var usr = db.userAccount.Single(u => u.UserName == user.UserName && u.Password == user.Password);
            //  //  var usr = db.userAccount.Where(u => (u.UserName == user.UserName) && (u.Password == user.Password));
                
            //    //if (usr != null)
            //    //{
            //    //    //Session["UserName"] = 
            //    //    //Session["UserId"] = usr.UserID.ToString();
                    
            //    //    return RedirectToAction("Index");
            //    //}
            //    //else
            //    //{
            //    //    ModelState.AddModelError("", "User Name or Password Is Error");
            //    //}
            //    
            //}


            GiftDBContext db = new GiftDBContext();

            var check = db.userAccount.Any(u => u.UserName == user.UserName && u.Password == user.Password);
          
            if (check)
            {
                var usr = db.userAccount.SingleOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
                Session["UserName"] = usr.UserName.ToString();
                Session["UserId"] = usr.ID.ToString();
                if (Session["ReturnToCheckout"] != null)
                {
                    return RedirectToAction("AddressAndPayment", "Checkout");
                    
                }
                else
                {
                    return RedirectToAction("Index", "Productinfo");
                }
            }
            else {
                ViewBag.message = "Incorrect user name or password!!!";
                return View();
            }
        }
    }
}
