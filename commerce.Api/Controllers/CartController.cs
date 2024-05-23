


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using commerce.BL.Dtos.Cart;
using commerce.BL.Manger.Cart;
using commerce.DAL.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManeger _cartManeger;
        private readonly UserManager<User> _userManage;
        public CartController(ICartManeger cartManeger, UserManager<User> userManage)
        {
            _cartManeger = cartManeger;
            _userManage = userManage;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddProductToCart(AddToCartDto addToCartDto)
        {
            User user = await _userManage.GetUserAsync(User);

            _cartManeger.AddProductToCart(addToCartDto.ProductId, addToCartDto.Quantity, user.Id);

            return Ok(" added successfully");

        }
        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> RemoveProductFromCart(int id)
        {
            User user = await _userManage.GetUserAsync(User);
            _cartManeger.RemoveProductFromCart(id, user.Id);
            return Ok("deleted successfully");
        }
        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpadteProductQuentity(EditQuentity EditQuentity)
        {
            User user = await _userManage.GetUserAsync(User);

            _cartManeger.UpadteProductQuentity(EditQuentity.ProductId,
             EditQuentity.Quantity, user.Id);
            return Ok("updated sucessfully");
        }
    }
}
