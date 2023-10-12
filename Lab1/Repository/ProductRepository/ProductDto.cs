namespace Lab1.Repository.ProductRepository
{
    public class ProductDto
    {
        public string ProductName { get; set; } = null!;
        public int? CategoryId { get; set; }
        public string? QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public bool Discontinued { get; set; }
    }
}
