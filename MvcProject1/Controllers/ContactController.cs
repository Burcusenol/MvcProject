using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject1.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidation = new ContactValidator();
        // GET: Contact
        public ActionResult Index()
        {
            var contactvalues = contactManager.GetContacts();
            return View(contactvalues);
        }

        [HttpGet]
        public ActionResult GetContactDetails(int id)
        {
            var result = contactManager.GetById(id);
            return View(result);
        }

        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }
    }
}