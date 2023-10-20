using Lab3.Infrastructure;
using Lab3.Models;
using System.Collections.Generic;

namespace Lab3.Repository.CheckOutRepository
{
    public class CheckOutRepository : ICheckOutRepository
    {
        private readonly NorthwindContext _context;

        public CheckOutRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<bool> DoCheckOut(Order requestOrder, List<CartItem> cartList)
        {
            if (requestOrder != null)
            {
                Order newOrder = new Order()
                {
                    CustomerId = "WOLZA",
                    EmployeeId = 6,
                    OrderDate = DateTime.Now,
                    RequiredDate = (DateTime.Now).AddDays(10),
                    ShippedDate = (DateTime.Now).AddMonths(1),
                    ShipVia = requestOrder.ShipVia,
                    Freight = 10,
                    ShipName = requestOrder.ShipName,
                    ShipAddress = requestOrder.ShipAddress,
                    ShipCity = requestOrder.ShipCity,
                    ShipRegion = null,
                    ShipPostalCode = "1001",
                    ShipCountry = requestOrder.ShipCountry,
                };
                await _context.Orders.AddAsync(newOrder);
                await _context.SaveChangesAsync();
                foreach (var item in cartList)
                {
                    OrderDetail orderDetail = new OrderDetail
                    {
                        OrderId = newOrder.OrderId,
                        ProductId = item.ProductId,
                        UnitPrice = (decimal)item.Price,
                        Quantity = (short)item.Quantity,
                        Discount = 0,
                    };
                    await _context.OrderDetails.AddAsync(orderDetail);
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
