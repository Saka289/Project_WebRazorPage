using Lab3.Models;

namespace Lab3.Repository.CategoryRepository
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetAllCategory();
    }
}
