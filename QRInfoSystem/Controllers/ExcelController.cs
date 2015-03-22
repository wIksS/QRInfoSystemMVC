using QRInfoSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRInfoSystem.Controllers
{
    [Authorize(Roles="Admin")]
    public class ExcelController : Controller
    {
        public ExcelController(IQRInfoSystemData data)
        {
            this.Data = data;
        }

        private IQRInfoSystemData Data { get; set; }
        // GET: Excel
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public RedirectResult UploadExcel(HttpPostedFileBase file, int? teacherId)
        {

            return RedirectPermanent("/#/Excel/" + teacherId);
        }
    }
}