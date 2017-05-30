﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiftYourbeloved.Models;

namespace GiftYourbeloved.Models
{
    public partial class ShoppingCart
    {
        GiftDBContext giftDb = new GiftDBContext();
        //Storedb = giftDb 

        string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Productinfo Productinfo)
        {
            // Get the matching cart and album instances
            var cartItem = giftDb.carts.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.ProductinfoId == Productinfo.ID);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Cart
                {
                    ProductinfoId = Productinfo.ID,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };

                giftDb.carts.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.Count++;
            }

            // Save changes
            giftDb.SaveChanges();
        }


        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = giftDb.carts.Single(
                cart => cart.CartId == ShoppingCartId
                && cart.RecordId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    giftDb.carts.Remove(cartItem);
                }

                // Save changes
                giftDb.SaveChanges();
            }

            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = giftDb.carts.Where(cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                giftDb.carts.Remove(cartItem);
            }

            // Save changes
            giftDb.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return giftDb.carts.Where(cart => cart.CartId == ShoppingCartId).ToList();
        }
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in giftDb.carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();

            // Return 0 if all entries are null
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = (from cartItems in giftDb.carts
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count * cartItems.productinfo.Price).Sum();
            return total ?? decimal.Zero;
        }

        //public double GetTotal()
        //{
        //    // Multiply album price by count of that album to get 
        //    // the current price for each of those albums in the cart
        //    // sum all album price totals to get the cart total
        //    double total = (from cartItems in giftDb.carts
        //                    where cartItems.CartId == ShoppingCartId
        //                    select (int?)cartItems.Count * cartItems.productinfo.Price);
        //    return total;
        //}


        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            // Iterate over the items in the cart, adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    ProductinfoId = item.ProductinfoId,
                    OrderId = order.Id,
                   // UnitPrice = item.productinfo.Price,
                    Quantity = item.Count
                };

               // Set the order total of the shopping cart
              //  orderTotal += (item.Count * item.productinfo.Price);

                giftDb.orderDetails.Add(orderDetail);

            }

            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            // Save the order
            giftDb.SaveChanges();

            // Empty the shopping cart
            EmptyCart();

            // Return the OrderId as the confirmation number
            return order.Id;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();

                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }


        public void MigrateCart(string userName)
        {
            var shoppingCart = giftDb.carts.Where(c => c.CartId == ShoppingCartId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }
            giftDb.SaveChanges();
        }


    }
}