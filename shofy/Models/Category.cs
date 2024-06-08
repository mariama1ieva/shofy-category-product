namespace shofy.Models
{
    public class Category : BaseEntity
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
