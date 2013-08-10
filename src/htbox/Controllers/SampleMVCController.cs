using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace htbox.Controllers
{
    public class SampleMVCController : Controller
    {
        //
        // GET: /SampleMVC/

        public ActionResult Index()
        {
            return View();
        }

    }
}
