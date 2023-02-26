using Shop_Online.Models;
using System.Linq;

namespace Shop_Online.Services
{
    public class ProductService
    {
        private readonly IDatabase _database;

        public ProductService(IDatabase database)
        {
            _database = database;
        }

        public Product GetUserById(int id)
        {
            return _database.GetById<Product>(id);
        }

        public void AddUser(Product product)
        {
            _database.Add(product);
        }

        public void UpdateUser(Product product)
        {
            _database.Update(product);
        }

        public void DeleteUser(Product product)
        {
            _database.Delete(product);
        }
    }
}
