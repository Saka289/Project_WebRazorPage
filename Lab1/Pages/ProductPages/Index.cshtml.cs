using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Lab1.Pages.ProductPages
{
    public class IndexModel : PageModel
    {
        public readonly NorthwindContext _context;
        public List<SelectListItem> categories { get; set; } = new List<SelectListItem>();

        public List<Product> products { get; set; } = new List<Product>();

        public IndexModel(NorthwindContext context)
        {
            _context = context;
        }

        public void OnGet(string id)
        {
            categories = _context.Categories.Select(c =>
                              new SelectListItem
                              {
                                  Value = c.CategoryId.ToString(),
                                  Text = c.CategoryName
                              }).ToList();
            products = _context.Products.ToList();
        }

        //[ValidateAntiForgeryToken]
        public IActionResult OnPostCategory()
        {
            int id = Int32.Parse(Request.Form["cateId"].ToString());
            var newProducts = _context.Products.Where(c => c.CategoryId == id).ToList();
            if (id == 0)
            {
                newProducts = _context.Products.ToList();
            }
            return new JsonResult(newProducts);
        }
    }
}
