using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context context = new Context();
        DbSet<Category> _category;

        public void Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category category)
        {
            _category.Add(category);
            context.SaveChanges();
        }

        public List<Category> List()
        {
            return _category.ToList();
        }

        public void Update(Category category)
        {
            context.SaveChanges();
        }
    }
}
