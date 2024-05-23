using commerce.DAL.Data.Model;
using commerce.DAL.Repository.Genaric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.DAL.Repository.Carts
{
    public interface ICartRepository : IGenaricRepositary<Cart>
    {

        void AddProductToCart(int productId, int Quentity, string UserId);
        void RemoveProductFromCart(int productId, string UserId);
        void UpadteProductQuentity(int productId, int Quentity, string UserId);
    }
}
