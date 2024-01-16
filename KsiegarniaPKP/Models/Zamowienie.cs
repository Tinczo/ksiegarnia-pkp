using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KsiegarniaPKP.Models
{
    public class Zamowienie
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Dostawa")]
        public int DostawaId { get; set; }
        public virtual Dostawa Dostawa { get; set; }

        [ForeignKey("Klient")]
        public int KlientId { get; set; }
        public virtual Uzytkownik Klient { get; set; }

        [ForeignKey("Pracownik")]
        public int PracownikId { get; set; }
        public virtual Uzytkownik Pracownik { get; set; }

        [ForeignKey("Dokument")]
        public int DokumentId { get; set; }
        public virtual Dokument Dokument { get; set; }
        [Required]
        public int NrZamowienia { get; set; }
    }
}
