using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiftYourbeloved.Models;

namespace GiftYourbeloved.Controllers
{
    //[Authorize]
    public class CheckoutController : Controller
    {
        //
        // GET: /Checkout/
        GiftDBContext db = new GiftDBContext();
        const string PromoCode = "FREE";

        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                return View("AddressAndPayment");
            }
            else
            {
                Session["ReturnToCheckout"] = "Return to CheckOut";
                return RedirectToAction("loginView", "Account");
            }
            
        }

        public ActionResult AddressAndPayment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddressAndPayment(Order order)
        {
           
            if (ModelState.IsValid)
            {
                db.orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Complete");
            }

            return View();

            //var order = new Order();
            //TryUpdateModel(order);
            //try
            //{
            //    if (string.Equals(values["PromoCode"], PromoCode,
            //    StringComparison.OrdinalIgnoreCase) == false)
            //    {
            //        return View(order);
            //    }

            //    else
            //    {
            //        order.Username = User.Identity.Name;
            //        order.OrderDate = DateTime.Now;
            //        //Save Order
            //        db.orders.Add(order);
            //        db.SaveChanges();
            //        //Process the order
            //        var cart = ShoppingCart.GetCart(this.HttpContext);
            //        cart.CreateOrder(order);
            //        return RedirectToAction("Complete",
            //        new { id = order.OrderId });
            //    }
            //}
            //catch
            //{
            //    //Invalid - redisplay with errors
            //    return View(order);
            //}

        }

        //
        // GET: /Checkout/Complete
        public ActionResult Complete()
        {
            return View();
        }




    }
}
