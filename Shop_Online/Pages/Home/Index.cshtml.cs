using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop_Online.Models;
using Shop_Online.Services;

namespace Shop_Online.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public readonly ProductService productService = new ProductService();

        public void OnGet()
        {
            
        }
        

        public void OnPost()
        {

        }
    }
}
