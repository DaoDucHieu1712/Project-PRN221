using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Shop_Online.Pages.Cart
{
    public class AddToCartAsyncModel : PageModel
    {
        public void OnGet()
        {
            var id = int.Parse(Request.Query["id"]);    
            string cartJson = HttpContext.Session.GetString("cart");
            var cart = JsonSerializer.Deserialize<IDictionary<int, int>>(cartJson);
            if (cart.ContainsKey(id))
            {
                cart[id] += 1;
            }
            else
            {
                cart.Add(id, 1);
            }
            string newCartJson = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString("cart", newCartJson);
        }
    }
}
