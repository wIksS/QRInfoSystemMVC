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
        public Room()
        {

        }

        public Room(string model)
        {
            this.Model = model;
        }

        [Key]
        public string Model { get; set; }        
    }
}
