using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using Business.FluentValidation;

namespace MvcProject1.Controllers
{
    public class WriterPanelController : Controller
    {
        Context context = new Context();
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterValidator writerValidator = new WriterValidator();
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        // GET: WriterPanel
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string param = (string)Session["WriterEmail"];
            id = context.Writers.Where(w => w.WriterEmail == param).Select(x => x.WriterId).FirstOrDefault();
            var result = writerManager.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            ValidationResult validationResult = writerValidator.Validate(writer);
            if (validationResult.IsValid)
            {
                writerManager.Update(writer);
                return RedirectToAction("AllHeading","WriterPanel");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }


        public ActionResult MyHeading(string param)
        {
            param = (string)Session["WriterEmail"];
            var writerid= context.Writers.Where(w => w.WriterEmail == param).Select(x => x.WriterId).FirstOrDefault();
            var result = headingManager.GetHeadingByWriter(writerid);
            return View(result);
        }

        [HttpGet]
        public ActionResult HeadingAdd()
        {
            List<SelectListItem> valuecategory = (from c in categoryManager.GetCategories()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryId.ToString()

                                                  }).ToList();
            ViewBag.valuecategory = valuecategory;
            return View();
        }

        [HttpPost]
        public ActionResult HeadingAdd(Heading heading)
        {
            string deger = (string)Session["WriterEmail"];
            var writeridhead = context.Writers.Where(w => w.WriterEmail == deger).Select(x => x.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId=writeridhead ;
            heading.HeadingStatus = true;
            headingManager.Insert(heading);
            return RedirectToAction("MyHeading");
            
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> valuecategory = (from c in categoryManager.GetCategories()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryId.ToString()

                                                  }).ToList();

            ViewBag.valuecategory = valuecategory;
            var result = headingManager.GetById(id);
            return View(result);
        }


        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            headingManager.Update(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var result = headingManager.GetById(id);
            if (result.HeadingStatus == true)
            {
                result.HeadingStatus = false;
            }
            else
            {
                result.HeadingStatus = true;
            }
            headingManager.Delete(result);
            return RedirectToAction("MyHeading");
        }


        public ActionResult AllHeading(int page=1)
        {
            var headings = headingManager.GetHeadings().ToPagedList(page, 10);
            return View(headings);
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}