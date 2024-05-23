using commerce.BL.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.BL.Manger.Order
{
   public  interface IOrderManeger
    {
        void AddNewOrder(List<AddOrderDto> newOrder, string UserId);
        IEnumerable<GetOrderHistoryDto> GetAllOrder(string userId);
    }
}
