namespace ProductTaskCRUD.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string? ImageURl { get; set; } = null;
        public DateTime dateOfAddition { get; set; } = DateTime.Now;
    }
}
