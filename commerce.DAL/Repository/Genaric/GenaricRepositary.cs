using commerce.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace commerce.DAL.Repository.Genaric
{
   public class GenaricRepositary<TEntity> : IGenaricRepositary<TEntity> where TEntity : class
    {
        protected readonly EcommerceContext _Context;
        public GenaricRepositary(EcommerceContext dbContext)
        {
            this._Context = dbContext;
        }
        public IEnumerable<TEntity> GetAll()
        {
            //return _context.TEntitys;
            return _Context.Set<TEntity>()
                .AsNoTracking();
        }
        public void Add(TEntity entity)
        {
            _Context.Set<TEntity>()
            .Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _Context.Set<TEntity>()
              .Remove(entity);
        }



        public void Update(TEntity entity)
        {

        }
    }
}
