using commerce.DAL.Data.Model;
using commerce.DAL.Repository.Genaric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.DAL.Repository.Products
{
    public interface IProductRepositary : IGenaricRepositary<Product>
    {
        Product? GetById(int id);
        IEnumerable<Product>? GetByName(string Name);
        IEnumerable<Product>? GetByCategory(int IdCat);
    }
}

