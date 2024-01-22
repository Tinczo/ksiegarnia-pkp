using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KsiegarniaPKP.Models
{
    public class Ksiazka
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Autor { get; set; }

        [Required, MaxLength(100)]
        public string Tytul { get; set; }

        public int RokWydania { get; set; }

        [Required, MaxLength(500)]
        public string Opis { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public float Cena { get; set; }

        [Required, MaxLength(255)]
        public string ObrazekUrl { get; set; }

        public virtual List<Oferta> Oferty { get; set; } = new List<Oferta>();
    }

    public class KsiazkaCreateView
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Autor { get; set; }

        [Required, MaxLength(100)]
        public string Tytul { get; set; }

        public int RokWydania { get; set; }

        [Required, MaxLength(500)]
        public string Opis { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public float Cena { get; set; }

        [Required]
        public IFormFile Obrazek { get; set; }

        public virtual List<Oferta> Oferty { get; set; } = new List<Oferta>();
    }

    public class KsiazkaEditView
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Autor { get; set; }

        [Required, MaxLength(100)]
        public string Tytul { get; set; }

        public int RokWydania { get; set; }

        [Required, MaxLength(500)]
        public string Opis { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public float Cena { get; set; }

        public IFormFile Obrazek { get; set; }

        public virtual List<Oferta> Oferty { get; set; } = new List<Oferta>();
    }
}
