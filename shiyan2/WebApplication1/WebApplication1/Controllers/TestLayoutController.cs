using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TestLayoutController : Controller
    {
        // GET: TestLayout
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
       
    }
}