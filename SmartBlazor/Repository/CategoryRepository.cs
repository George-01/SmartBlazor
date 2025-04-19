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

        public IEnumerable<Category> GetCategories()
        {
            return _db.Category.ToList();
        }

        public Category GetCategory(int id)
        {
            return _db.Category.FirstOrDefault(c => c.Id == id)!;
        }

        public Category CreateCategory(Category obj)
        {
            _db.Category.Add(obj);
            _db.SaveChanges();
            return obj;
        }

        public Category UpdateCategory(Category obj)
        {
            var objectToUpdate = _db.Category.FirstOrDefault(c =>c.Id == obj.Id);
            if (objectToUpdate == null)
            {
                return obj;
            }

            objectToUpdate.Name = obj.Name;
            _db.Category.Update(objectToUpdate);
            _db.SaveChanges();
            return objectToUpdate;

        }

        public bool DeleteCategory(int id)
        {
            var existingCategory = _db.Category.FirstOrDefault(c => c.Id == id);
            if (existingCategory == null)
            {
                return false;
            }
            _db.Category.Remove(existingCategory);
            return _db.SaveChanges() > 0;
        }
    }
}
