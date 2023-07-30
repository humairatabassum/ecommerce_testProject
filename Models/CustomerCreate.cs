using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System.Xml.Linq;

namespace ecommerce_testProject.Models
{
    public class CustomerCreate
    { 
        [Required (ErrorMessage = "Please provide your name first ")]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        [Required (ErrorMessage = "Please provide your Valid Email")]
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set;
        }

    }
}
