using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KsiegarniaPKP.Models
{
    public class Uzytkownik : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string Imie { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nazwisko { get; set; }
        [Required]
        [MaxLength(20)]
        public string Rola { get; set; }

        public virtual List<PozycjaKoszyka> PozycjeKoszyka { get; set; } = new List<PozycjaKoszyka>();
        public virtual List<Dostawa> PracownikDostawy { get; set; } = new List<Dostawa>();
        public virtual List<Dostawa> KurierDostawy { get; set; } = new List<Dostawa>();
        public virtual List<Zamowienie> KlientZamowienia { get; set; } = new List<Zamowienie>();
        public virtual List<Zamowienie> PracownikZamowienia { get; set; } = new List<Zamowienie>();
        public virtual List<Dokument> PracownikDokumenty { get; set; } = new List<Dokument>();

    }
}
