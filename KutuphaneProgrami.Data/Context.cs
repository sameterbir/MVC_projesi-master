using KutuphaneProgrami.Data.Migrations;
using KutuphaneProgrami.Data.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace KutuphaneProgrami.Data
{
    public class Context : DbContext
    {

        public Context() : base("KutuphaneProgramiDb")
        {

            //InitPattern();

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>("KutuphaneProgramiDb"));


        }

        public DbSet<Kategori> Kategoriler { get; set; }

        public DbSet<Kitap> Kitaplar { get; set; }

        public DbSet<OduncKitap> OduncKitaplar { get; set; }

        public DbSet<Uye> Uyeler { get; set; }

        public DbSet<Yazar> Yazarlar { get; set; }


        // S Takısı kaldırma
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    

        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    base.OnModelCreating(modelBuilder);
        //}


        private void InitPattern()
        {
            Database.CreateIfNotExists(); // veri tabanı yoksa oluştur
            SaveChanges();
        }
    }
}
