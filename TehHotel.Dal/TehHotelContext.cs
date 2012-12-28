using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TehHotel.Dal.Models;

namespace TehHotel.Dal
{
    public class TehHotelContext : DbContext
    {
        public DbSet<DvoranaEF> Dvorane { get; set; }
        public DbSet<HotelEF> Hoteli { get; set; }
        public DbSet<IdentifikacijaEF> Identifikacije { get; set; }
        public DbSet<NaslovEF> Naslovi { get; set; }
        public DbSet<ParkirisceEF> Parkirisca { get; set; }
        public DbSet<SobaEF> Sobe { get; set; }
        public DbSet<ZaposleniEF> Osebje { get; set; }
        public DbSet<StrankaEF> Stranke { get; set; }
        public DbSet<RezervacijaSobeEF> RezervacijeSob { get; set; }
        public DbSet<RacunEF> Racuni { get; set; }
        public DbSet<RezervacijaDvoraneEF> RezervacijeDvorane { get; set; }
        public DbSet<RezervacijaParkiriscaEF> RezervacijaParkirisca { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelEF>().HasMany(x => x.Sobe).WithOptional(x => x.Hotel).HasForeignKey(x => x.HotelId).WillCascadeOnDelete(true);
            modelBuilder.Entity<HotelEF>().HasMany(x => x.Dvorane).WithOptional(x => x.Hotel).HasForeignKey(x => x.HotelId).WillCascadeOnDelete(true);
            modelBuilder.Entity<HotelEF>().HasMany(x => x.Parkirisca).WithOptional(x => x.Hotel).HasForeignKey(x => x.HotelId).WillCascadeOnDelete(true);
            modelBuilder.Entity<HotelEF>().HasMany(x => x.Osebje).WithOptional(x => x.Hotel).HasForeignKey(x => x.HotelId).WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }
    }
}
