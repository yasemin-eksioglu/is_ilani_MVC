using is_ilani_MVC.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace is_ilani_MVC.Models
{
    public class DataContext: IdentityDbContext<Musteri>
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ////Başvuru - Aday ilişkisi
            modelBuilder.Entity<Basvuru>()
                .HasOne(b => b.aday) //başvuru bir adaya ait
                .WithMany(a => a.basvurular); //bir adayın birçok başvurusu olabilir


            ////Başvuru- İlan ilişkisi
            modelBuilder.Entity<Basvuru>()
               .HasOne(b => b.ilan)
               .WithMany()
               .HasForeignKey(b => b.ilanId)
               .OnDelete(DeleteBehavior.NoAction);

            //İlan - kategori 
            modelBuilder.Entity<Ilanlar>()
                .HasOne(i => i.kategori) //her ilan bir kategoriye ait
                .WithMany(k=> k.ilanlar) //bir kategorinin birçok ilanı olabilir
                .HasForeignKey(i => i.kategoriId) //foreign key (kategoriId)
                .OnDelete(DeleteBehavior.NoAction); //Kategori silindiğinde ilanlar da silinsin

            //İşveren - ilanlar 
            modelBuilder.Entity<Ilanlar>()
                .HasOne(i => i.isveren) //her ilan bir işverene ait
                .WithMany(k => k.ilanlar) //bir işverenin birçok ilanı olabilir
                .HasForeignKey(i => i.isverenId) //foreign key (isverenId)
                .OnDelete(DeleteBehavior.NoAction);

        }

        public DbSet<Aday> adaylar { get; set; }
        public DbSet<Ilanlar> ilanlar { get; set; }
        public DbSet<Isveren> isverenler { get; set; }
        public DbSet<Kategori> kategoriler { get; set; }
        public DbSet<Kullanici> kullanicilar { get; set; }
        public DbSet<Basvuru> basvurular { get; set; }
    }
}
