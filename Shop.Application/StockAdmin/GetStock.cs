using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        public  IEnumerable<StockViewModel> Do(int productId)
        {
            return _context.Stock
                .Where(stock => stock.ProductId == productId)
                .Select(x => new StockViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    Quantity = x.Quantity,                    
                })
                .ToList();                           
        }

        public class StockViewModel
        {
            public int Id { get; set; }            
            public string Description { get; set; }
            public int Quantity { get; set; }
        }
        
    }
}