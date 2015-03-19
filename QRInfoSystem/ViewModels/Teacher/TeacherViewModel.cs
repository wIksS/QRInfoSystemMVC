using QRInfoSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QRInfoSystem.Web.ViewModels
{
    public class TeacherViewModel 
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20,MinimumLength=3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [Phone]        
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string ImagePath { get; set; }
    }
}