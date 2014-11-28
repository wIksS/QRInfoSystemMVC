using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRInfoSystem.Models
{
    public class QRCode
    {
        public QRCode()
        {
            this.Code = Guid.NewGuid();
        }

        [Key]
        public Guid Code { get; set; }

        public virtual Teacher Teacher { get; set; }

        public int TeacherId { get; set; }
    }
}
