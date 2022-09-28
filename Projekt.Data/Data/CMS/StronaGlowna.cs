using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Data.Data.CMS
{
    public class StronaGlowna
    {
        [Key]
        public int IdStronyGlownej { get; set; }

        [Required(ErrorMessage = "Wpisz tytul 1")]
        [Display(Name = "Tytul1 StronyGlownej")]
        public string Tytul1StronyGlownej { get; set; }

        [Required(ErrorMessage = "Wpisz tytul 2")]
        [Display(Name = "Tytul2 StronyGlownej")]
        public string Tytul2StronyGlownej { get; set; }
    }
}
