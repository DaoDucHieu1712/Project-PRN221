using Microsoft.EntityFrameworkCore;
using Shop_Online.Models;
using System.Linq;

namespace Shop_Online.Services
{
    public class ProductService
    {
        private readonly ShopOnlineContext _db = new ShopOnlineContext();

        public ProductService()
        {

        }
        public ProductService(ShopOnlineContext db)
        {
            _db = db;
        }


        public List<Product> GetProducts()
        {
            return _db.Products.ToList();
        }

        public List<Product> getListProductById(int id)
        {
            return _db.Products.Where(x => x.Cid == id).ToList();
        }

        public List<Product> getProductsWithHome(int id)
        {
            return _db.Products.Where(x => x.Cid == id).Take(4).ToList();
        }

        public void create()
        {

        }

        public void update()
        {

        }

        public void delete()
        {

        }

    }
}
