using Microsoft.EntityFrameworkCore;


namespace CTPapuci.Models.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Magazin>().HasData(
               new Magazin
               {
                   Id = -1,
                   Nume = "Carmelina",
                   Cod = 99989,
                   Locatie = "Piatra Neamt"

               },
               new Magazin
               {
                   Id = -2,
                   Nume = "Katarina",
                   Cod = 99974,
                   Locatie = "Roman"
               }
               );

            modelBuilder.Entity<Functie>().HasData(
               new Functie
               {
                   Id = -1,
                   Nume = "Vanzator",
                   Descriere = "Vinde cu spor"
               },
               new Functie
               {
                   Id = -2,
                   Nume = "Manager",
                   Descriere = "Conduce de zor"
               }
               );

            modelBuilder.Entity<Departament>().HasData(
               new Departament
               {
                   Id = -1,
                   Cod = 78793,
                   Nume = "Vanzari",
                   IdMagazin = -1,
               },
               new Departament
               {
                   Id = -2,
                   Nume = "Management",
                   Cod = 39915,
                   IdMagazin = -2
               },
               new Departament
               {
                   Id = -3,
                   Nume = "IT",
                   Cod = 42215,
                   IdMagazin = -2
               }
               );
            modelBuilder.Entity<Angajat>().HasData(
                new Angajat { 
                    Id = -1,
                    Nume = "Anastasiei Gheorghe",
                    Marca = 90993,
                    Salariu = 3000,
                    IdDepartament = -1,
                    IdFunctie = -1
                },
                new Angajat
                {
                    Id = -2,
                    Nume = "Cireasa Cristina",
                    Marca = 39921,
                    Salariu = 6000,
                    IdDepartament = -2,
                    IdFunctie = -2
                },
                new Angajat
                {
                    Id = -3,
                    Nume = "Mugur Andrei",
                    Marca = 786654,
                    Salariu = 6000,
                    IdDepartament = -3,
                    IdFunctie = -2
                }
                );
          
        }
    }
}
