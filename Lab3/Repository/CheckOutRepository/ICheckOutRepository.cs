using Lab3.Models;

namespace Lab3.Repository.CheckOutRepository
{
    public interface ICheckOutRepository
    {
        public Task<bool> DoCheckOut(Order requestOrder, List<CartItem> cartList);
    }
}
