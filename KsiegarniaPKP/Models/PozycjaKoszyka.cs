using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KsiegarniaPKP.Models
{
    public class PozycjaKoszyka
    {
        [Key, Column(Order = 0), ForeignKey("Oferta")]
        public int OfertaId { get; set; }

        [Key, Column(Order = 1), ForeignKey("Klient")]
        public string KlientId { get; set; }

        public virtual Oferta Oferta { get; set; }
        public virtual Uzytkownik Klient { get; set; }

    }
}
