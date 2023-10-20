using Lab3.Models;

namespace Lab3.Repository.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NorthwindContext _context;

        public CategoryRepository(NorthwindContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _context.Categories.ToList();
        }
    }
}
