using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Randevuobject;

namespace RandevuSistemi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Kuafor> Kuaforler { get; set; }
        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<CalismaPlani> CalismaPlanlari { get; set; }
        public DbSet<Islem> Islemler { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }

    }
}
