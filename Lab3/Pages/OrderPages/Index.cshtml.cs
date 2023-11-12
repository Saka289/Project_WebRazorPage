using Lab3.Repository.OrderRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3.Pages.OrderPages
{
    public class IndexModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

        public List<OrderDto> Orders { get; set; }

        public PaginatedList<OrderDto> OrderPaging { get; set; }

        public IndexModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void OnGet(int? pageIndex)
        {
            int pageSize = 10;
            OrderPaging = PaginatedList<OrderDto>.Create(_orderRepository.GetAllOrder(), pageIndex ?? 1, pageSize);
            Orders = OrderPaging;
        }
    }
}
