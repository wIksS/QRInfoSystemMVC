using QRInfoSystem.Data.Repositories;
using QRInfoSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRInfoSystem.Data
{
    public class QRInfoSystemData : IQRInfoSystemData
    {
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public QRInfoSystemData()
            : this(new QRInfoSystemDbContext())
        {
        }

        public QRInfoSystemData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Teacher> Teachers
        {
            get { return this.GetRepository<Teacher>(); }
        }


        public IRepository<QRCode> QRCodes
        {
            get { return this.GetRepository<QRCode>(); }
        }

        public IRepository<Room> Rooms
        {
            get { return this.GetRepository<Room>(); }
        }

        public IRepository<Shedule> Shedules
        {
            get { return this.GetRepository<Shedule>(); }
        }

        public IRepository<ApplicationUser> Users
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
