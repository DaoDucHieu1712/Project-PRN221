using Microsoft.EntityFrameworkCore;
using Shop_Online.Models;
using System.Linq;
using System.Security.Cryptography;

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
            List<Product> products;
            try
            {
                products = _db.Products.Include(x =>x.CidNavigation).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return products;
        }

        public List<Product> getProductsAndPaging(string search_name, int pageIndex){
            List<Product> products;
            int pageSize = 4;
            try
            {
                products = _db.Products
                    .Include(x => x.CidNavigation)
                    .Where(x => x.Name.ToUpper().Contains(search_name.ToUpper()))
                    .OrderByDescending(x => x.Id)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public int totalProducts()
        {
            int pageSize = 4;
            int totalPage = (int)Math.Ceiling(_db.Products.Count() / (double)pageSize);
            return totalPage;
        }


        public List<Product> getListProductByCId(int cid)
        {
            List<Product> products;
            try
            {
                products = _db.Products.Where(x => x.Cid == cid).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return products;
        }

        public List<Product> getProductsWithHome(int id)
        {
            List<Product> products;
            try
            {
                products = _db.Products.Where(x => x.Cid == id).Take(4).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public Product GetProductById(int id)
        {
            Product product;
            try
            {
                product = _db.Products.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return product;
        }

        public void create(Product product)
        {
            try
            {
                Product _product = GetProductById(product.Id);
                if (_product == null)
                {
                    _db.Products.Add(product);
                    _db.SaveChanges();
                }
                else
                {
                   throw new Exception("The product is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void update(Product product)
        {
            try
            {
                    _db.Entry<Product>(product).State = EntityState.Modified;
                    _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void delete(Product product)
        {
            try
            {
                    _db.Products.Remove(product);
                    _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

       
    }
}
