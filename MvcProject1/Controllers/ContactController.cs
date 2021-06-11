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
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
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
            var contact = contactManager.GetContacts().Count();
            ViewBag.contact = contact;

            var sendMail = messageManager.GetMessageSendBox().Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = messageManager.GetMessagesInbox().Count();
            ViewBag.receiverMail = receiverMail;

            var draftMail = messageManager.GetMessageSendBox().Where(m => m.IsDraft == true).Count();
            ViewBag.draftMail = draftMail;

            var readMessage = messageManager.GetMessagesInbox().Where(m => m.IsRead == true).Count();
            ViewBag.readMessage = readMessage;

            var unreadMessage = messageManager.GetAllRead().Count();
            ViewBag.unreadMessage = unreadMessage;
            return PartialView();
        }
    }
}