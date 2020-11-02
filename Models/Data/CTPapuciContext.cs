using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTPapuci.Models;

namespace CTPapuci.Models.Data
{

    public class CTPapuciContext : DbContext
    {
        public CTPapuciContext(DbContextOptions<CTPapuciContext> options) : base(options)
        { 

        }
        public DbSet<Angajat> Angajati { get; set; }
        public DbSet<Magazin> Magazine { get; set; }
        public DbSet<Departament> Departamente { get; set; }
        public DbSet<Functie> Functii { get; set; }

        public DbSet<Comanda> Comenzi { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Magazin>()
            .HasMany(m => m.Departamente)
            .WithOne(d => d.Magazin);

            modelBuilder.Entity<Departament>()
            .HasOne(d => d.Magazin)
            .WithMany(m => m.Departamente);

            modelBuilder.Entity<Departament>()
            .HasMany(d => d.Angajati)
            .WithOne(a => a.Departament);

            modelBuilder.Entity<Angajat>()
            .HasOne(a => a.Departament)
            .WithMany(d => d.Angajati);

            modelBuilder.Entity<Functie>()
            .HasMany(d => d.Angajati)
            .WithOne(a => a.Functie);

            modelBuilder.Entity<Angajat>()
            .HasOne(a => a.Functie)
            .WithMany(d => d.Angajati);

            /*modelBuilder.Entity<Comanda>()
                .Property(b => b.Data_Comanda)
                .HasDefaultValueSql("getdate()");
            */
            //modelBuilder.Entity<Stoc>().HasKey(po => new { po.IdProdus, po.IdMagazin });
            modelBuilder.Seed();
        }

        public DbSet<CTPapuci.Models.Client> Client { get; set; }






    }
}
