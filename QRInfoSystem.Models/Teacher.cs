using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRInfoSystem.Models
{
    public class Teacher
    {
        private ICollection<QRCode> qrCodes;
        private ICollection<Shedule> shedules;
        private ICollection<ApplicationUser> subscribedUsers;

        public Teacher()
        {
            this.Shedules = new HashSet<Shedule>();
            this.QRCodes = new HashSet<QRCode>();
            this.SubscribedUsers = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string ImagePath { get; set; }

        //public virtual QRCode QRCode { get; set; }

        //public int QRCodeId { get; set; }

        [JsonIgnore]
        public virtual ICollection<Shedule> Shedules
        {
            get { return this.shedules; }
            set { this.shedules = value; }
        }

        [JsonIgnore]
        public virtual ICollection<QRCode> QRCodes
        {
            get { return this.qrCodes; }
            set { this.qrCodes = value; }
        }

        [JsonIgnore]
        public virtual ICollection<ApplicationUser> SubscribedUsers
        {
            get { return this.subscribedUsers; }
            set { this.subscribedUsers = value; }
        }
    }
}
