using P04Zawodnicy.Shared.Data;
using P04Zawodnicy.Shared.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04Zawodnicy.Shared.Services
{     
    internal class ManagerZawodnikowLINQ : IManagerZawodnikow
    {
        public void Dodaj(Zawodnik z)
        {
            using (ModelBazyDataContext db = new ModelBazyDataContext())
            {
                var zb = new ZawodnikDb();
                mapujNaZawodnikaDb(z, zb);
                db.ZawodnikDb.InsertOnSubmit(zb);
                db.SubmitChanges();
            }           
        }

        private void mapujNaZawodnikaDb(Zawodnik z, ZawodnikDb zb)
        {
            zb.id_zawodnika = z.Id_zawodnika;
            zb.imie = z.Imie;
            zb.nazwisko = z.Nazwisko;
            zb.kraj = z.Kraj;
            zb.data_ur = z.DataUrodzenia;
            zb.wzrost = z.Wzrost;
            zb.waga = z.Waga;
            zb.id_trenera = z.Id_trenera;

        }

        public void Edytuj(Zawodnik edytowany)
        {
            using (ModelBazyDataContext db = new ModelBazyDataContext())
            {
                ZawodnikDb zd = db.ZawodnikDb.FirstOrDefault(x => x.id_zawodnika == edytowany.Id_zawodnika);
                mapujNaZawodnikaDb(edytowany, zd);
                db.SubmitChanges();
            }
        }

        public string[] PodajKraje()
        {
            using (ModelBazyDataContext db = new ModelBazyDataContext())
            {
                 return db.ZawodnikDb
                    .GroupBy(x=>x.kraj)
                    .Select(x=>x.Key)
                    .ToArray();
            }
        }

        public int PodajSredniWiekZawodnikow(string kraj)
        {
            using (ModelBazyDataContext db = new ModelBazyDataContext())
            {
                var sredniWiek=  db.ZawodnikDb
                   .Where(x => x.kraj.Equals(kraj))
                   .Select(x => DateTime.Now.Year - x.data_ur.Value.Year)
                   .Average();
                return Convert.ToInt32(sredniWiek);
            }
        }

        public double PodajSredniWzrost(string kraj)
        {
            using (ModelBazyDataContext db = new ModelBazyDataContext())
            {
                return db.ZawodnikDb
                   .Where(x => x.kraj.Equals(kraj))     
                   .Average(x=>x.wzrost).Value;
            }
        }

        public Trener[] PodajTrenerow()
        {
            using (ModelBazyDataContext db = new ModelBazyDataContext())
            {
                var ternerzy = db.TrenerDb.Select(x => new Trener()
                {
                    Id = x.id_trenera,
                    Imie = x.imie_t,
                    Nazwisko = x.nazwisko_t,
                }).ToArray();
                return ternerzy;
            }
        }

        public Zawodnik[] PodajZawodnikow(string kraj)
        {
            throw new NotImplementedException();
        }

        public void Usun(int id)
        {
            throw new NotImplementedException();
        }

        public List<Zawodnik> WczytajZawodnikow()
        {
            throw new NotImplementedException();
        }

        public List<Osoba> WyszukajOsoby(string text)
        {
            throw new NotImplementedException();
        }
    }
}
