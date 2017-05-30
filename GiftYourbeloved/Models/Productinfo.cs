using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GiftYourbeloved.Models
{
    public class Productinfo
    {

        [Key]
        public int ID { get; set; }
        public String Name { get; set; }
        public int ProductBrandId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductCategoryId { get; set; }
        public int OccasionId { get; set; }
        public string Description { get; set; }
        public string Person_tag { get; set; }       
        public string age_tag { get; set; }


        public virtual ProductBrand ProductBrand { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual Occasion Occasion {get; set;}
        public virtual List<OrderDetail> OrderDetails { get; set; }


    }
}