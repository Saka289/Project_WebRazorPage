using Lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Repository.CategoryRepository
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
