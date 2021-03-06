using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject1.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string param)
        {
             var values = contentManager.GetContents(param);
             return View(values);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = contentManager.GetListByHeadingId(id);
            return View(contentvalues);
        }


        
    }
}