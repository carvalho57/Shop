using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Database;
using Shop.Domain.Models;

namespace Shop.Application.StockAdmin
{
    public class GetStock
    {
        private readonly ApplicationDbContext _context;

        public GetStock(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<ProductViewModel> Do()
        {
            return _context.Products
                .Include(prod => prod.Stock)
                .Select(prod => new ProductViewModel
                {
                    Id = prod.Id,
                    Description = prod.Description,                                       
                    Stock = prod.Stock.Select(stock =>
                        new StockViewModel
                        {
                            Id = stock.Id,
                            Description = stock.Description,
                            Quantity = stock.Quantity,
                        }                        
                    )
                })
                .ToList();
        }

        public class StockViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
        }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public IEnumerable<StockViewModel> Stock { get; set; }
        }

    }
}