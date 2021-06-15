using BusinessLayer.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject1.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();
        // GET: WriterPanelContent
        public ActionResult MyContent(string param)
        {
            param = (string)Session["WriterEmail"];
            var writeridinfo = context.Writers.Where(w => w.WriterEmail == param).Select(x => x.WriterId).FirstOrDefault();
            var contentvalues = contentManager.GetListByWriter(writeridinfo);
            return View(contentvalues);
            
        }
    }
}