using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Products;

namespace Shop.UI.Pages
{
    public class ProductModel : PageModel
    {
        public GetProduct.ProductViewModel Product { get; set; }
        public IActionResult OnGet(
            [FromServices] GetProduct product,
            string name)
        {

            Product = product.Do(name.Replace("-"," "));
            if(Product == null)
                return RedirectToPage("Index");
            else    
                return Page();
        }
    }
}
