using QRInfoSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRInfoSystem.Web.ViewModels
{
    public class QRCodeViewModel 
    {
        public Guid Code { get; set; }

        public int TeacherId { get; set; }
    }
}