using commerce.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.BL.Manger.Cart
{
   public class CartManeger: ICartManeger
    {

        private readonly IUnitOfWork _unitOfWork;
        public CartManeger(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddProductToCart(int productId, int Quentity, string UserId)
        {
            _unitOfWork.cartRepository.AddProductToCart(productId, Quentity, UserId);
            _unitOfWork.SaveChanges();

        }

        public void RemoveProductFromCart(int productId, string UserId)
        {
            _unitOfWork.cartRepository.RemoveProductFromCart(productId, UserId);
            _unitOfWork.SaveChanges();

        }

        public void UpadteProductQuentity(int productId, int Quentity, string UserId)
        {
            _unitOfWork.cartRepository.UpadteProductQuentity(productId, Quentity, UserId);
            _unitOfWork.SaveChanges();


        }
    }
}

