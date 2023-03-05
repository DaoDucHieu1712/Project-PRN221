using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop_Online.Models;
using Shop_Online.Services;
using System.Text.Json;

namespace Shop_Online.Pages.Home
{
    public class IndexModel : PageModel
    {
        public ProductService productService = new ProductService();

        public void OnGet()
        {
            string cartSession = HttpContext.Session.GetString("cart");
            if (cartSession != null)
            {
                HttpContext.Session.SetString("cart", cartSession);
            }
            else
            {
                IDictionary<int, int> cart = new Dictionary<int, int>();
                string cartJson = JsonSerializer.Serialize(cart);
                HttpContext.Session.SetString("cart", cartJson);
            }
        }
        
    }
}
