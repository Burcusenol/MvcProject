using Business.Concrete;
using DataAccess.EntityFramework;
using MvcProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject1.Controllers
{
    public class ScheduleController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        // GET: Schedule
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Schedule());
        }

        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            var viewModel = new Schedule();
            var events = new List<Schedule>();
            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-14);

            foreach (var item in headingManager.GetHeadings())
            {
                events.Add(new Schedule()
                {
                    title = item.HeadingName,
                    start = item.HeadingDate,
                    end = item.HeadingDate.AddDays(-14),
                    allDay = false
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }


            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}
