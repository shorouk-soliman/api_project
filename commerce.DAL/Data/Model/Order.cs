using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.DAL.Data.Model
{
    public class Order
    {
        public int Id { get; set; }
        public List<ProductOrder> OrderItems { get; set; } = [];
        public User ?user { get; set; }
        public string userId { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice
        {
            get; set;
        }
        public DateTime CeartionDateTime { get; set; }
    }
}
