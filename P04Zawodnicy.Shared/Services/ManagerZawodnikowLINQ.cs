using P04Zawodnicy.Shared.Data;
using P04Zawodnicy.Shared.Domains;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04Zawodnicy.Shared.Services
{     
    public class ManagerZawodnikowLINQ : IManagerZawodnikow
    {
        // private readonly string connString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=A_Zawodnicy;Integrated Security=True;Encrypt=False";
        private readonly string connString;
        public ManagerZawodnikowLINQ()
        {
            connString = ConfigurationManager.ConnectionStrings["A_ZawodnicyConnectionString"].ConnectionString;
        }
        public void Dodaj(Zawodnik z)
        {
            using (ModelBazyDataContext db = new ModelBazyDataContext(connString))
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
            using (ModelBazyDataContext db = new ModelBazyDataContext(connString))
            {
                ZawodnikDb zd = db.ZawodnikDb.FirstOrDefault(x => x.id_zawodnika == edytowany.Id_zawodnika);
                mapujNaZawodnikaDb(edytowany, zd);
                db.SubmitChanges();
            }
        }

        public string[] PodajKraje()
        {
            using (ModelBazyDataContext db = new ModelBazyDataContext(connString))
            {
                 return db.ZawodnikDb
                    .GroupBy(x=>x.kraj)
                    .Select(x=>x.Key)
                    .ToArray();
            }
        }

        public int PodajSredniWiekZawodnikow(string kraj)
        {
            using (ModelBazyDataContext db = new ModelBazyDataContext(connString))
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
            using (ModelBazyDataContext db = new ModelBazyDataContext(connString))
            {
                return db.ZawodnikDb
                   .Where(x => x.kraj.Equals(kraj))     
                   .Average(x=>x.wzrost).Value;
            }
        }

        public Trener[] PodajTrenerow()
        {
            using (ModelBazyDataContext db = new ModelBazyDataContext(connString))
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
            using (ModelBazyDataContext db = new ModelBazyDataContext(connString))
            {
                var zawodnicyDb = db.ZawodnikDb
                    .Where(x => x.kraj == kraj)
                    .ToArray();

                return mapujZawodnikow(zawodnicyDb);
            }
        }

        private Zawodnik[] mapujZawodnikow(params ZawodnikDb[] dane)
        {
            Zawodnik[] tab = new Zawodnik[dane.Length];
            for (int i = 0; i < dane.Length; i++)
            {
                tab[i] = new Zawodnik()
                {
                    Id_zawodnika = dane[i].id_zawodnika,
                    Id_trenera = dane[i].id_trenera,
                    Imie = dane[i].imie,
                    Nazwisko = dane[i].nazwisko,
                    Kraj = dane[i].kraj,
                    Wzrost = (int)dane[i].wzrost,
                    Waga = (int)dane[i].waga,
                };
            }
            return tab;
        }

        public void Usun(int id)
        {
            using(ModelBazyDataContext db = new ModelBazyDataContext(connString))
            {
                var usuwany = db.ZawodnikDb.FirstOrDefault(x=>x.id_zawodnika == id);
                db.ZawodnikDb.DeleteOnSubmit(usuwany);
                db.SubmitChanges();
            }
        }

        public List<Zawodnik> WczytajZawodnikow()
        {
            using (ModelBazyDataContext db = new ModelBazyDataContext(connString))
            {
                var zawodnicyDb = db.ZawodnikDb.ToArray();
                return mapujZawodnikow(zawodnicyDb).ToList();
            }
        }
        public List<Osoba> WyszukajOsoby(string text)
        {
            using (ModelBazyDataContext db = new ModelBazyDataContext(connString))
            {
                var zawodnicy = db.ZawodnikDb
                    .Where(x => x.imie.Contains(text) || x.nazwisko.Contains(text))
                    .Select(x => new Osoba()
                    {
                        Imie = x.imie,
                        Nazwisko = x.nazwisko,
                    }).ToList();

                var trenerzy = db.TrenerDb
                   .Where(x => x.imie_t.Contains(text) || x.nazwisko_t.Contains(text))
                   .Select(x => new Osoba()
                   {
                       Imie = x.imie_t,
                       Nazwisko = x.nazwisko_t,
                   }).ToList();

                return zawodnicy.Concat(trenerzy).ToList();
            }
        }

        public GrupaKraju[] PodajSerdniWzrostDlaKazdegoKraju()
        {
            
            using(ModelBazyDataContext db = new ModelBazyDataContext(connString))
            {
                return db.ZawodnikDb
                    .GroupBy(x=>x.kraj)
                    .Select(x=> new GrupaKraju()
                    {
                        Kraj = x.Key,
                        SredniWzrost = x.Average(y=>y.wzrost).Value
                    }).ToArray();
            }
        }
    }
}
