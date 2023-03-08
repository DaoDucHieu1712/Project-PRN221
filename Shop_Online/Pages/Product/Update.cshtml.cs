using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop_Online.Models;
using Shop_Online.Services;

namespace Shop_Online.Pages.Product
{
    public class UpdateModel : PageModel
    {
        public CategoryService categoryService = new CategoryService();
        public ProductService productService = new ProductService();


        public Models.Product _product { get; set; }
        public List<Category> categories { get; set; }
        public void OnGet([FromQuery] int id)
        {
            _product = productService.GetProductById(id);
            categories = categoryService.GetCategories();
        }


        [BindProperty]
        public Models.Product Product { get; set; } = default;
        public IActionResult OnPost([FromQuery] int id)
        {
            categories = categoryService.GetCategories();
            _product = productService.GetProductById(id);
            productService.update(Product);
            return RedirectToPage("./Index");
        }
    }
}
