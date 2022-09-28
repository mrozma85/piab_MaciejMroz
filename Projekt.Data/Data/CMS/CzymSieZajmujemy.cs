using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Data.Data.CMS
{
    public class CzymSieZajmujemy
    {
        [Key]
        public int IdCzymSieZajmujemy { get; set; }

        [Required(ErrorMessage = "Wpisz tytul CzymSieZajmujemy")]
        [Display(Name = "Link CzymSieZajmujemy")]
        public string LinkCzymSieZajmujemy { get; set; }

        [Required(ErrorMessage = "Wpisz tytul CzymSieZajmujemy")]
        [Display(Name = "Tytul CzymSieZajmujemy")]
        public string TytulCzymSieZajmujemy { get; set; }

        [Display(Name = "Tresc")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Tresc1CzymSieZajmujemy { get; set; }

        [Display(Name = "Tresc")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Tresc2CzymSieZajmujemy { get; set; }
        public int Pozycja { get; set; }

    }
}
