using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Data.Data.CMS
{
    public class PytaniaIOdpowiedzi
    {
        [Key]
        public int IdPytaniaIOdpowiedzi { get; set; }

        [Required(ErrorMessage = "Wpisz link pytania i odpowiedzi")]
        [Display(Name = "Link pytania i odpowiedzi")]
        public string? LinkPytaniaIOdpowiedzi { get; set; }

        [Required(ErrorMessage = "Wpisz tytul Pytania I Odpowiedzi")]
        [Display(Name = "Tytul Pytania I Odpowiedzi")]
        public string? TytulPytaniaIOdpowiedzi { get; set; }

        [Display(Name = "Tresc pytania i odpowiedzi")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? TrescPytaniaIOdpowiedzi { get; set; }
        public string? TytulGlownyPytaniaIOdpowiedzi { get; set; }

        public int Pozycja { get; set; }

    }
}