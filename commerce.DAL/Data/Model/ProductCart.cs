using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.DAL.Data.Model
{
    public class ProductCart
    {
        public Product? Product { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int ProductQuntity { get; set; }
        public Cart? cart { get; set; }
    }

}

