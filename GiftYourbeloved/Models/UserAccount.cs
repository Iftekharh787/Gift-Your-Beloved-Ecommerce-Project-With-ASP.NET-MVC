using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GiftYourbeloved.Models
{
    public class UserAccount
    {
       [Key]
        public int ID { get; set; }

        [Required(ErrorMessage="Name Is Required")]
        public String Name { get; set; }

         [Required(ErrorMessage="UserName Is Required")]
        public String UserName { get; set; }

        
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + 
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email Format Is Invalid")]
        [Required]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage="Please Confirm Your Error Message")  ]
        [DataType(DataType.Password)]
        public String ConfirmPassword { get; set; }
       
    }
}