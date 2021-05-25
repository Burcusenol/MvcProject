﻿using BusinessLayer.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }

        public Content GetById(int id)
        {
             return _contentDal.Get(c => c.ContentId == id);
        }

        public List<Content> GetContents()
        {
            return _contentDal.GetAll();
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDal.List(c => c.HeadingId == id);
        }

        public void Insert(Content content)
        {
            _contentDal.Insert(content);
        }

        public void Update(Content content)
        {
            _contentDal.Update(content);
        }
    }
}