using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProject1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Context context = new Context();
            var result = context.Admins.FirstOrDefault(a => a.AdminUserName == admin.AdminUserName &&
              a.AdminPassword == admin.AdminPassword);
            if(result!=null)
            {
                FormsAuthentication.SetAuthCookie(result.AdminUserName,false);
                Session["AdminUserName"] = result.AdminUserName;
                return RedirectToAction("Index","AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
           
        }
    }
}