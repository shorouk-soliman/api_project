using commerce.DAL.Context;
using commerce.DAL.Data.Model;
using commerce.DAL.Repository.Genaric;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.DAL.Repository.Products
{
    public class ProductRepositary : GenaricRepositary<Product>, IProductRepositary
    {

        public ProductRepositary(EcommerceContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Product>? GetByCategory(int IdCat)
        {
            return _Context.Set<Product>().Where(x => x.CategoryId == IdCat);
        }

        public Product? GetById(int id)
        {
            return _Context.Set<Product>().Include(e => e.category).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product>? GetByName(string Name)
        {
            return _Context.Set<Product>().Where(x => x.Name == Name);
        }


    }
}


   

