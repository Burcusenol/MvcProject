using Business.Concrete;
using Business.FluentValidation;
using DataAccess.Concrete;
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
        Context context = new Context();
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
            var contact = context.Contacts.Count().ToString();
            ViewBag.contact = contact;

            var sendMail = context.Messages.Count(m => m.SenderMail == "admin@gmail.com").ToString();
            ViewBag.sendMail = sendMail;

            var receiverMail = context.Messages.Count(m => m.ReceiverMail == "admin@gmail.com").ToString();
            ViewBag.receiverMail = receiverMail;
            return PartialView();
        }
    }
}