namespace shofy.Models
{
    public class ProductImages : BaseEntity
    {
        public string Name { get; set; }
        public bool IsMain { get; set; } = false;
        public int ProductId { get; set; }
    }
}
