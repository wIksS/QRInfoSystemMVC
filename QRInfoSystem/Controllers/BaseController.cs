﻿using QRInfoSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QRInfoSystem.Web.Controllers
{
    public class BaseController : ApiController
    {
        public BaseController(IQRInfoSystemData data)
        {
            this.Data = data;
        }

        protected IQRInfoSystemData Data { get; set; }
    }
}
