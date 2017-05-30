using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiftYourbeloved.Models
{
    public class Occasion
    {
        public int Id { get; set; }
        public string ProductOccasion { get; set; }

        public virtual List<Productinfo> productInfo { get; set; }
    }
}