using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GiftYourbeloved.Models
{
    public class ProductBrand
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public virtual List<Productinfo> productInfo { get; set; }

        internal bool Contains(string Brand)
        {
            throw new NotImplementedException();
        }
    }
}