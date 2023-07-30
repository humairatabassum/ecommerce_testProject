using System.ComponentModel.DataAnnotations;

namespace ecommerce_testProject.Models
{
    public class CategoryCreate
    {
        [Required(ErrorMessage = "Name can't be blank")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
