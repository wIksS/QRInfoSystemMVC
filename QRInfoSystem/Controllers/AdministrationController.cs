using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRInfoSystem.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdministrationController : Controller
    {
        public ActionResult Users()
        {
            return View();
        }

        public ActionResult QRCode()
        {
            return View();
        }

        public ActionResult Unauthorized()
        {
            return View();
        }

        public ActionResult AdminPanel()
        {
            return View();
        }

        public ActionResult TeachersCodes()
        {
            return View();
        }
    }
}