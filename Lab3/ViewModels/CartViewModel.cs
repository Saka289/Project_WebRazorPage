using Lab3.Models;

namespace Lab3.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public double GrandTotal { get; set; }
    }
}
