using QRInfoSystem.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace QRInfoSystem.Controllers
{
    public class TeacherController : Controller
    {
        public TeacherController(IQRInfoSystemData data)
        {
            this.Data = data;
        }

        private IQRInfoSystemData Data { get; set; }

        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TeacherDetails()
        {
            return View();
        }

        public ActionResult TeacherRegister()
        {
            return View();
        }

        public ActionResult Schedule()
        {
            return View();
        }

        public ActionResult Teachers()
        {
            return View();
        }

        public ActionResult UploadImage()
        {
            return View();
        }

        public RedirectResult UploadTeacherImage(HttpPostedFileBase file, int? teacherId)
        {
            if (file != null && teacherId != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Images"), pic);
                
                file.SaveAs(path);

                var teacher = Data.Teachers.Find(teacherId);
                teacher.ImagePath = "/Images/" + pic;
                Data.Teachers.SaveChanges();
            }

            return RedirectPermanent("/#/");
        }
    }
}