using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JasmineTest.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Jasmine()
        {
            return View();
        }

    }
}
