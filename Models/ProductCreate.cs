using System.ComponentModel.DataAnnotations;

namespace ecommerce_testProject.Models
{
    public class ProductCreate
    {
        [Required(ErrorMessage = "Name can't be blank")]
        public string Name { get; set; }
        public string Description { get; set; }

        public string Color { get; set; }
        public string Size { get; set; }

        [Required(ErrorMessage = "Price can't be empty")]
        public int Price { get; set; }
    }
}
