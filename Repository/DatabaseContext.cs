using System.Collections.Generic;
using System.Configuration;
using System.Numerics;
using System.Reflection.Emit;
using dviraciu_nuoma_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace dviraciu_nuoma_backend.Repository
{
    public class DatabaseContext: DbContext
    {
        string connectionString;
        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration config) : base(options)
        {
            connectionString = config.GetConnectionString("NsqlConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                        .UseNpgsql($@"{connectionString}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserModel>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<DviratisModel>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<KelioneModel>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<KelioneModel>().Navigation(e => e.Dviratis).AutoInclude();
            modelBuilder.Entity<KelioneModel>().Navigation(e => e.Vartotojas).AutoInclude();
            //modelBuilder.Entity<Player>().Navigation(e => e.Team);
        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<DviratisModel> Dviratis { get; set; }
        public DbSet<KelioneModel> Kelione { get; set; }


        
        public static void SeedDatabase(DatabaseContext context)
        {
            
            var users = new List<UserModel>()
            {
                new UserModel()
                {
                    ElPastas = "user@user.com",
                    PrisijungimoVardas = "user",
                    Role = RoleEnum.USER,
                    Slaptazodis = "user"
                },
                new UserModel()
                {
                    ElPastas = "admin@admin.com",
                    PrisijungimoVardas = "admin",
                    Role = RoleEnum.ADMIN,
                    Slaptazodis = "admin"
                },
            };
            if (!context.User.Any())
            {
                context.User.AddRange(users);
            }

            var dviraciai = new List<DviratisModel>() {
                new DviratisModel
                {
                    DviracioKaina = 10,
                    dviracioPavadinimas = "Kregždutė",
                    DviracioSpecifikacija = "Kregždutė yra miesto dviratis, skirtas važinėti dviračių takais, jo ratų dydis yra 21, svoris 5,4 kg. Dažniausiai šį dviratį renkasi senjorai.",
                    DviracioStatusas = DviracioStatusasEnum.LAISVAS,
                    DviracioTipas = DviracioTipasEnum.MIESTO
                },
                new DviratisModel
                {
                    DviracioKaina = 11,
                    dviracioPavadinimas = "Saulutė",
                    DviracioSpecifikacija = "Saulutė yra miesto dviratis, skirtas važinėti dviračių takais, jo ratų dydis yra 21, svoris 4,4 kg. Dažniausiai šį dviratį renkasi senjorės.",
                    DviracioStatusas = DviracioStatusasEnum.LAISVAS,
                    DviracioTipas = DviracioTipasEnum.MIESTO
                },
                new DviratisModel
                {
                    DviracioKaina = 23,
                    dviracioPavadinimas = "Formulė",
                    DviracioSpecifikacija = "Formulė yra plentinis dviratis, skirtas važinėti keliais, jo ratų dydis yra 23, svoris 3,2 kg. Dažniausiai šį dviratį renkasi sportininkai.",
                    DviracioStatusas = DviracioStatusasEnum.LAISVAS,
                    DviracioTipas = DviracioTipasEnum.PLENTINIS
                },
                new DviratisModel
                {
                    DviracioKaina = 24,
                    dviracioPavadinimas = "Kulka",
                    DviracioSpecifikacija = "Kulka yra plentinis dviratis, skirtas važinėti keliais, jo ratų dydis yra 23, svoris 3,1 kg. Dažniausiai šį dviratį renkasi sportininkės.",
                    DviracioStatusas = DviracioStatusasEnum.LAISVAS,
                    DviracioTipas = DviracioTipasEnum.PLENTINIS
                },
                new DviratisModel
                 {
                    DviracioKaina = 42,
                    dviracioPavadinimas = "Rampa",
                    DviracioSpecifikacija = "Rampa yra sportinis dviratis, skirtas važinėti ant rampų, jo ratų dydis yra 18, svoris 5,2 kg. Dažniausiai šį dviratį renkasi pradedantieji.",
                    DviracioStatusas = DviracioStatusasEnum.LAISVAS,
                    DviracioTipas = DviracioTipasEnum.SPORTINIS
                },
                new DviratisModel
                 {
                    DviracioKaina = 45,
                    dviracioPavadinimas = "Pagieža",
                    DviracioSpecifikacija = "Pagieža yra sportinis dviratis, skirtas važinėti ant rampų, jo ratų dydis yra 18, svoris 4,8 kg. Dažniausiai šį dviratį renkasi pažengę.",
                    DviracioStatusas = DviracioStatusasEnum.LAISVAS,
                    DviracioTipas = DviracioTipasEnum.SPORTINIS
                },
                new DviratisModel
                 {
                    DviracioKaina = 60,
                    dviracioPavadinimas = "Hardas",
                    DviracioSpecifikacija = "Hardas yra sportinis dviratis, skirtas važinėti ant rampų, jo ratų dydis yra 18, svoris 4,3 kg. Dažniausiai šį dviratį renkasi profesionalai.",
                    DviracioStatusas = DviracioStatusasEnum.LAISVAS,
                    DviracioTipas = DviracioTipasEnum.SPORTINIS
                },
            };
           
            if (!context.Dviratis.Any())
            {
                context.Dviratis.AddRange(dviraciai);
            }
            context.SaveChanges();
        }
       

    }
}
