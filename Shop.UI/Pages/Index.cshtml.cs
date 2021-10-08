using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Shop.Application.Products;

namespace Shop.UI.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<GetProducts.ProductViewModel> Products { get; set; }
     
        public void OnGet([FromServices]GetProducts getProducts)
        {
            Products = getProducts.Do();
        }        
    }
}
