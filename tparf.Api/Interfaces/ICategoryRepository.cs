using System.Diagnostics.Metrics;
using tparf.Domain.Entites;

namespace tparf.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int categoryId);
        bool CategoryExists(int categoryId);
        bool CreateCategory(Category category);
        public ICollection<Product> GetProductByCategories(int categoryId);
        bool Save();
    }
}
