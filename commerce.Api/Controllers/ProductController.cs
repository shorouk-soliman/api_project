using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using commerce.BL.Manger;
using commerce.BL.Dtos;
using commerce.BL.Manger.Product;
using commerce.BL.Dtos.Product;


namespace commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManeger _maneger;
        public ProductController(IProductManeger maneger)
        {
            _maneger = maneger;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAll()
        {
            var product = _maneger.GetAll();
            return product.ToList();
        }
        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult<ProductDetailsDto> GetById(int id)
        {
            var ProductDetails = _maneger.GetById(id);
            if (ProductDetails is null)
            {
                return NotFound();
            }
            return ProductDetails;
        }
        [HttpGet]
        [Route("{Name:alpha}")]
        public ActionResult<IEnumerable<ProductDto>> GetByName(string Name)
        {
            var Products = _maneger.GetByName(Name);
            if (Products is null)
            {
                return NotFound();
            }
            return Products.ToList();
        }
    }
}
