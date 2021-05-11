using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        void Insert(Category category);
        List<Category> GetCategories();
        void Delete(Category category);
        void Update(Category category);
        Category GetById(int Id);
    }
}
