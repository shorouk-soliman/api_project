using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.DAL.Repository.Genaric
{
   public  interface IGenaricRepositary<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
