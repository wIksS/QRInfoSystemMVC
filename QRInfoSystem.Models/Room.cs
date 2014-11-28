using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRInfoSystem.Models
{
    public class Room
    {
        [Key]
        public string Model { get; set; }        
    }
}
