using SmartBlazor.Data;

namespace SmartBlazor.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetCategories();
        public Category GetCategory(int id);
        public Category CreateCategory(Category obj);
        public Category UpdateCategory(Category obj);
        public bool DeleteCategory(int id);
    }
}
