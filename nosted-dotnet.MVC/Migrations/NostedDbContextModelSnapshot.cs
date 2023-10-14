﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using nosted_dotnet.MVC.Entities;

#nullable disable

namespace nosted_dotnet.MVC.Migrations
{
    [DbContext(typeof(NostedDbContext))]
    partial class NostedDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("nosted_dotnet.MVC.Entities.CheckList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CheckListId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ConsumedHours")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerCity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerComment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerStreet")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerTelephoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerZipcode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mechanic")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MechanicComment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VinsjModel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VinsjType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CheckLists");
                });

            modelBuilder.Entity("nosted_dotnet.MVC.Entities.ChecklistCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CheckListId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CheckListId");

                    b.ToTable("ChecklistCategory");
                });

            modelBuilder.Entity("nosted_dotnet.MVC.Entities.ServiceSchema", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Arbeidstimer")
                        .HasColumnType("TEXT");

                    b.Property<string>("AvtaltMedKunden")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FerdigDato")
                        .HasColumnType("TEXT");

                    b.Property<string>("ForsendelsesMåte")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Kunde")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KundeAdresse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KundeMail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KundeTelefonNr")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MedgåtteDeler")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("MotattDato")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OrdreNummer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Produkttype")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RepBeskrivelse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Serienummer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceRep")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SignaturKunde")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SignaturRep")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UtskiftetDelerRetur")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Årsmodell")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ServiceSchemas");
                });

            modelBuilder.Entity("nosted_dotnet.MVC.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adresse")
                        .HasColumnType("TEXT");

                    b.Property<string>("Etternavn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Navn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Stilling")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefonnummer")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("nosted_dotnet.MVC.Entities.CheckList", b =>
                {
                    b.HasOne("nosted_dotnet.MVC.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("nosted_dotnet.MVC.Entities.ChecklistCategory", b =>
                {
                    b.HasOne("nosted_dotnet.MVC.Entities.CheckList", null)
                        .WithMany("ChecklistCategories")
                        .HasForeignKey("CheckListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("nosted_dotnet.MVC.Entities.ServiceSchema", b =>
                {
                    b.HasOne("nosted_dotnet.MVC.Entities.CheckList", "CheckList")
                        .WithOne("ServiceSchema")
                        .HasForeignKey("nosted_dotnet.MVC.Entities.ServiceSchema", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CheckList");
                });

            modelBuilder.Entity("nosted_dotnet.MVC.Entities.CheckList", b =>
                {
                    b.Navigation("ChecklistCategories");

                    b.Navigation("ServiceSchema")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
