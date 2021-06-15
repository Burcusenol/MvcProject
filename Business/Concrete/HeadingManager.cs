using Business.Abstract;
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
            _headingDal.Update(heading);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(h => h.HeadingId == id);
        }

        public List<Heading> GetHeadingByWriter(int id)
        {
            return _headingDal.List(h=>h.WriterId==id);
        }

        public List<Heading> GetHeadings()
        {
            return _headingDal.GetAll();
        }

        public void Insert(Heading heading)
        {
             
            _headingDal.Insert(heading);
        }

        public void Update(Heading heading)
        {
            _headingDal.Update(heading);
        }

       
    }
}
