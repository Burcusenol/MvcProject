using BusinessLayer.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void Delete(Heading heading)
        {
            _headingDal.Delete(heading);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(h => h.HeadingId == id);
        }

        public List<Heading> GetHeadings()
        {
            return _headingDal.GetAll();
        }

        public void Insert(Heading heading)
        {
             DateAdded(heading);
            _headingDal.Insert(heading);
        }

        public void Update(Heading heading)
        {
            _headingDal.Update(heading);
        }

        private void DateAdded(Heading heading)
        {
              heading.HeadingDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
        }
    }
}
