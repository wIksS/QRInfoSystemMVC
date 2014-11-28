using QRInfoSystem.Data.Repositories;
using QRInfoSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QRInfoSystem.Data
{
    public interface IQRInfoSystemData
    {
        IRepository<Teacher> Teachers { get; }

        IRepository<Shedule> Shedules { get; }

        IRepository<Room> Rooms { get; }

        IRepository<QRCode> QRCodes { get; }

        IRepository<ApplicationUser> Users { get; }        

    }
}
