using KsiegarniaPKP.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KsiegarniaPKP.Data
{
    public static class DataInitializer
    {
        public static void SeedDatabase(this ModelBuilder modelBuilder)
        {
            Constants c = new Constants();

            List<Ksiazka> ksiazkas = new List<Ksiazka>();
            List<Oferta> ofertas = new List<Oferta>();
            List<PozycjaKoszyka> pozycjakoszykas = new List<PozycjaKoszyka>();

            // Ksiazki

            ksiazkas.Add(new()
            {
                Id = 1,
                Autor = "Adam Mickiewicz",
                Tytul = "Dziady I",
                Gatunek = "Horror",
                Opis = "Straszne rzeczy",
                Cena = 0.1F
            });

            ksiazkas.Add(new()
            {
                Id = 2,
                Autor = "Adam Mickiewicz",
                Tytul = "Dziady II",
                Gatunek = "Komedia",
                Opis = "Straszne rzeczy",
                Cena = 2.2F
            });

            ksiazkas.Add(new()
            {
                Id = 3,
                Autor = "Adam Mickiewicz",
                Tytul = "Dziady III",
                Gatunek = "Dramat",
                Opis = "Straszne rzeczy",
                Cena = 33.3F
            });

            ksiazkas.Add(new()
            {
                Id = 4,
                Autor = "Adam Mickiewicz",
                Tytul = "Dziady IV",
                Gatunek = "Powieść obyczajowa",
                Opis = "Straszne rzeczy",
                Cena = 4444.4F
            });

            ksiazkas.Add(new()
            {
                Id = 5,
                Autor = "Adam Mickiewicz",
                Tytul = "Dziady V",
                Gatunek = "Sci-fi",
                Opis = "Straszne rzeczy",
                Cena = 55555.5F
            });;

            // Oferty

            // 1

            ofertas.Add(new ()
            {
                OfertaId = 1,
                KsiazkaId = 1,
                Dostepnosc = false
            });

            // 2

            ofertas.Add(new()
            {
                OfertaId = 2,
                KsiazkaId = 2,
                Dostepnosc = false
            });

            ofertas.Add(new()
            {
                OfertaId = 3,
                KsiazkaId = 2,
                Dostepnosc = true
            });

            // 3

            ofertas.Add(new()
            {
                OfertaId = 4,
                KsiazkaId = 3,
                Dostepnosc = false
            });

            ofertas.Add(new()
            {
                OfertaId = 5,
                KsiazkaId = 3,
                Dostepnosc = true
            });

            ofertas.Add(new()
            {
                OfertaId = 6,
                KsiazkaId = 3,
                Dostepnosc = true
            });

            // 4

            ofertas.Add(new()
            {
                OfertaId = 7,
                KsiazkaId = 4,
                Dostepnosc = false
            });

            ofertas.Add(new()
            {
                OfertaId = 8,
                KsiazkaId = 4,
                Dostepnosc = true
            });

            ofertas.Add(new()
            {
                OfertaId = 9,
                KsiazkaId = 4,
                Dostepnosc = true
            });

            ofertas.Add(new()
            {
                OfertaId = 10,
                KsiazkaId = 4,
                Dostepnosc = true
            });

            // 5

            ofertas.Add(new()
            {
                OfertaId = 11,
                KsiazkaId = 5,
                Dostepnosc = false
            });

            ofertas.Add(new()
            {
                OfertaId = 12,
                KsiazkaId = 5,
                Dostepnosc = true
            });

            ofertas.Add(new()
            {
                OfertaId = 13,
                KsiazkaId = 5,
                Dostepnosc = true
            });

            ofertas.Add(new()
            {
                OfertaId = 14,
                KsiazkaId = 5,
                Dostepnosc = true
            });

            ofertas.Add(new()
            {
                OfertaId = 15,
                KsiazkaId = 5,
                Dostepnosc = true
            });

            modelBuilder.Entity<Ksiazka>().HasData(ksiazkas);
            modelBuilder.Entity<Oferta>().HasData(ofertas);
            // Pozycje koszyka

            pozycjakoszykas.Add(new()
            {
                OfertaId = 1,
                KlientId = c.createId(0)
            });

            pozycjakoszykas.Add(new()
            {
                OfertaId = 2,
                KlientId = c.createId(0)
            });

            pozycjakoszykas.Add(new()
            {
                OfertaId = 4,
                KlientId = c.createId(0)
            });

            pozycjakoszykas.Add(new()
            {
                OfertaId = 7,
                KlientId = c.createId(0)
            });

            pozycjakoszykas.Add(new()
            {
                OfertaId = 11,
                KlientId = c.createId(0)
            });

            modelBuilder.Entity<PozycjaKoszyka>().HasData(pozycjakoszykas);
        }
    }
}
