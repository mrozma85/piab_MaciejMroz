using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Data.Data.CMS
{
    public class Nawigacja
    {
        [Key]
        public int IdNawigacji { get; set; }

        [Required(ErrorMessage = "Wpisz tytul nawigacji")]
        [Display(Name = "Link nawigacji")]
        public string LinkNawigacji { get; set; }

        [Required(ErrorMessage = "Wpisz tytul nawigacji")]
        [Display(Name = "Tytul nawigacji")]
        public string TytulNawigacji { get; set; }

        [Display(Name = "Tresc")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string TrescNawigacji { get; set; }
        public int Pozycja { get; set; }
    }
}
