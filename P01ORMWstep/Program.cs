using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace P01ORMWstep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ORM - Object - Relation - Mapping
            ModelBazyDataContext db = new ModelBazyDataContext();

            // select * from zawodnicy 
            Zawodnik[] zawodnicy = db.Zawodnik.ToArray();

            //foreach (var z in zawodnicy)
            //{
            //    Console.WriteLine(z.imie + " " + z.nazwisko);
            //}
           // Console.ReadKey();

            // to polecenie wykonalo sie na bazy danych  (select * from zawodnicy where kraj = 'pol'
            Zawodnik[] wyn1 = db.Zawodnik.Where(x => x.kraj == "pol").ToArray();

            // to wykonało się lokalnie (wielkość liter ma znaczenie)  w C# pol != POL
            Zawodnik[] wyn2 = zawodnicy.Where(x => x.kraj == "POL").ToArray();

            // LINQ lokalnie

            string[] napisy = { "BACHLEDA", "MATEJA", "HERR" };
            string[] wynik = napisy.Where(x => x.Length > 4).ToArray();

            // Console.WriteLine(string.Join(" ",wynik));

            int[] liczby = { 4, 6, 33, 2, 30, 20, 22 };
            int[] wynik2 = liczby.Where(x=>x > 20).OrderByDescending(x => x).ToArray();

            var wyn3 = db.Zawodnik
                    .Where(x=>x.kraj == "pol" || x.kraj.Equals("ger"))
                    .OrderByDescending(x => x.kraj)
                    .ThenBy(x => x.wzrost)
                    .ToArray();


            Console.ReadKey();

            // znajdz zawodników, których nazwisko konczy się na litere a 
            // oraz wzrost jest ponad 2 razy wiekszy niz waga
            // urodzonych w II polowie roku i posortouj po dlugosci imienia 


            //Lambda expression syntax
            var wyn7 = db.Zawodnik
                    .Where(x=>x.nazwisko.EndsWith("a") && x.wzrost > x.waga*2 && x.data_ur.Value.Month > 6)
                    .OrderBy(x=>x.imie.Length)
                    .ToArray();
            
            //sql
            //select * from zawodnicy 
            //where right(nazwisko,1) = 'a'
            //and wzrost > waga * 2 and month(data_ur) > 6
            //order by len(imie)

            //Query expression syntax
            var wyn8 = (from x in db.Zawodnik
                       where x.nazwisko.EndsWith("a")
                       && x.wzrost > 2 * x.waga
                       && x.data_ur.Value.Month > 6
                       orderby x.imie.Length
                       select x).ToArray();


            //select * from zawodnicy 
            Zawodnik[] wyn9 = db.Zawodnik.ToArray();

            string[] wyn10 = db.Zawodnik.Select(x=>x.imie).ToArray();

            //select imie + ' ' + nazwisko from zawodnicy 
            string[] wyn11 = db.Zawodnik.Select(x => x.imie + " " + x.nazwisko).ToArray();

            ZawodnikMini[] wyn12 = db.Zawodnik.Select(x => new ZawodnikMini()
            {
                MojeImie = x.imie,
                MojeNazwisko = x.nazwisko,
            }).ToArray();

            // jezeli nie chce nam sie tworzyc nowych obietkow 
            var wyn13 = db.Zawodnik.Select(x => new
            {
                MojeImie = x.imie,
                MojaWaga = x.waga,
                x.kraj
            }).ToArray();

            var wyn14 = db.Zawodnik.Select(x=>new {x.imie, x.waga,x.kraj}).ToArray();

            // wypisanei danych 
            foreach (var z in wyn14)
                Console.WriteLine(z.imie + " " + z.waga + " " + z.kraj);

            // wypisz listę zawodnikow (imie nazwisko i BMI) 
            // i posortuj wyniki po BMI malejąco 
            //bmi = waga[kg]/wzrost[m]^2
            // wynik bmi podaj do dwóch miejsc po przecinku 

            //select imie, nazwisko, FORMAT(waga / power((wzrost / 100.0), 2), '0.00') bmi
            //from zawodnicy
            //order by bmi desc

            var wyn15 = db.Zawodnik
                .Where(x => x.waga.HasValue && x.wzrost.HasValue) // upewnienie sie ze waga i wzrost maja uzup. wartosci 
                .Select(x => new
                {
                    Imie = x.imie,
                    Nazwisko = x.nazwisko,
                    BMI = Math.Round((double)x.waga / Math.Pow((double)x.wzrost / 100, 2), 2, MidpointRounding.AwayFromZero)
                })
                .OrderByDescending(x=>x.BMI).ToList();

                //2.5  do 3 
                // 3.5 do 4
                // -2.5 do -3
                // -3.5 do  -4 

                var wyn15b = 
                    (from x in db.Zawodnik
                     where x.waga.HasValue && x.wzrost.HasValue
                     select new
                     {
                         Imie = x.imie,
                         Nazwisko = x.nazwisko,
                         BMI = Math.Round((double)x.waga / Math.Pow((double)x.wzrost / 100, 2), 2, MidpointRounding.AwayFromZero)
                     })
                     .OrderByDescending (x=>x.BMI).ToList();


                IQueryable<Zawodnik> wyn16 = db.Zawodnik.Where(x => x.kraj == "pol"); // to jescze nie zostalo wyslane do bazy

                var wyn17 = wyn16.Where(x => x.wzrost > 170).ToArray(); // dopiero teraz zapytanie poszlo do bazy danych 

            // poznalismy: select , from , where, order by 

            // group by 


            //select kraj, avg(convert(decimal, wzrost))
            //from zawodnicy
            //group by kraj

            var var18 = db.Zawodnik
                .GroupBy(x => x.kraj)
                .Select(x => new
                {
                    Kraj = x.Key,
                    SredniWzrost = x.Average(y => y.wzrost)
                }).ToArray();


            var wyn19 = db.Zawodnik.GroupBy(x => x.kraj).ToArray();// to nam zwraca grupy 

            string kraj1 = wyn19[0].Key;// kraj z pierwzsej grupy 
            double? sredniWzrostZGrupy1 = wyn19.Select(x=>x.Average(y=>y.wzrost)).First();

            Zawodnik najnizszy = db.Zawodnik.OrderBy(x => x.wzrost).FirstOrDefault();

            // wypisz wszystkie wartości długości nazwisk, wraz z informacją ile osób posiada
            // nazwisko o podanej długości 
            //np:
            // nazwisko o długości 5 ma 4 osoby
            // nazwisko o długości 7 ma 6 osoby
            // nazwisko o długości 6 ma 6 osoby
            //.... itd..
            // wyniki posortuj po liczbie osób w grupie rosnąco
            // , a jeżeli liczba osób jest taka sama to po długości nazwiska malejąco

            // * uwzgędnij tylko zawodników, których nazwisko nie zaczyna się na "a"
            // i wypisz tylko te grupy, które zawierają co najmniej 2 osoby 
        }
    }
}
