using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRInfoSystem.Models
{
    public class Shedule
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public string RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}
