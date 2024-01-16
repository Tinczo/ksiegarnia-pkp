using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KsiegarniaPKP.Models
{
    public class Ksiazka
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Autor { get; set; }

        [Required, MaxLength(255)]
        public string Tytul { get; set; }

        public int RokWydania { get; set; }

        [Required, MaxLength(255)]
        public string Opis { get; set; }
        [Required]
        public float Cena { get; set; }

        public virtual List<Oferta> Oferty { get; set; } = new List<Oferta>();
    }
}
