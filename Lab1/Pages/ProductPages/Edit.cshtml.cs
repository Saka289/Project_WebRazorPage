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
    public class EditModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        private readonly ICategoryRepository _categoryRepository;
        public IEnumerable<SelectListItem> categories { get; set; } = new List<SelectListItem>();

        public List<Product> products { get; set; } = new List<Product>();

        private IMapper _mapper;
        public Product Product { get; set; }
        public EditModel(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            Product = new Product();
            _mapper = mapper;

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
            if (ModelState.IsValid)
            {
                ProductDto product = _mapper.Map<ProductDto>(Product);
                _productRepository.UpdateProduct(Product.ProductId, product);
                TempData["success"] = "Product update successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
