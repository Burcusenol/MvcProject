using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetContents();
        void Insert(Content content);
        void Update(Content content);
        void Delete(Content content);
        Content GetById(int id);
        List<Content> GetListByHeadingId(int id);
    }
}
