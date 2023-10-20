using Lab3.Models;

namespace Lab3.Repository.ProductRepository
{
    public interface IProductRepository
    {
        public List<Product> GetAllProduct();

        public Product GetProductById(int id);

        public void AddNewProduct(ProductDto requestProductDto);

        public void DeleteProduct(int id);

        public void UpdateProduct(int id, ProductDto requestProductDto);

        public IEnumerable<Product> GetAllProductsFollowCategory(int id);

        public bool ChecKDeleteProduct(int id);
    }
}
