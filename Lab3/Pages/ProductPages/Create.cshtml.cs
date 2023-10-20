using AutoMapper;
using Lab3.Models;
using Lab3.Repository.CategoryRepository;
using Lab3.Repository.ProductRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab3.Pages.ProductPages
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        private readonly ICategoryRepository _categoryRepository;
        public IEnumerable<SelectListItem> categories { get; set; } = new List<SelectListItem>();

        private IMapper _mapper;
        public Product Product { get; set; }
        public CreateModel(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            Product = new Product();
            _mapper = mapper;

        }
        public void OnGet()
        {
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
                _productRepository.AddNewProduct(product);
                TempData["success"] = "Product created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
