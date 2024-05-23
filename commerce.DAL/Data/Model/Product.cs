using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.DAL.Data.Model
{
    
        public class Product
        {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;

        public string Size { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category? category { get; set; }
        public ICollection<ProductOrder>? productOrders { get; set; }
        public ICollection<ProductCart>? productCarts { get; set; }
    }

    }

