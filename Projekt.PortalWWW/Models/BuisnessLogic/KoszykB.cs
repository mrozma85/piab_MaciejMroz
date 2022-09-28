using Projekt.Data.Data;
using Projekt.Data.Data.Oferta;
using Microsoft.EntityFrameworkCore;

namespace Projekt.PortalWWW.Models.BuisnessLogic
{
    public class KoszykB
    {
        private readonly ProjektContext _context;
        private string idSesjiKoszyka;

        public KoszykB(ProjektContext context, HttpContext httpContext)
        {
            _context = context;
            idSesjiKoszyka = GetIdSesjiKoszyka(httpContext);
        }
        private string GetIdSesjiKoszyka(HttpContext httpContext)
        {
            if (httpContext.Session.GetString("IdSesjiKoszyka") == null)
            {
                if (!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    httpContext.Session.SetString("IdSesjiKoszyka", httpContext.User.Identity.Name);
                }
                else
                {
                    Guid tempIdSesjiKoszyka = Guid.NewGuid();
                    httpContext.Session.SetString("IdSesjiKoszyka", tempIdSesjiKoszyka.ToString());
                }
            }
            return httpContext.Session.GetString("IdSesjiKoszyka");
        }        
        public void DodajDoKoszyka(RodzajTransportu rodzajTransportu)
        {
            // sprawdzimy najpierw czy elemnty koszyka jest juz towar ktory jest danej przegladarki
            var tempElementUslugi =
                _context.ElementUslugi
                .Where(e => e.IdSesjiKoszyka==idSesjiKoszyka && e.IdRodzajuTransportu == rodzajTransportu.IdRodzajuTransportu)
                .FirstOrDefault();
            //jezeli ta przegladarka ma juz w koszyk ten towar to zwiekszamy przy kazdym dodaniu ilosc o jeden
            if (tempElementUslugi != null)
            {
                tempElementUslugi.Ilosc++;
            }
            else //jezeli nie ma tego towaru przegladarka to go 
            {
                tempElementUslugi = new ElementUslugi() // dodajemy jako element
                {
                    IdSesjiKoszyka = this.idSesjiKoszyka, // dodajemy do danej przgladarki i usatwaimy
                    IdRodzajuTransportu = rodzajTransportu.IdRodzajuTransportu,
                    RodzajTransportu = _context.RodzajTransportu.Find(rodzajTransportu.IdRodzajuTransportu),
                    Ilosc=1,
                    DataUtworzenia=DateTime.Now
                };
                _context.ElementUslugi.Add(tempElementUslugi);     // dodajemy do bazy danych          
            }
            _context.SaveChanges(); // i zapisujemy
        }
        // funkcja zwraca wszystkie elemnty koszyka danego koszyka
                
        public async Task<List<ElementUslugi>> GetElementyKoszykaKlienta()
        {
            return await _context.ElementUslugi.Where(e => e.IdSesjiKoszyka==this.idSesjiKoszyka).Include(e => e.RodzajTransportu).ToListAsync();
        }

        //funkcja zwraca sume wartosci towarow w koszyku danego klienta
        
        public async Task<decimal> GetRazem()
        {
            var items =
            (
                from element in _context.ElementUslugi
                where element.IdSesjiKoszyka == this.idSesjiKoszyka
                select element.RodzajTransportu.Cena*(decimal?)element.Ilosc
            );
            return await items.SumAsync()??0;
        }
    }
    }
