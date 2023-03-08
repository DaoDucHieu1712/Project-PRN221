using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop_Online.Models;
using Shop_Online.Services;

namespace Shop_Online.Pages.Product
{
    public class IndexModel : PageModel
    {


        public ProductService productService = new ProductService();
        public List<Models.Product> products = new List<Models.Product>();
        public filterProducts filter { get;set; }
        public int total_page { get; set; } 
        public async void OnGet(filterProducts filtersp)
        {   
            if(filtersp != null)
            {
               total_page = productService.totalProducts();
               filtersp.pageIndex =  filtersp.pageIndex <= 0 ? 1 : filtersp.pageIndex;
               filtersp.search_name = filtersp.search_name ?? "";
               products = productService.getProductsAndPaging(filtersp.search_name,filtersp.pageIndex);
               filter = filtersp;
            }
        }

        public class filterProducts
        {
            public int pageIndex { get; set; } = 1;
            public string? search_name { get; set; } = default;
        }
    }
}
