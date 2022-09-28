#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data.CMS;
using Projekt.Data.Data.Oferta;

namespace Projekt.Intranet.Data
{
    public class ProjektIntranetContext : DbContext
    {
        public ProjektIntranetContext (DbContextOptions<ProjektIntranetContext> options)
            : base(options)
        {
        }

        public DbSet<Projekt.Data.Data.CMS.CzymSieZajmujemy> CzymSieZajmujemy { get; set; }
        public DbSet<Projekt.Data.Data.CMS.Kontakt> Kontakt { get; set; }
        public DbSet<Projekt.Data.Data.CMS.Opinie> Opinie { get; set; }
        public DbSet<Projekt.Data.Data.CMS.PytaniaIOdpowiedzi> PytaniaIOdpowiedzi { get; set; }
        public DbSet<Projekt.Data.Data.CMS.StronaGlowna> StronaGlowna { get; set; }
        public DbSet<Projekt.Data.Data.Oferta.Oferta> Oferta { get; set; }
        public DbSet<Projekt.Data.Data.Oferta.RodzajTransportu> RodzajTransportu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           if (!optionsBuilder.IsConfigured)
           {
              optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=ProjektContext;Trusted_Connection=True;");
           }
        }

        public DbSet<Projekt.Data.Data.CMS.Stopka>? Stopka { get; set; }


    }
}
