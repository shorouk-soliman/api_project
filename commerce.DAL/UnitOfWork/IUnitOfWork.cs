using commerce.DAL.Repository.Carts;
using commerce.DAL.Repository.Orders;
using commerce.DAL.Repository.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepositary productRepository { get; }
        ICartRepository cartRepository { get; }
        IOrderRepositary orderRepository { get; }

        void SaveChanges();
    }
}
