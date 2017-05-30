using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GiftYourbeloved.Models
{
    public partial class Order
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Username Is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "FirstName Is Required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address Is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "CityName Is Required")]
        public string City { get; set; }
        [Required(ErrorMessage = "State Is Required")]
        public string State { get; set; }
        [Required(ErrorMessage = "PostalCode Is Required")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Country Is Required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Phone Is Required")]
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Total Is Required")]
        public decimal Total { get; set; }
        public System.DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}