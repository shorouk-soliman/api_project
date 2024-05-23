using commerce.DAL.Context;
using commerce.DAL.Repository.Carts;
using commerce.DAL.Repository.Orders;
using commerce.DAL.Repository.Products;
using commerce.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.DAL
{
    public class ConcreteUnitOfWork : IUnitOfWork
    {
        private readonly EcommerceContext _context;

        public ConcreteUnitOfWork(EcommerceContext DbContext, IProductRepositary productRepo, ICartRepository cartRepo, IOrderRepositary orderRepo)
        {
            _context = DbContext;
            productRepository = productRepo;
            cartRepository = cartRepo;
            orderRepository = orderRepo;
        }

        public IProductRepositary productRepository { get; }
        public ICartRepository cartRepository { get; }
        public IOrderRepositary orderRepository { get; }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

  