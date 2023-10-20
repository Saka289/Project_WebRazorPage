using Lab3.Infrastructure;
using Lab3.Models;
using Lab3.Repository.CheckOutRepository;
using Lab3.Repository.ShiperRepository;
using Lab3.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab3.Pages.ShoppingCart
{
    [BindProperties]
    public class CheckOutModel : PageModel
    {
        private readonly IShipperRepository _shipperRepository;

        private readonly ICheckOutRepository _checkOutRepository;

        public Order Order { get; set; }

        public CartViewModel cartViewModel { get; set; }

        public IEnumerable<SelectListItem> ShipVia { get; set; } = new List<SelectListItem>();

        public CheckOutModel(IShipperRepository shipperRepository, ICheckOutRepository checkOutRepository)
        {
            Order = new Order();
            _shipperRepository = shipperRepository;
            _checkOutRepository = checkOutRepository;
        }

        public void OnGet()
        {
            List<CartItem> cartList = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            cartViewModel = new()
            {
                CartItems = cartList,
                GrandTotal = cartList.Sum(x => x.Quantity * x.Price)
            };
            ShipVia = _shipperRepository.GetAllShipper().Select(s => new SelectListItem
            {
                Text = s.CompanyName,
                Value = s.ShipperId.ToString()

            });
        }

        public async Task<IActionResult> OnPost()
        {
            List<CartItem> cartList = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            if (await _checkOutRepository.DoCheckOut(Order, cartList))
            {
                TempData["Success"] = "Order Success !!!";
                HttpContext.Session.Remove("Cart");
                return RedirectToPage("/ProductPages/Index");
            }
            TempData["Error"] = "Order Failed !!!";
            return RedirectToPage("CheckOut");
        }
    }
}
