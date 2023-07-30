namespace ecommerce_testProject.Models
{
    public class ProductEditVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public int Price { get; set; }
    }
}
