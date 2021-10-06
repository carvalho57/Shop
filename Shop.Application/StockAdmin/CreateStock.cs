using System.Threading.Tasks;
using Shop.Database;
using Shop.Domain.Models;

namespace Shop.Application.StockAdmin
{
    public class CreateStock
    {
        private readonly ApplicationDbContext _context;

        public CreateStock(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Response> Do(Request request)
        {
            var stock = new Stock(request.Description, request.Quantity,request.ProductId);

            _context.Stock.Add(stock);
            await _context.SaveChangesAsync();

            return new Response()
            {
                Id = stock.Id,
                Description = stock.Description,
                Quantity = stock.Quantity
            };
        }

        public class Response
        {
            public int Id { get; set; }            
            public string Description { get; set; }
            public int Quantity { get; set; }
        }

        public class Request
        {
            public int ProductId { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
        }
    }
}