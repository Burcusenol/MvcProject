using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject1.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        // GET: Heading
        public ActionResult Index()
        {
            var HeadingValues = headingManager.GetHeadings();
            return View(HeadingValues);
        }

        public ActionResult HeadingReport()
        {
            var HeadingValues = headingManager.GetHeadings();
            return View(HeadingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from c in categoryManager.GetCategories()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value=c.CategoryId.ToString()

                                                  }).ToList();

            List<SelectListItem> valuewriter = (from w in writerManager.GetWriters()
                                                  select new SelectListItem
                                                  {
                                                     Text=w.WriterName + " "+ w.WriterSurName,
                                                     Value=w.WriterId.ToString()

                                                  }).ToList();
            ViewBag.valuecategory = valuecategory;
            ViewBag.valuewriter = valuewriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Now;
            headingManager.Insert(heading);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var result = headingManager.GetById(id);
            if(result.HeadingStatus==true)
            {
                result.HeadingStatus = false;
            }
            else
            {
                result.HeadingStatus = true;
            }
            headingManager.Delete(result);
            return RedirectToAction("Index");
        }
    }
}