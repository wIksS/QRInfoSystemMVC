using Microsoft.AspNet.Identity.EntityFramework;
using QRInfoSystem.Data.Migrations;
using QRInfoSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRInfoSystem.Data
{
    public class QRInfoSystemDbContext : IdentityDbContext
    {
        public QRInfoSystemDbContext()
            : base("QRInfoSystemConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<QRInfoSystemDbContext, Configuration>());
        }

        IDbSet<Teacher> Teachers { get; set; }

        IDbSet<Room> Rooms { get; set; }

        IDbSet<Shedule> Shedules { get; set; }

        IDbSet<QRCode> QRCodes { get; set; }

        IDbSet<ApplicationUser> Users { get; set; }

        public static QRInfoSystemDbContext Create()
        {
            return new QRInfoSystemDbContext();
        }
    }
}
