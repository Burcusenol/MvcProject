using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject1.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var result=imageFileManager.GetImageFile();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(ImageFile imageFile)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string expansion = Path.GetExtension(Request.Files[0].FileName);
                string path = "/Images/Gallery/" + fileName + expansion;
                Request.Files[0].SaveAs(Server.MapPath(path));
                imageFile.ImagePath = "/Images/Gallery/" + fileName + expansion;
                imageFileManager.Insert(imageFile);
                return RedirectToAction("Index");

            }
            return View();

            
        }


    }
}