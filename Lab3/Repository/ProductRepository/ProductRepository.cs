using AutoMapper;
using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly NorthwindContext _context;

        private readonly IMapper _mapper;

        public ProductRepository(NorthwindContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddNewProduct(ProductDto requestProductDto)
        {
            Product product = _mapper.Map<Product>(requestProductDto);
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var queryProduct = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (queryProduct != null)
            {
                _context.Products.Remove(queryProduct);
                _context.SaveChanges();
            }
        }

        public List<Product> GetAllProduct()
        {
            return _context.Products.ToList();
        }


        public Product GetProductById(int id)
        {
            var result = _context.Products.Include(c => c.Category).FirstOrDefault(p => p.ProductId == id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public void UpdateProduct(int id, ProductDto requestProductDto)
        {
            var queryProduct = _context.Products.Find(id);
            if (queryProduct != null)
            {
                _mapper.Map(requestProductDto, queryProduct);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Product> GetAllProductsFollowCategory(int categoryId)
        {
            var queryProduct = _context.Products.Where(p => p.CategoryId == categoryId);
            if (queryProduct != null)
            {
                return queryProduct.ToList();
            }
            return null;
        }

        public bool ChecKDeleteProduct(int id)
        {
            var queryOderDetail = _context.OrderDetails.FirstOrDefault(o => o.ProductId == id);
            if (queryOderDetail == null)
            {
                return true;
            }
            return false;
        }
    }
}
