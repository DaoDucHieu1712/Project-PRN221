using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop_Online.Models;
using Shop_Online.Services;

namespace Shop_Online.Pages.Product
{
    public class DeleteModel : PageModel
    {
        public ProductService productService = new ProductService();


        public Models.Product Product { get; set; } = default;
        public string name_product { get; set; }


        public void OnGet([FromQuery] int id)
        {
            Product = productService.GetProductById(id);
            name_product= Product.Name;
        }

        public IActionResult OnGetConfirm([FromQuery] int id)
        {
            Product = productService.GetProductById(id);
            name_product = Product.Name;
            var _product = productService.GetProductById(id);
            productService.delete(_product);
            return RedirectToPage("./Index");
        }

    }
}
