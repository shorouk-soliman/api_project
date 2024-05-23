using commerce.DAL.Data.Model;
using commerce.DAL.Repository.Genaric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.DAL.Repository.Orders
{
    public interface IOrderRepositary : IGenaricRepositary<Order>
    {
        void AddNewOrder(List<(int ProductId, int Quntity)> newOrder, string UserId);
        IEnumerable<Order> GetAllOrder(string userId);
    }
}
