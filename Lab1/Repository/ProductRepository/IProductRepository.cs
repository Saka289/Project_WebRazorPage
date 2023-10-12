using Lab1.Models;

namespace Lab1.Repository.ProductRepository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProduct();

        public Product GetProductById(int id);

        public void AddNewProduct(ProductDto requestProductDto);

        public void DeleteProduct(int id);

        public void UpdateProduct(int id, ProductDto requestProductDto);

        public IEnumerable<Product> GetAllProductsFollowCategory(int id);

        public bool ChecKDeleteProduct(int id);
    }
}
