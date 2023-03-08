using Shop_Online.Models;

namespace Shop_Online.Services
{
    public class CategoryService
    {
        private readonly ShopOnlineContext _db = new ShopOnlineContext();

        public CategoryService()
        {

        }

        public CategoryService(ShopOnlineContext db)
        {
            _db = db;
        }

        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }
    }
}
