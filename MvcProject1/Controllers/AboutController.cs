using Business.Concrete;
using Business.FluentValidation;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject1.Controllers
{
    public class AboutController : Controller
    {

        AboutManager aboutManager = new AboutManager( new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var aboutvalues = aboutManager.GetAbouts();
            return View(aboutvalues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            AboutValidator aboutValidator = new AboutValidator();
            ValidationResult validationResult = aboutValidator.Validate(about);
            if (validationResult.IsValid)
            {
                aboutManager.Insert(about);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}