using AutoMapper;
using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Repository.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly NorthwindContext _context;

        private readonly IMapper _mapper;

        public OrderRepository(NorthwindContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<OrderDto> GetAllOrder()
        {
            List<Order> orders = _context.Orders.Include(c => c.Customer).ToList();
            return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
