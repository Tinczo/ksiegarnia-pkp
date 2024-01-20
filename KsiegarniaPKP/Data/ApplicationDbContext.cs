using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KsiegarniaPKP.Models;

namespace KsiegarniaPKP.Models
{
    // Twoja klasa kontekstu
    public class ApplicationDbContext : IdentityDbContext<Uzytkownik>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Definicje DbSet dla wszystkich encji
        public DbSet<Uzytkownik> Uzytkownik { get; set; }
        public DbSet<Oferta> Oferty { get; set; }
        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Dokument> Dokumenty { get; set; }
        public DbSet<Dostawa> Dostawy { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }

        // Tutaj konfigurujesz relacje między encjami
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ksiazka - Oferta
            modelBuilder.Entity<Ksiazka>()
                .HasMany(k => k.Oferty)
                .WithOne(o => o.Ksiazka)
                .HasForeignKey(o => o.KsiazkaId);

            // PozycjaKoszyka klucz
            modelBuilder.Entity<PozycjaKoszyka>()
                .HasKey(t => new { t.OfertaId, t.KlientId});

            // PozycjaKoszyka - Uzytkownik
            modelBuilder.Entity<PozycjaKoszyka>()
                .HasOne(pk => pk.Klient)
                .WithMany(zu => zu.PozycjeKoszyka)
                .HasForeignKey(pk => pk.KlientId);

            // PozycjaKoszyka - Oferta
            modelBuilder.Entity<PozycjaKoszyka>()
                .HasOne(pk => pk.Oferta)
                .WithMany(o => o.PozycjeKoszyka)
                .HasForeignKey(pk => pk.OfertaId);

            // Uzytkownik - Dostawa
            modelBuilder.Entity<Dostawa>()
                .HasOne(d => d.Pracownik)
                .WithMany(u => u.PracownikDostawy)
                .HasForeignKey(d => d.PracownikId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Dostawa>()
                .HasOne(d => d.Kurier)
                .WithMany(u => u.KurierDostawy)
                .HasForeignKey(d => d.KurierId)
                .OnDelete(DeleteBehavior.Restrict);

            // Dostawa - Zamowienia
            modelBuilder.Entity<Dostawa>()
                .HasOne(d => d.Zamowienie)
                .WithOne(z => z.Dostawa)
                .HasForeignKey<Zamowienie>(z => z.DostawaId);

            // Uzytkownik - Zamowienie
            modelBuilder.Entity<Zamowienie>()
                .HasOne(z => z.Klient)
                .WithMany(u => u.KlientZamowienia)
                .HasForeignKey(z => z.KlientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Zamowienie>()
                .HasOne(z => z.Pracownik)
                .WithMany(u => u.PracownikZamowienia)
                .HasForeignKey(z => z.PracownikId)
                .OnDelete(DeleteBehavior.Restrict);

            // Dokument - Zamowienie
            modelBuilder.Entity<Dokument>()
                .HasOne(d => d.Zamowienie)
                .WithOne(z => z.Dokument)
                .HasForeignKey<Zamowienie>(z => z.DokumentId);

            // Uzytkownik - Dokument
            modelBuilder.Entity<Dokument>()
                .HasOne(d => d.Pracownik)
                .WithMany(u => u.PracownikDokumenty)
                .HasForeignKey(d => d.PracownikId);
        }

        // Tutaj konfigurujesz relacje między encjami
        public DbSet<KsiegarniaPKP.Models.PozycjaKoszyka> PozycjaKoszyka { get; set; }
    }
}
