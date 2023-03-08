using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop_Online.Models;
using Shop_Online.Services;

namespace Shop_Online.Pages.Product
{
    public class CreateModel : PageModel
    {
        public CategoryService categoryService = new CategoryService();
        public ProductService productService = new ProductService();

        public List<Category> categories { get; set; } = default;
        public void OnGet()
        {
            categories = categoryService.GetCategories();
        }

        [BindProperty]
        public Models.Product Product { get; set; } = default;

        public IActionResult OnPost()
        {
            categories = categoryService.GetCategories();
            productService.create(Product);
            return  RedirectToPage("./Index");
        }
    }
}
