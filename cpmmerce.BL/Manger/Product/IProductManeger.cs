using commerce.BL.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.BL.Manger.Product
{
   public  interface IProductManeger
    {
        IEnumerable<ProductDto> GetAll();
        ProductDetailsDto? GetById(int id);
        IEnumerable<ProductDto>? GetByName(string Name);
        IEnumerable<ProductDto>? GetByCategory(int IdCat);
    }
}
