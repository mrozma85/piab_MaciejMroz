using System.ComponentModel.DataAnnotations;

namespace Projekt.Data.Data.Oferta
{
    public class Oferta
    {
        [Key]
        public int IdOferty { get; set; }

        [Required(ErrorMessage = "Wpisz nazwe rodzaju")]
        [MaxLength(25, ErrorMessage = "Nazwa powinnina zawierac maks 25 znakow")]
        public string? Nazwa { get; set; }
        public string? Opis { get; set; }
        public List<RodzajTransportu>? RodzajTransportu{ get; set; }
    }
}
