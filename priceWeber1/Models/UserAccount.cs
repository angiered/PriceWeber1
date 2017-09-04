using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace priceWeber1.Models
{
    public class UserAccount
    {
        [Key]
       
        //IP address shoudl have been the primary key
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        //email was checked using the most basic format. Additional checks need to be done
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "eMail is not in proper format")]
        public string Email { get; set; }
     //
        public string MyDateTime { get; set; }
        //

        public string MyIPAddress { get; set; }

    }

        

   
}