using AutoMapper;
using Lab1.Models;
using Lab1.Repository.CategoryRepository;
using Lab1.Repository.ProductRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab1.Pages.ProductPages
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        private readonly ICategoryRepository _categoryRepository;
        public IEnumerable<SelectListItem> categories { get; set; } = new List<SelectListItem>();

        public List<Product> products { get; set; } = new List<Product>();
        public Product Product { get; set; }
        public DeleteModel(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            Product = new Product();

        }

        public void OnGet(int id)
        {
            Product = _productRepository.GetProductById(id);
            categories = _categoryRepository.GetAllCategory().Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();
        }

        public IActionResult OnPost()
        {
            int id = Product.ProductId;
            if (_productRepository.ChecKDeleteProduct(id))
            {
                _productRepository.DeleteProduct(id);
                TempData["success"] = "Product delete successfully";
                return RedirectToPage("Index");
            }
            else
            {
                TempData["error"] = "Product can't delete";
                return RedirectToPage("Index");
            }
        }
    }
}
