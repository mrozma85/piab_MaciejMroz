using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data.CMS;
using Projekt.Data.Data.Oferta;

namespace Projekt.Data.Data
{
    public class ProjektContext : DbContext
    {
        public ProjektContext(DbContextOptions<ProjektContext> options)
            : base(options)
        {
        }

        public DbSet<Nawigacja> Nawigacja { get; set; }
        public DbSet<CzymSieZajmujemy> CzymSieZajmujemy { get; set; }
        public DbSet<Opinie> Opinie { get; set; }
        public DbSet<PytaniaIOdpowiedzi> PytaniaIOdpowiedzi { get; set; }
        public DbSet<Kontakt> Kontakt { get; set; }
        public DbSet<Stopka> Stopka { get; set; }
        public DbSet<StronaGlowna> StronaGlowna{ get; set; }
        public DbSet<Oferta.Oferta> Oferta { get; set; }
        public DbSet<RodzajTransportu> RodzajTransportu{ get; set; }
        public DbSet<ElementUslugi> ElementUslugi { get; set; }

    }
}