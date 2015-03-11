using QRInfoSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRInfoSystem.Web.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult HomeLogin()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}