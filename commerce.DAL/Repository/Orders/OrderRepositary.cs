using commerce.DAL.Context;
using commerce.DAL.Data.Model;
using commerce.DAL.Repository.Genaric;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.DAL.Repository.Orders
{ 
   public class OrderRepositary : GenaricRepositary<Order>, IOrderRepositary
{
    public OrderRepositary(EcommerceContext dbContext) : base(dbContext)
    {
    }

    public void AddNewOrder(List<(int ProductId, int Quntity)> newOrder, string UserId)
    {
        var cart = _Context.Set<Cart>()
                  .FirstOrDefault(c => c.userId == UserId);
        if (cart != null)
        {
            // Create a new order
            var order = new Order
            {
                CeartionDateTime = DateTime.Now,
                userId = UserId,

                OrderItems = new List<ProductOrder>()
            };
            _Context.Set<Order>().Add(order);
            _Context.SaveChanges();
            // Add order items from the provided list

            decimal total = 0;
            foreach (var obj in newOrder)
            {
                var product = _Context.Set<Product>().Find(obj.ProductId);
                if (product != null)
                {
                    var orderItem = new ProductOrder
                    {
                        ProductId = obj.ProductId,
                        ProductQuntity = obj.ProductId,
                        OrderId = order.Id
                    };
                    _Context.Set<ProductOrder>().Add(orderItem);


                    total += obj.Quntity * product.Price;

                    order.TotalPrice = total;
                    // Add the order to the context and save changes

                    _Context.SaveChanges();
                    var cartItem = cart?.CartItem?.FirstOrDefault(e => e.ProductId == obj.ProductId);
                    if (cartItem != null)
                    {
                        cart?.CartItem?.Remove(cartItem);
                        _Context.SaveChanges();
                    }

                }
            }
            _Context.SaveChanges();
        }
    }






    public IEnumerable<Order> GetAllOrder(string userId)
    {
        return _Context.Set<Order>()
           .Where(c => c.userId == userId);
    }
}
}

