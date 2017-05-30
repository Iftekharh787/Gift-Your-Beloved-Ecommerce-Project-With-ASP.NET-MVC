using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GiftYourbeloved.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        public virtual List<Productinfo> productInfo { get; set; }
    }
}