using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QRInfoSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Teacher> subscribedTeachers;

        public ApplicationUser()
        {
            this.SubscribedTeachers = new HashSet<Teacher>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        //public IList<string> UserRoles { get; set; }       

        public virtual Teacher Teacher { get; set; }

        public int? TeacherId { get; set; }

        public virtual ICollection<Teacher> SubscribedTeachers
        {
            get { return this.subscribedTeachers; }
            set { this.subscribedTeachers = value; }
        }
    }
}
