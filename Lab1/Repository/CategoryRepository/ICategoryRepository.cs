using Lab1.Models;

namespace Lab1.Repository.CategoryRepository
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetAllCategory();
    }
}
