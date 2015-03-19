using QRInfoSystem.Data;
using QRInfoSystem.Web.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace QRInfoSystem.Controllers
{
    public class ImagesController: BaseController
    {
        public ImagesController(IQRInfoSystemData data)
            : base(data)
        {            
        }

       
    }
}
