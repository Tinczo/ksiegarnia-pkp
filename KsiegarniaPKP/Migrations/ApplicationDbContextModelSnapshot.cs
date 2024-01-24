﻿// <auto-generated />
using System;
using KsiegarniaPKP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KsiegarniaPKP.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KsiegarniaPKP.Models.Dokument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataWystawienia")
                        .HasColumnType("datetime2");

                    b.Property<float>("Kwota")
                        .HasColumnType("real");

                    b.Property<string>("Nabywca")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("NrDokumentu")
                        .HasColumnType("int");

                    b.Property<float>("Podatek")
                        .HasColumnType("real");

                    b.Property<string>("PracownikId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PracownikId");

                    b.ToTable("Dokumenty");
                });

            modelBuilder.Entity("KsiegarniaPKP.Models.Dostawa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("CzyOplacone")
                        .HasColumnType("bit");

                    b.Property<string>("KurierId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PracownikId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("KurierId");

                    b.HasIndex("PracownikId");

                    b.ToTable("Dostawy");
                });

            modelBuilder.Entity("KsiegarniaPKP.Models.Ksiazka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<float>("Cena")
                        .HasColumnType("real");

                    b.Property<string>("Gatunek")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Ksiazki");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Autor = "Adam Mickiewicz",
                            Cena = 0.1f,
                            Gatunek = "Horror",
                            Opis = "Straszne rzeczy",
                            Tytul = "Dziady I"
                        },
                        new
                        {
                            Id = 2,
                            Autor = "Adam Mickiewicz",
                            Cena = 2.2f,
                            Gatunek = "Komedia",
                            Opis = "Straszne rzeczy",
                            Tytul = "Dziady II"
                        },
                        new
                        {
                            Id = 3,
                            Autor = "Adam Mickiewicz",
                            Cena = 33.3f,
                            Gatunek = "Dramat",
                            Opis = "Straszne rzeczy",
                            Tytul = "Dziady III"
                        },
                        new
                        {
                            Id = 4,
                            Autor = "Adam Mickiewicz",
                            Cena = 4444.4f,
                            Gatunek = "Powieść obyczajowa",
                            Opis = "Straszne rzeczy",
                            Tytul = "Dziady IV"
                        },
                        new
                        {
                            Id = 5,
                            Autor = "Adam Mickiewicz",
                            Cena = 55555.5f,
                            Gatunek = "Sci-fi",
                            Opis = "Straszne rzeczy",
                            Tytul = "Dziady V"
                        });
                });

            modelBuilder.Entity("KsiegarniaPKP.Models.Oferta", b =>
                {
                    b.Property<int>("OfertaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Dostepnosc")
                        .HasColumnType("bit");

                    b.Property<int>("KsiazkaId")
                        .HasColumnType("int");

                    b.HasKey("OfertaId");

                    b.HasIndex("KsiazkaId");

                    b.ToTable("Oferty");

                    b.HasData(
                        new
                        {
                            OfertaId = 1,
                            Dostepnosc = false,
                            KsiazkaId = 1
                        },
                        new
                        {
                            OfertaId = 2,
                            Dostepnosc = false,
                            KsiazkaId = 2
                        },
                        new
                        {
                            OfertaId = 3,
                            Dostepnosc = true,
                            KsiazkaId = 2
                        },
                        new
                        {
                            OfertaId = 4,
                            Dostepnosc = false,
                            KsiazkaId = 3
                        },
                        new
                        {
                            OfertaId = 5,
                            Dostepnosc = true,
                            KsiazkaId = 3
                        },
                        new
                        {
                            OfertaId = 6,
                            Dostepnosc = true,
                            KsiazkaId = 3
                        },
                        new
                        {
                            OfertaId = 7,
                            Dostepnosc = false,
                            KsiazkaId = 4
                        },
                        new
                        {
                            OfertaId = 8,
                            Dostepnosc = true,
                            KsiazkaId = 4
                        },
                        new
                        {
                            OfertaId = 9,
                            Dostepnosc = true,
                            KsiazkaId = 4
                        },
                        new
                        {
                            OfertaId = 10,
                            Dostepnosc = true,
                            KsiazkaId = 4
                        },
                        new
                        {
                            OfertaId = 11,
                            Dostepnosc = false,
                            KsiazkaId = 5
                        },
                        new
                        {
                            OfertaId = 12,
                            Dostepnosc = true,
                            KsiazkaId = 5
                        },
                        new
                        {
                            OfertaId = 13,
                            Dostepnosc = true,
                            KsiazkaId = 5
                        },
                        new
                        {
                            OfertaId = 14,
                            Dostepnosc = true,
                            KsiazkaId = 5
                        },
                        new
                        {
                            OfertaId = 15,
                            Dostepnosc = true,
                            KsiazkaId = 5
                        });
                });

            modelBuilder.Entity("KsiegarniaPKP.Models.PozycjaKoszyka", b =>
                {
                    b.Property<int>("OfertaId")
                        .HasColumnType("int");

                    b.Property<string>("KlientId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OfertaId", "KlientId");

                    b.HasIndex("KlientId");

                    b.ToTable("PozycjaKoszyka");
                });

            modelBuilder.Entity("KsiegarniaPKP.Models.Uzytkownik", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("KsiegarniaPKP.Models.Zamowienie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DokumentId")
                        .HasColumnType("int");

                    b.Property<int>("DostawaId")
                        .HasColumnType("int");

                    b.Property<string>("KlientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NrZamowienia")
                        .HasColumnType("int");

                    b.Property<string>("PracownikId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DokumentId")
                        .IsUnique();

                    b.HasIndex("DostawaId")
                        .IsUnique();

                    b.HasIndex("KlientId");

                    b.HasIndex("PracownikId");

                    b.ToTable("Zamowienia");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("KsiegarniaPKP.Models.Dokument", b =>
                {
                    b.HasOne("KsiegarniaPKP.Models.Uzytkownik", "Pracownik")
                        .WithMany("PracownikDokumenty")
                        .HasForeignKey("PracownikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pracownik");
                });

            modelBuilder.Entity("KsiegarniaPKP.Models.Dostawa", b =>
                {
                    b.HasOne("KsiegarniaPKP.Models.Uzytkownik", "Kurier")
                        .WithMany("KurierDostawy")
                        .HasForeignKey("KurierId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KsiegarniaPKP.Models.Uzytkownik", "Pracownik")
                        .WithMany("PracownikDostawy")
                        .HasForeignKey("PracownikId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Kurier");

                    b.Navigation("Pracownik");
                });

            modelBuilder.Entity("KsiegarniaPKP.Models.Oferta", b =>
                {
                    b.HasOne("KsiegarniaPKP.Models.Ksiazka", "Ksiazka")
                        .WithMany("Oferty")
                        .HasForeignKey("KsiazkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ksiazka");
                });

            modelBuilder.Entity("KsiegarniaPKP.Models.PozycjaKoszyka", b =>
                {
                    b.HasOne("KsiegarniaPKP.Models.Uzytkownik", "Klient")
                        .WithMany("PozycjeKoszyka")
                        .HasForeignKey("KlientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KsiegarniaPKP.Models.Oferta", "Oferta")
                        .WithMany("PozycjeKoszyka")
                        .HasForeignKey("OfertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klient");

                    b.Navigation("Oferta");
                });

            modelBuilder.Entity("KsiegarniaPKP.Models.Zamowienie", b =>
                {
                    b.HasOne("KsiegarniaPKP.Models.Dokument", "Dokument")
                        .WithOne("Zamowienie")
                        .HasForeignKey("KsiegarniaPKP.Models.Zamowienie", "DokumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KsiegarniaPKP.Models.Dostawa", "Dostawa")
                        .WithOne("Zamowienie")
                        .HasForeignKey("KsiegarniaPKP.Models.Zamowienie", "DostawaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KsiegarniaPKP.Models.Uzytkownik", "Klient")
                        .WithMany("KlientZamowienia")
                        .HasForeignKey("KlientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("KsiegarniaPKP.Models.Uzytkownik", "Pracownik")
                        .WithMany("PracownikZamowienia")
                        .HasForeignKey("PracownikId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Dokument");

                    b.Navigation("Dostawa");

                    b.Navigation("Klient");

                    b.Navigation("Pracownik");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("KsiegarniaPKP.Models.Uzytkownik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("KsiegarniaPKP.Models.Uzytkownik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KsiegarniaPKP.Models.Uzytkownik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("KsiegarniaPKP.Models.Uzytkownik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KsiegarniaPKP.Models.Dokument", b =>
                {
                    b.Navigation("Zamowienie");
                });

            modelBuilder.Entity("KsiegarniaPKP.Models.Dostawa", b =>
                {
                    b.Navigation("Zamowienie");
                });

            modelBuilder.Entity("KsiegarniaPKP.Models.Ksiazka", b =>
                {
                    b.Navigation("Oferty");
                });

            modelBuilder.Entity("KsiegarniaPKP.Models.Oferta", b =>
                {
                    b.Navigation("PozycjeKoszyka");
                });

            modelBuilder.Entity("KsiegarniaPKP.Models.Uzytkownik", b =>
                {
                    b.Navigation("KlientZamowienia");

                    b.Navigation("KurierDostawy");

                    b.Navigation("PozycjeKoszyka");

                    b.Navigation("PracownikDokumenty");

                    b.Navigation("PracownikDostawy");

                    b.Navigation("PracownikZamowienia");
                });
#pragma warning restore 612, 618
        }
    }
}
