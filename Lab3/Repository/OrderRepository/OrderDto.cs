using Lab3.Models;

namespace Lab3.Repository.OrderRepository
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipCountry { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
