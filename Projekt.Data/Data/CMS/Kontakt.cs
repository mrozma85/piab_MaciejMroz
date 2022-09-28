using System.ComponentModel.DataAnnotations;

namespace Projekt.Data.Data.CMS
{
    public class Kontakt
    {
        [Key]
        public int IdKontaktu { get; set; }

        [Required(ErrorMessage = "Wpisz pelna tresc kontaktu")]
        [Display(Name = "Tresc kontaktu")]
        public string TrescKontaktu { get; set; }

        public int Pozycja { get; set; }
    }
}