using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KsiegarniaPKP.Models
{
    public class Dostawa
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("Pracownik")]
        public string PracownikId{ get; set; }
        public virtual Uzytkownik Pracownik { get; set; }

        [Required, ForeignKey("Kurier")]
        public string KurierId { get; set; }
        public virtual Uzytkownik Kurier { get; set; }
        public virtual Zamowienie? Zamowienie { get; set; }

        [Required, MaxLength(255)]
        public string Adres { get; set; }

        [Required, MaxLength(20)]
        public string Status { get; set; }

        public bool CzyOplacone { get; set; }

    }
}
