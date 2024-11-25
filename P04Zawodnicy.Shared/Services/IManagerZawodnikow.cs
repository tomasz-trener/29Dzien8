using P04Zawodnicy.Shared.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04Zawodnicy.Shared.Services
{
    public interface IManagerZawodnikow
    {
        List<Zawodnik> WczytajZawodnikow();
        string[] PodajKraje();
        Zawodnik[] PodajZawodnikow(string kraj);

        double PodajSredniWzrost(string kraj);

        void Usun(int id);

        void Dodaj(Zawodnik z);

        void Edytuj(Zawodnik edytowany);

        int PodajSredniWiekZawodnikow(string kraj);

        Trener[] PodajTrenerow();
        List<Osoba> WyszukajOsoby(string text);

        GrupaKraju[] PodajSerdniWzrostDlaKazdegoKraju();
    }
}
