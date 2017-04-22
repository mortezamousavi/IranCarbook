using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer
{
    public class DataContext:DbContext
    {
        static DataContext()
        {
            System.Data.Entity.Database.SetInitializer
      (new System.Data.Entity.MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>());
        }
        public DataContext()
        {

        }
        public System.Data.Entity.DbSet<UserRoll> UserRoll { get; set; }
        public System.Data.Entity.DbSet<dbUser> dbUser { get; set; }
        public System.Data.Entity.DbSet<MaghalehGroup> MaghalehGroup { get; set; }
        public System.Data.Entity.DbSet<Maghaleh> Maghaleh { get; set; }
        public System.Data.Entity.DbSet<Gallery> Gallery { get; set; }
        public System.Data.Entity.DbSet<CarInfo> CarInfo { get; set; }
        public System.Data.Entity.DbSet<news> news { get; set; }
    }
}
