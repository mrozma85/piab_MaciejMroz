using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Data.Data.CMS
{
    public class Stopka
    {
        [Key]
        public int IdStopki { get; set; }

        [Required(ErrorMessage = "Wpisz nazwe stopki")]
        [Display(Name = "Nazwa stopki")]
        public string? NazwaStopki { get; set; }
    }
}
