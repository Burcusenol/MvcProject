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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Delete(Writer writer)
        {
             _writerDal.Delete(writer);
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(w => w.WriterId == id);
        }

        public List<Writer> GetWriters()
        {
            return _writerDal.GetAll();
        }

        public void Insert(Writer writer)
        {
             _writerDal.Insert(writer);
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
