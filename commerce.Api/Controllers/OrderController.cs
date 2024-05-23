
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using commerce.BL.Dtos.Cart;
using commerce.BL.Dtos.Order;
using commerce.BL.Dtos.Product;
using commerce.BL.Manger.Cart;
using commerce.BL.Manger.Order;
using commerce.DAL.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManeger _orderManeger;
        private readonly UserManager<User> _userManage;
        public OrderController(IOrderManeger orderManeger, UserManager<User> userManage)
        {
            _orderManeger = orderManeger;
            _userManage = userManage;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddNewOrder(List<AddOrderDto> newOrder)
        {
            User user = await _userManage.GetUserAsync(User);


            _orderManeger.AddNewOrder(newOrder, user.Id);


            return Ok("added successfilly");
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetOrderHistoryDto>>> GetAllOrder()
        {
            User user = await _userManage.GetUserAsync(User);

            var orders = _orderManeger.GetAllOrder(user.Id);
            return orders.ToList();
        }


    }
}
