using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
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


            //select len(nazwisko) dlugosc, count(*) liczbaOsob
            //from zawodnicy
            //where LEFT(nazwisko, 1) != 'a'
            //group by len(nazwisko)
            //having count(*) > 1
            //order by liczbaOsob, dlugosc desc

            var wyn20 = db.Zawodnik
                .Where(x=> !x.nazwisko.StartsWith("a"))
                .GroupBy(x=>x.nazwisko.Length)
                .Select(x=> new
                {
                    DlugoscNazwiska = x.Key,
                    LiczbaOsob = x.Count(),
                    Srednia = x.Average(y=>y.wzrost),
                    Max = x.Max(y=>y.wzrost),   
                })
                .Where(x=>x.LiczbaOsob> 1)
                .OrderBy(x=>x.LiczbaOsob)
                .ThenByDescending(x=>x.DlugoscNazwiska)
                .ToArray();

            foreach (var g in wyn20)
                Console.WriteLine($"Nazwisko o długosci {g.DlugoscNazwiska} ma {g.LiczbaOsob} osob");


            // a co gdybysmy chcieli uzyskac zbior nazwisk o dlugosci od 1 do 15 
            var dlugosciNazwisk = Enumerable.Range(1, 15);

            Console.WriteLine("----------");
            var wyn20b = dlugosciNazwisk
                .Select(x=>new
                {
                    DlugoscNazwiska = x,
                    LiczbaOsob = wyn20.FirstOrDefault(y=>y.DlugoscNazwiska==x)?.LiczbaOsob ?? 0
                }).OrderBy(x=>x.DlugoscNazwiska).ToArray();

            foreach (var g in wyn20b)
                Console.WriteLine($"Nazwisko o długosci {g.DlugoscNazwiska} ma {g.LiczbaOsob} osob");


            // Dla kazdego kraju, wypisz po przecinku liste nazwisk zawodników z danego kraju 

            var wyn21 = db.Zawodnik
                .GroupBy(x => x.kraj)
                .Select(x => new 
                {
                    Kraj = x.Key,
                    Nazwiska = x.Select(y=>y.nazwisko).OrderBy(y=>y)
                }).ToArray();

            foreach (var g in wyn21)
            {
                Console.WriteLine("Kraj " + g.Kraj);
                Console.WriteLine(string.Join(" ,", g.Nazwiska));
            }


            // do tej pory wybieralismy zbiór elementow 

            // chcemy wybrac jeden rekord 

            Zawodnik wyn22 = db.Zawodnik.Where(x => x.nazwisko == "małysz").ToArray()[0];


            Zawodnik wyn23 = db.Zawodnik.Where(x => x.nazwisko == "małysz").FirstOrDefault();

            Zawodnik wyn24 = db.Zawodnik.FirstOrDefault(x => x.nazwisko == "małysz");

          //  Zawodnik wyn25 = db.Zawodnik.First(x => x.id_zawodnika == 20);


            // znajdz zawodnikow których waga jest o dokładnie 1 kilogram mniejsza od wagi najwyższego zawodnika

            var najwyzszy = db.Zawodnik.OrderByDescending(x=>x.wzrost).FirstOrDefault();
            var wyb26 = db.Zawodnik.Where(x => x.waga == najwyzszy.waga - 1).ToArray();

            // to samo w jednym : 

            var wyb27 = db.Zawodnik.Where(x => x.waga == (db.Zawodnik.OrderByDescending(y => y.wzrost).FirstOrDefault()).waga - 1).ToArray();

            // inne rozwaizanie 
            var najwyzszyWzrost = db.Zawodnik.Select(x => x.wzrost).Max();
            var wyn28 = db.Zawodnik.Where(x => x.waga == db.Zawodnik.FirstOrDefault(y => y.wzrost == najwyzszyWzrost).waga - 1).ToArray();

            // to samo w jednym : 
            var wyn29 = db.Zawodnik.Where(x => x.waga == db.Zawodnik.FirstOrDefault(y => y.wzrost == db.Zawodnik.Select(z => z.wzrost).Max()).waga - 1).ToArray();

            // dla każdego kraju wypisz imie i nazwisko najwyzszego zawodnika z tego kraju 

            var wyn30 = db.Zawodnik
                .GroupBy(x=>x.kraj)
                .Select(x=> new
                {
                    Kraj = x.Key,
                    Najwyzsi = db.Zawodnik.Where(y=>y.wzrost == x.Select(z=>z.wzrost).Max() && y.kraj == x.Key).Select(y=>y.imie + " " + y.nazwisko + " (" + y.wzrost + ")").ToArray()
                }).ToArray();

            // zamiast odwolywać się do wszystkich mozemy odowlac sie do danej grupy (x) 
            // wtedy nie potrzebujemy dodatkowo filtrowac po kraju 
            var wyn30b = db.Zawodnik
            .GroupBy(x => x.kraj)
            .Select(x => new
            {
                Kraj = x.Key,
                Najwyzsi = x.Where(y => y.wzrost == x.Select(z => z.wzrost).Max()).Select(y => y.imie + " " + y.nazwisko + " (" + y.wzrost + ")").ToArray()
            }).ToArray();

            foreach (var g in wyn30b)
                Console.WriteLine($"kraj: {g.Kraj} zawodnicy: {string.Join(" ,", g.Najwyzsi)}");


            //var wyn30c = db.Zawodnik
            //.GroupBy(x => x.kraj)
            //.Select(x => new
            //{
            //    Najwyzsi = x.Where(y => y.wzrost == x.Select(z => z.wzrost).Max()).Select(y => y).ToArray()
            //}).ToArray();

            //foreach (var g in wyn30c)
            //    Console.WriteLine($"kraj: {g.Najwyzsi.FirstOrDefault().kraj} zawodnicy: {string.Join(" ,", g.Najwyzsi.Select(x=>x.nazwisko))}");

            // wypisz grupy nazwisk zawodnikow urodzonych w tym samym miesiacu 
            
            var wyn31 = db.Zawodnik
                .Where(x=>x.data_ur.HasValue)
                .GroupBy(x=>x.data_ur.Value.Month)
                .Select(x=>new
                {
                    NrMiesiaca = x.Key,
                    Nazwiska = string.Join(" ,",x.Select(y=>y.nazwisko).ToArray())
                })
                .OrderBy(x=>x.NrMiesiaca)
                .ToArray();

            foreach (var g in wyn31)
                Console.WriteLine(g.NrMiesiaca + " " + g.Nazwiska);


            //foreach (var g in wyn31)
            //    Console.WriteLine(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.NrMiesiaca) + " " + g.Nazwiska);

            var polskieWyrazy = new CultureInfo("pl-PL");
            foreach (var g in wyn31)
                Console.WriteLine(polskieWyrazy.DateTimeFormat.GetMonthName(g.NrMiesiaca) + " " + g.Nazwiska);


            Console.ReadKey();
        }
    }
}
