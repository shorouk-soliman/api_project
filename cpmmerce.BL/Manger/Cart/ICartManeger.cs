using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.BL.Manger.Cart
{
    public interface ICartManeger
    {
        void AddProductToCart(int productId, int Quentity, string UserId);
        void RemoveProductFromCart(int productId, string UserId);
        void UpadteProductQuentity(int productId, int Quentity, string UserId);
    }
}
