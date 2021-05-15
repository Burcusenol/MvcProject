using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetWriters();
        void Insert(Writer writer);
        void Update(Writer writer);
        void Delete(Writer writer);
        Writer GetById(int id);
    }
}
