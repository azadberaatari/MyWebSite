using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebSite.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        //WriterValidator writervalidator = new WriterValidator();

        public ActionResult Index()
        {
            var WriterValues = wm.GetList();
            return View(WriterValues);
        }
    }
}