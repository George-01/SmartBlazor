using Microsoft.EntityFrameworkCore;
using SmartBlazor.Data;
using SmartBlazor.Repository.IRepository;

namespace SmartBlazor.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _db.Category.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            var obj = await _db.Category.FirstOrDefaultAsync(c => c.Id == id);
            if(obj == null)
            {
                return new Category();
            }
            return obj;
        }

        public async Task<Category> CreateCategory(Category obj)
        {
             _db.Category.Add(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<Category> UpdateCategory(Category obj)
        {
            var objectToUpdate = await _db.Category.FirstOrDefaultAsync(c => c.Id == obj.Id);
            if (objectToUpdate == null)
            {
                return obj;
            }

            objectToUpdate.Name = obj.Name;
            _db.Category.Update(objectToUpdate);
            await _db.SaveChangesAsync();
            return objectToUpdate;

        }

        public async Task<bool> DeleteCategory(int id)
        {
            var existingCategory = await _db.Category.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCategory == null)
            {
                return false;
            }
            _db.Category.Remove(existingCategory);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
