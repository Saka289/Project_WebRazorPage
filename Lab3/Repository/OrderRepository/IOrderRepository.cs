using Lab3.Models;

namespace Lab3.Repository.OrderRepository
{
    public interface IOrderRepository
    {
        public List<OrderDto> GetAllOrder();
    }
}
