using QRInfoSystem.Data;
using QRInfoSystem.Models;
using QRInfoSystem.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QRInfoSystem.Web.Controllers
{
    public class QRCodeController : BaseController
    {
        public QRCodeController(IQRInfoSystemData data)
            : base(data)
        {
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult CreateQRCode(int id)
        {
            QRCode code = new QRCode();
            code.TeacherId = id;

            Data.QRCodes.Add(code);
            Data.QRCodes.SaveChanges();

            return Ok(code);
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetQRCode(int id)
        {
            var teacher = this.Data.Teachers.Find(id);

            var dbCode = teacher.QRCodes.FirstOrDefault();
            if(dbCode != null)
            {
                var code = new QRCodeViewModel()
                    {
                        Code = dbCode.Code,
                        TeacherId = dbCode.TeacherId
                    };
                return Ok(code);
            }

            return NotFound();
        }
    }
}
