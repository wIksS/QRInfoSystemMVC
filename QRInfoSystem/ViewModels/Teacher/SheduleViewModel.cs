namespace QRInfoSystem.Web.ViewModels
{
    using QRInfoSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    public class SheduleViewModel 
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public int TeacherId { get; set; }
        
        [StringLength(4,MinimumLength=4)]
        [Required]
        public string RoomName { get; set; }
    }
}