using commerce.DAL.Context;
using commerce.DAL.Data.Model;
using commerce.DAL.Repository.Genaric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.DAL.Repository.Carts
{
    public class CartRepository : GenaricRepositary<Cart>, ICartRepository

    {
        public CartRepository(EcommerceContext dbContext) : base(dbContext)
        {
        }

        public void AddProductToCart(int productId, int Quentity, string UserId)
        {

            var cart = _Context.Set<Cart>()
                      .FirstOrDefault(c => c.userId == UserId);

            if (cart == null)
            {
                // Create a new cart if it doesn't exist for the user
                cart = new Cart
                {
                    userId = UserId,
                    CartItem = new List<ProductCart>()
                };
                _Context.Set<Cart>().Add(cart);
            }

            // Create a new cart item based on the provided productId and quantity
            var product = _Context.Products.Find(productId);
            if (product != null)
            {

                var cartItem = _Context.Set<ProductCart>().FirstOrDefault(item => item.ProductId == productId && item.CartId == cart.Id);
                if (cartItem != null)
                {
                    cartItem.ProductQuntity += Quentity;
                }
                else
                {
                    var newcartItem = new ProductCart
                    {
                        ProductId = productId,
                        ProductQuntity = Quentity,
                        CartId = cart.Id
                    };

                    _Context.Set<ProductCart>().Add(newcartItem);
                    _Context.SaveChanges();


                }

            }

            _Context.SaveChanges();

        }

        public void RemoveProductFromCart(int productId, string UserId)
        {

            var cart = _Context.Set<Cart>()
                        .FirstOrDefault(c => c.userId == UserId);

            if (cart != null)
            {
                var cartItem = _Context.Set<ProductCart>().FirstOrDefault(item => item.CartId == cart.Id && item.ProductId == productId);
                if (cartItem != null)
                {
                    _Context.Set<ProductCart>().Remove(cartItem);
                    _Context.SaveChanges();
                }
            }

        }

        public void UpadteProductQuentity(int productId, int Quentity, string UserId)
        {
            var userId = UserId;
            var cart = _Context.Set<Cart>()
                      .FirstOrDefault(c => c.userId == userId);
            if (cart != null)
            {
                var cartItem = _Context.Set<ProductCart>().FirstOrDefault(item => item.ProductId == productId && item.CartId == cart.Id);
                if (cartItem != null)
                {
                    cartItem.ProductQuntity = Quentity;

                    _Context.SaveChanges();
                }

            }

        }
    }

}


