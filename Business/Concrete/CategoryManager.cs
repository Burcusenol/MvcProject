using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void İnsert(Category category)
        {
             _categoryDal.Insert(category);
        }

        public List<Category> GetCategories()
        {
            return _categoryDal.List();
        }
    }
}
