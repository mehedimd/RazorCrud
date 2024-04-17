using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrud.Models;

namespace RazorCrud.Pages
{
    public class ProductModel : PageModel
    {
        private readonly RazorContext context;
        public ProductModel(RazorContext cntx)
        {
            this.context = cntx;
        }
        [BindProperty]
        public Product Product { get; set; }
        public List<Product> allProducts = new List<Product>();
        public void OnGet()
        {
            allProducts = context.Products.ToList();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var ifExistes = context.Products.Any(p => p.ProductName.Equals(Product.ProductName));
                if (!ifExistes)
                {
                    context.Products.Add(Product);
                    context.SaveChanges();
                }
                else
                {
                    TempData["ErrorMsg"] = "Product Already Exists, Enter a New Product";
                }
            }
            return RedirectToPage();
        }
        public IActionResult Delete(int id)
        {
            context.Products.Remove(context.Products.Find(id));
            return RedirectToPage();
        }
    }
}
