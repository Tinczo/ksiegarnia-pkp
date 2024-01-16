using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace KsiegarniaPKP.Models
{
    public class Dokument
    {
        [Key]
        public int Id { get; set; }
        [Required, ForeignKey("Pracownik")]
        public string PracownikId { get; set; }
        public virtual Uzytkownik Pracownik { get; set; }
        public virtual Zamowienie? Zamowienie { get; set; }
        [Required]
        public int NrDokumentu { get; set; }
        [Required]
        public DateTime DataWystawienia { get; set; }
        [Required, MaxLength(255)]
        public string Nabywca { get; set; }
        [Required]
        public float Kwota { get; set; }
        [Required]
        public float Podatek { get; set; }
    }
}
