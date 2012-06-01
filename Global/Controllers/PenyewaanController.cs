using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Global.Controllers
{
    public class PenyewaanController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPenyewaan()
        {
            return View();
        }
    }
}
