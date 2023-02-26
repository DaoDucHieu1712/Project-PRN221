using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop_Online.Models;
using Shop_Online.Services;

namespace Shop_Online.Pages.Home
{
    public class IndexModel : PageModel
    {

        //private readonly ILogger<IndexModel> _logger;

        

        //public IndexModel(ILogger<IndexModel> logger, ProductService _productService)
        //{
        //    _logger = logger;
        //    productService = _productService;
        //}

        public Product product { get; set; }


        public void OnGet([FromQuery]int? id)
        {
            
        }

        public void OnPost(Product product)
        {

        }
    }
}
