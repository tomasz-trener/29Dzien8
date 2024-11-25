using P04Zawodnicy.Shared.Domains;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace P04Zawodnicy.Shared.Services
{
    public class ManagerZawodnikowLocal : IManagerZawodnikow
    {

        //private Zawodnik[] zawodnicyCache;
        private List<Zawodnik> zawodnicyCache;
        string url = @"c:\dane\zawodnicy.txt";
        public List<Zawodnik> WczytajZawodnikow()
        {
            //string url = "http://tomaszles.pl/wp-content/uploads/2019/06/zawodnicy.txt";

            WebClient wc = new WebClient();
            string dane = wc.DownloadString(url);

            string[] wiersze = dane.Split(new string[1] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            // Zawodnik[] zawodnicy = new Zawodnik[wiersze.Length - 1];
            List<Zawodnik> zawodnicy = new List<Zawodnik>();


            for (int i = 1; i < wiersze.Length; i++)
            {
                string[] komorki = wiersze[i].Split(';');
                Zawodnik z = new Zawodnik();
                z.Id_zawodnika = Convert.ToInt32(komorki[0]);

                if (!string.IsNullOrEmpty(komorki[1]))
                    z.Id_trenera = Convert.ToInt32(komorki[1]);

                z.Imie = komorki[2];
                z.Nazwisko = komorki[3];
                z.Kraj = komorki[4];
                z.DataUrodzenia = Convert.ToDateTime(komorki[5]);
                z.Wzrost = Convert.ToInt32(komorki[6]);
                z.Waga = Convert.ToInt32(komorki[7]);

                //zawodnicy[i - 1] = z;
                zawodnicy.Add(z);

            }
            zawodnicyCache = zawodnicy;
            return zawodnicy;
        }

        public string[] PodajKraje()
        {
            // unikam ponownego wczytywania danych dzieki zastosowaniu cachu 
            //   Zawodnik[] zawodnicy = WczytajZawodnikow();
            if (zawodnicyCache == null)
                throw new Exception("Najpierw wczytaj zawodnikow");

            //  Zawodnik[] zawodnicy = zawodnicyCache;
            List<Zawodnik> zawodnicy = zawodnicyCache;


            HashSet<string> kraje = new HashSet<string>();
            foreach (var z in zawodnicy)
                kraje.Add(z.Kraj);

            List<string> posortowaneKraje = kraje.ToList();
            posortowaneKraje.Sort(); // sortowanie alfabetyczne 
                                     //            posortowaneKraje.Reverse(); // ewentualnie mozna odwrocic kolejnosc 

            return posortowaneKraje.ToArray();

        }

        public Zawodnik[] PodajZawodnikow(string kraj)
        {
            List<Zawodnik> zawodnicy = new List<Zawodnik>();
            foreach (var z in zawodnicyCache)
                if (z.Kraj == kraj)
                    zawodnicy.Add(z);

            posrotujZawodnikowPoNazwisku(zawodnicy);
            return zawodnicy.ToArray();
        }

        private void posrotujZawodnikowPoNazwisku(List<Zawodnik> zawodnicy)
        {
            for (int i = 0; i < zawodnicy.Count - 1; i++)
            {
                for (int j = 0; j < zawodnicy.Count - 1 - i; j++)
                {
                    if (string.Compare(zawodnicy[j].Nazwisko, zawodnicy[j + 1].Nazwisko) > 0)
                    {
                        Zawodnik temp = zawodnicy[j];
                        zawodnicy[j] = zawodnicy[j + 1];
                        zawodnicy[j + 1] = temp;
                    }
                }
            }
        }

        public double PodajSredniWzrost(string kraj)
        {
            Zawodnik[] zawodnicy = PodajZawodnikow(kraj);

            double suma = 0;
            foreach (var zawodnik in zawodnicy)
                suma += zawodnik.Wzrost;

            return suma / zawodnicy.Length;
        }

        // Zaczynamy od zrobienia metody zapisz 
        // ta metoda powinna zapisywać do pliku stan aktualny naszych zawodnikow 
        private void Zapisz()
        {
            const string naglowek = "id_zawodnika;id_trenera;imie;nazwisko;kraj;data urodzenia;wzrost;waga";
            const string szablon = "{0};{1};{2};{3};{4};{5};{6};{7}";


            StringBuilder sb = new StringBuilder(naglowek + Environment.NewLine);
            foreach (var z in zawodnicyCache)
            {
                string dataUr = z.DataUrodzenia == null ? "null" : "'" + z.DataUrodzenia.Value.ToString("yyyyMMdd") + "'";


                string wiersz = string.Format(szablon,
                    z.Id_zawodnika, z.Id_trenera, z.Imie, z.Nazwisko,
                    z.Kraj, dataUr,
                    z.Wzrost, z.Waga);
                sb.AppendLine(wiersz);
            }
            File.WriteAllText(url, sb.ToString(), Encoding.UTF8);
        }

        public void Usun(int id)
        {
            Zawodnik zawodnikDoUsuniecia = null;
            foreach (var z in zawodnicyCache)
            {
                if (z.Id_zawodnika == id)
                {
                    zawodnikDoUsuniecia = z;
                    break;
                }
            }
            zawodnicyCache.Remove(zawodnikDoUsuniecia);
            Zapisz();
        }

        public void Dodaj(Zawodnik zawodnik)
        {
            int maksId = 0;
            foreach (var z in zawodnicyCache)
                if (z.Id_zawodnika > maksId)
                    maksId = z.Id_zawodnika;

            zawodnik.Id_zawodnika = maksId + 1;
            zawodnicyCache.Add(zawodnik);

            Zapisz();
        }

        public void Edytuj(Zawodnik edytowany)
        {
            Zapisz();
        }

        public int PodajSredniWiekZawodnikow(string kraj)
        {
            throw new NotImplementedException();
        }

        public Trener[] PodajTrenerow()
        {
            throw new NotImplementedException();
        }

        public List<Osoba> WyszukajOsoby(string text)
        {
            throw new NotImplementedException();
        }

        public GrupaKraju[] PodajSerdniWzrostDlaKazdegoKraju()
        {
            throw new NotImplementedException();
        }
    }
}
