namespace Lab3.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total
        {
            get { return Quantity * Price; }
        }
        public string CategoryName { get; set; }

        public CartItem()
        {
        }

        public CartItem(Product product)
        {
            ProductId = product.ProductId;
            ProductName = product.ProductName;
            Price = (double)product.UnitPrice;
            Quantity = 1;
            CategoryName = product.Category.CategoryName;
        }
    }
}
