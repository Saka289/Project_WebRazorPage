using Lab3.Infrastructure;
using Lab3.Models;
using Lab3.Repository.ProductRepository;
using Lab3.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Pages.ShoppingCart
{

    public class CartModel : PageModel
    {
        public CartViewModel cartViewModel { get; set; }

        private readonly IProductRepository _productRepository;

        public CartModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void OnGet()
        {
            List<CartItem> cartList = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            cartViewModel = new()
            {
                CartItems = cartList,
                GrandTotal = cartList.Sum(x => x.Quantity * x.Price)
            };
        }

        public IActionResult OnGetAdd(int id)
        {
            Product product = _productRepository.GetProductById(id);
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();
            if (cartItem == null)
            {
                cart.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity += 1;
            }
            HttpContext.Session.SetJson("Cart", cart);
            TempData["Success"] = "The product has been added!";
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult OnGetDecrease(long id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();
            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p => p.ProductId == id);
            }
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            TempData["Success"] = "The product has been removed!";
            return RedirectToPage("Cart");
        }

        public IActionResult OnGetRemove(long id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            cart.RemoveAll(p => p.ProductId == id);
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            TempData["Success"] = "The product has been removed!";
            return RedirectToPage("Cart");
        }

        public IActionResult OnGetClear()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToPage("Cart");
        }

    }
}
