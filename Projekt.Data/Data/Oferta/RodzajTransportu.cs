using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Data.Data.Oferta
{
    public class RodzajTransportu
    {
        [Key]
        public int IdRodzajuTransportu { get; set; }

        [Required(ErrorMessage = "Kod oferty jest wymagany")]
        public string? Kod { get; set; }

        [Required(ErrorMessage = "Nazwa oferty jest wymagana")]
        public string? Nazwa { get; set; }

        [Required(ErrorMessage = "Cena oferty jest wymagana")]
        [Column(TypeName = "money")]
        public decimal Cena { get; set; }

        public int IdOferty { get; set; }
        public Oferta? Oferta { get; set; }
        [Display(Name = "Czy oferta jest promowana?")]
        public bool PromocjaOferty { get; set; }
    }
}
