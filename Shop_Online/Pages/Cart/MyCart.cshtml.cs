using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop_Online.Models;
using Shop_Online.Services;
using System.Text.Json;

namespace Shop_Online.Pages.Cart
{
    public class MyCartModel : PageModel
    {
        public ProductService productService = new ProductService();
        public IDictionary<int, int> cart { get; set; }
        public int total_Price { get; set; }

        public IDictionary<int, int> getCart()
        {
            string cartJson = HttpContext.Session.GetString("cart");
            cart = JsonSerializer.Deserialize<IDictionary<int, int>>(cartJson);
            return cart;
        }

        public void LoadCart(IDictionary<int, int> cart)
        {
            string newCartJson = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString("cart", newCartJson);
        }

        public void updatePrice()
        {
            foreach (var item in cart)
            {
                var sp = productService.GetProductById(item.Key);
                total_Price += sp.Price * item.Value;
            }

        }

        public void OnGet()
        {
            cart = getCart();
            updatePrice();
        }

        public void OnGetRemove([FromQuery] int id)
        {
            cart = getCart();
            cart.Remove(id);
            LoadCart(cart);
            updatePrice();

        }

        public void OnGetIncrement([FromQuery] int id)
        {
            cart = getCart();
            if (cart.ContainsKey(id))
            {
                cart[id] += 1;
            }
            LoadCart(cart);
            updatePrice();

        }

        public void OnGetDecrement([FromQuery] int id)
        {
            cart = getCart();
            if (cart.ContainsKey(id))
            {
                if (cart[id] == 1)
                {
                    cart.Remove(id);
                }
                else
                {
                    cart[id] -= 1;
                }
            }
            LoadCart(cart);
            updatePrice();
        }
    }
}
