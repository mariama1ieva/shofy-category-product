namespace shofy.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string SKU { get; set; }
        public string Color { get; set; }
        public Category Category { get; set; }
        public List<ProductImages> Images { get; set; }



    }
}
