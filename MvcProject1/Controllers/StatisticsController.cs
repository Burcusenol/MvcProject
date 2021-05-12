using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject1.Controllers
{
    public class StatisticsController : Controller
    {

        Context context = new Context();
        // GET: Statistics
        public ActionResult Index()
        {
            var result = context.Categories.Count().ToString();
            ViewBag.viewbag = result;

            var result1 = context.Headings.Count(x => x.HeadingName == "Yazılım").ToString();
            ViewBag.viewbag1 = result1;

            var result2 = (from w in context.Writers select w.WriterName.IndexOf("a")).Distinct().Count().ToString();
            ViewBag.viewvbag2 = result2;

            var result3 = context.Categories.Where(c => c.CategoryId == (context.Headings.GroupBy(h => h.CategoryId)
            .OrderByDescending(h => h.Count()).Select(h => h.Key).FirstOrDefault())).
            Select(h => h.CategoryName).FirstOrDefault();
            ViewBag.viewbag3 = result3;

            var result4 = context.Categories.Count(c => c.CategoryStatus == true) - context.Categories.Count(c => c.CategoryStatus == false);
            ViewBag.viewbag4 = result4;

            return View();
        }
    }
}