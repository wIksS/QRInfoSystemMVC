using AutoMapper;
using QRInfoSystem.Data;
using QRInfoSystem.Models;
using QRInfoSystem.Web.ViewModels;
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

            data.QRCodes.Add(code);
            data.QRCodes.SaveChanges();

            return Ok(code);
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetQRCode(int id)
        {
            var teacher = this.data.Teachers.Find(id);

            var dbCode = teacher.QRCodes.FirstOrDefault();
            if(dbCode != null)
            {
                var code = Mapper.Map<QRCodeViewModel>(dbCode);
                return Ok(code);
            }

            return NotFound();
        }
    }
}
