using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.BL.Dtos.Order
{
    public class GetOrderHistoryDto
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice { get; set; }
        public DateTime CeartionDateTime { get; set; }
    }
}
