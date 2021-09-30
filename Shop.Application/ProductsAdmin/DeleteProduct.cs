using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Database;

namespace Shop.Application.ProductsAdmin
{
    
    public class DeleteProduct
    {
        private ApplicationDbContext _context;

        public DeleteProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Do(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if(product == null)
                return false;
            
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}