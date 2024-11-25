using P04Zawodnicy.Shared.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04Zawodnicy.Shared.Services
{
    public class ManagerZawodnikowFake : IManagerZawodnikow
    {
        public void Dodaj(Zawodnik z)
        {
            throw new NotImplementedException();
        }

        public void Edytuj(Zawodnik edytowany)
        {
            throw new NotImplementedException();
        }

        public string[] PodajKraje()
        {
            return new string[] { "POL", "GER" };
        }

        public GrupaKraju[] PodajSerdniWzrostDlaKazdegoKraju()
        {
            throw new NotImplementedException();
        }

        public int PodajSredniWiekZawodnikow(string kraj)
        {
            throw new NotImplementedException();
        }

        public double PodajSredniWzrost(string kraj)
        {
            return 100;
        }

        public Trener[] PodajTrenerow()
        {
            throw new NotImplementedException();
        }

        public Zawodnik[] PodajZawodnikow(string kraj)
        {
            return WczytajZawodnikow().ToArray();
        }

        public void Usun(int id)
        {
            throw new NotImplementedException();
        }

        public List<Zawodnik> WczytajZawodnikow()
        {
            return new List<Zawodnik>()
            {
                new Zawodnik()
                {
                    Imie = "Adam",
                    Nazwisko = "Nowak",
                    Kraj = "POL",
                },
                 new Zawodnik()
                {
                    Imie = "Jan",
                    Nazwisko = "Kowalski",
                    Kraj = "POL",
                },
            };
        }

        public List<Osoba> WyszukajOsoby(string text)
        {
            throw new NotImplementedException();
        }
    }
}
