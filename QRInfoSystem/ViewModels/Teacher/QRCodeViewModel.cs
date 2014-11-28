using QRInfoSystem.Models;
using QRInfoSystem.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRInfoSystem.Web.ViewModels
{
    public class QRCodeViewModel : IMapFrom<QRCode>
    {
        public Guid Code { get; set; }

        public int TeacherId { get; set; }
    }
}