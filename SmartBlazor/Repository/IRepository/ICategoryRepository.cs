using SmartBlazor.Data;

namespace SmartBlazor.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetCategories();
        public Task<Category> GetCategory(int id);
        public Task<Category> CreateCategory(Category obj);
        public Task<Category> UpdateCategory(Category obj);
        public Task<bool> DeleteCategory(int id);
    }
}
