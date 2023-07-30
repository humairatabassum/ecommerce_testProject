using System.ComponentModel.DataAnnotations;

namespace ecommerce_testProject.Models
{
    public class CustomerEditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide Your Name")]
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please provide a valid email")]
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }


    }
}
