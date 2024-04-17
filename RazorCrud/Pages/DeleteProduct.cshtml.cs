using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrud.Models;

namespace RazorCrud.Pages
{
    public class DeleteProductModel : PageModel
    {
        private readonly RazorContext context;
        public DeleteProductModel(RazorContext cntx)
        {
            this.context = cntx;
        }
        public IActionResult OnGet(int id)
        {
            context.Products.Remove(context.Products.Find(id));
            context.SaveChanges();
            return RedirectToPage("Product");
        }
    }
}
