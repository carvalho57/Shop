using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Models
{
    //represent how many products we have
    public class Stock
    {
        public Stock() {}
        public Stock(string description, int quantity, int productId)
        {
            Description = description;
            Quantity = quantity;
            ProductId = productId;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        
    }
}
