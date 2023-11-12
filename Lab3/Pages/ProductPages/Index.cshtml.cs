using Lab3.Models;
using Lab3.Repository.ProductRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3.Pages.ProductPages
{
    public class IndexModel : PageModel
    {

        private readonly IProductRepository _productRepository;

        public List<Product> products { get; set; }

        public PaginatedList<Product> ProductPaging { get; set; }

        public IndexModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            products = new List<Product>();
        }

        public void OnGet(int? pageIndex)
        {
            int pageSize = 10;
            ProductPaging = PaginatedList<Product>.Create(_productRepository.GetAllProduct(), pageIndex ?? 1, pageSize);
            products = ProductPaging;
        }
    }
}
