using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        List<About> GetAbouts();
        void Insert(About about);
        void Update(About about);
        void Delete(About about);
        About GetById(int id);
    }
}
