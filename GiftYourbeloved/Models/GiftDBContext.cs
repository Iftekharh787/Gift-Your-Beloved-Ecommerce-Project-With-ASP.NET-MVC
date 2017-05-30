using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GiftYourbeloved.Models
{
    public class GiftDBContext : DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }
        public DbSet<Productinfo> Productinfoes { get; set; }
        public DbSet<Occasion> occasion { get; set; }
        public DbSet<ProductBrand> productBrand { get; set; }
        public DbSet<ProductCategory> productCatagory { get; set; }
        public DbSet<Admin> admin { get; set; }


        public DbSet<Cart> carts { get; set; }
        public DbSet<Order> orders { get; set; } 
        public DbSet<OrderDetail> orderDetails { get; set; }

    }
}