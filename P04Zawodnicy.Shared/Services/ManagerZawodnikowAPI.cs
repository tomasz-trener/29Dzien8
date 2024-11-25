using P04Zawodnicy.Shared.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04Zawodnicy.Shared.Services
{
    public class ManagerZawodnikowAPI : IManagerZawodnikow
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
            throw new NotImplementedException();
        }

        public int PodajSredniWiekZawodnikow(string kraj)
        {
            throw new NotImplementedException();
        }

        public double PodajSredniWzrost(string kraj)
        {
            throw new NotImplementedException();
        }

        public Trener[] PodajTrenerow()
        {
            throw new NotImplementedException();
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
