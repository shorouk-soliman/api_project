using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.DAL.Data.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public User? user { get; set; }
        public string userId { get; set; } = string.Empty;
        public List<ProductCart>? CartItem { get; set; }
    }
}
