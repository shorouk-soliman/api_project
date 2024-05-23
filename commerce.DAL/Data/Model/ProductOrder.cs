using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.DAL.Data.Model
{
    public class ProductOrder
    {
        public Product? Product { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int ProductQuntity { get; set; }
        public Order? order { get; set; }
    }
}
