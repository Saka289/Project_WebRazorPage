using Lab1.Models;
using Lab1.Repository.CategoryRepository;
using Lab1.Repository.ProductRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;

namespace Lab1.Pages.ProductPages
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IProductRepository _productRepository;

        public IEnumerable<SelectListItem> categories { get; set; } = new List<SelectListItem>();

        public List<Product> products { get; set; } = new List<Product>();

        public IndexModel(NorthwindContext context, ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public void OnGet()
        {

            categories = _categoryRepository.GetAllCategory().Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();
            products = _productRepository.GetAllProduct().ToList();
        }

        //[ValidateAntiForgeryToken]
        public IActionResult OnPostCategory()
        {
            int id = Int32.Parse(Request.Form["cateId"].ToString());
            var newProducts = _productRepository.GetAllProductsFollowCategory(id);
            if (id == 0)
            {
                newProducts = _productRepository.GetAllProduct().ToList();
            }
            return Partial("_ProductTablePartial", newProducts);
            //return new PartialViewResult
            //{
            //    ViewName = "_ProductTablePartial",
            //    ViewData = new ViewDataDictionary<List<Product>>(ViewData, newProducts)
            //};
        }
    }
}
