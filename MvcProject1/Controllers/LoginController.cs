using Business.Concrete;
using DataAccess.Concrete;
using DataAccessLayer.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProject1.Controllers
{
    public class LoginController : Controller
    {
       
        Context context = new Context();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var result = context.Admins.FirstOrDefault(a => a.AdminUserName == admin.AdminUserName &&
                        a.AdminPassword == admin.AdminPassword);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(result.AdminUserName, false);
                Session["AdminUserName"] = result.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Login");
        }
    }
}