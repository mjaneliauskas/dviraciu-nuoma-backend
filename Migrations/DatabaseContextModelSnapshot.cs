// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using dviraciu_nuoma_backend.Repository;

#nullable disable

namespace dviraciu_nuoma_backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("dviraciu_nuoma_backend.Models.DviratisModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("DviracioKaina")
                        .HasColumnType("double precision");

                    b.Property<string>("DviracioSpecifikacija")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DviracioStatusas")
                        .HasColumnType("integer");

                    b.Property<int>("DviracioTipas")
                        .HasColumnType("integer");

                    b.Property<string>("dviracioPavadinimas")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Dviratis");
                });

            modelBuilder.Entity("dviraciu_nuoma_backend.Models.KelioneModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DviratisId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("KelionesPabaiga")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("KelionesPradzia")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("VartotojasId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DviratisId");

                    b.HasIndex("VartotojasId");

                    b.ToTable("Kelione");
                });

            modelBuilder.Entity("dviraciu_nuoma_backend.Models.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ElPastas")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PrisijungimoVardas")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Slaptazodis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("dviraciu_nuoma_backend.Models.KelioneModel", b =>
                {
                    b.HasOne("dviraciu_nuoma_backend.Models.DviratisModel", "Dviratis")
                        .WithMany()
                        .HasForeignKey("DviratisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dviraciu_nuoma_backend.Models.UserModel", "Vartotojas")
                        .WithMany()
                        .HasForeignKey("VartotojasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dviratis");

                    b.Navigation("Vartotojas");
                });
#pragma warning restore 612, 618
        }
    }
}
