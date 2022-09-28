using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Data.Data.Oferta
{
    public class ElementUslugi
    {
        [Key]
        public int IdElementuUslugi { get; set; }
        public string IdSesjiKoszyka { get; set; } // id przegladarki
        public int IdRodzajuTransportu { get; set; }
        public RodzajTransportu RodzajTransportu { get; set; }
        public int Ilosc { get; set; }
        public DateTime DataUtworzenia { get; set; }
    }
}
