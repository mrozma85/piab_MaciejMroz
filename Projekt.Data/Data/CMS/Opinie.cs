using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Data.Data.CMS
{
    public class Opinie
    {
        [Key]
        public int IdOpini { get; set; }

        [Required(ErrorMessage = "Wpisz link opini")]
        [Display(Name = "Link Opini")]
        public string? LinkOpini{ get; set; }
        public string? Naglowek1Opini { get; set; }
        public string? Naglowek2Opini { get; set; }

        [Required(ErrorMessage = "Wpisz imie i nazwisko dodajacego opinie")]
        [Display(Name = "Imie i nazwisko dodajacego opinie")]
        public string? ImieINazwiskoDodajacego{ get; set; }

        [Display(Name = "Tresc opini")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? TrescOpini{ get; set; }

        public int Pozycja { get; set; }

    }
}
