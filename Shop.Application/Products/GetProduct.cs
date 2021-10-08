using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Database;

namespace Shop.Application.Products
{
    //acesses sources
    public class GetProduct
    {

        private readonly ApplicationDbContext _context;

        public GetProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProductViewModel Do(string name)
        {
            
            return  _context.Products
                .Where(x => x.Name == name)
                .Select(x => new ProductViewModel()
                {
                    Name = x.Name,
                    Description = x.Description,
                    Value = x.Value.ToString("N2"),

                    Stock = x.Stock.Select(y => new StockViewModel
                    {
                        Id = y.Id,
                        Description = y.Description,
                        InStock = y.Quantity > 0
                    })
                }).FirstOrDefault();
        }

        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
            public IEnumerable<StockViewModel> Stock { get; set; }
        }

        public class StockViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public bool InStock { get; set; }
        }
    }
}