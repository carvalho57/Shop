using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Database;
using Shop.Domain.Models;

namespace Shop.Application.StockAdmin
{
    public class DeleteStock
    {
        private readonly ApplicationDbContext _context;

        public DeleteStock(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<bool> Do(int id)
        {
            var stock = await _context.Stock.FirstOrDefaultAsync(stock => stock.Id == id);

            if(stock != null)
                _context.Stock.Remove(stock);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}