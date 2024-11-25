using System;
using System.Collections.Generic;
using System.Linq;
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

        }
    }
}
