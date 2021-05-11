using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
          Context context = new Context();
          DbSet<T> _entity;
        public GenericRepository()
        {
            _entity = context.Set<T>();
        }
        public void Delete(T entity)
        {
            _entity.Remove(entity);
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _entity.SingleOrDefault(filter);
        }

        public void Insert(T entity)
        {
            _entity.Add(entity);
            context.SaveChanges();
        }

        public List<T> List()
        {
            return _entity.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _entity.Where(filter).ToList();
        }

        public void Update(T entity)
        {

            context.SaveChanges();
        }
    }
}
