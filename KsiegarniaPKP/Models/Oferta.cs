using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace KsiegarniaPKP.Models
{
    public class Oferta
    {
        [Key]
        public int OfertaId { get; set; }

        [ForeignKey("Ksiazka")]
        public int KsiazkaId { get; set; }
        public bool Dostepnosc { get; set; }

        public virtual Ksiazka Ksiazka { get; set; }

        public virtual List<PozycjaKoszyka> PozycjeKoszyka { get; set; } = new List<PozycjaKoszyka>();
    }
}
