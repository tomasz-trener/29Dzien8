using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02OperacjeCRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ModelBazyDataContext db = new ModelBazyDataContext();

            //// Dodawanie do bazy 

            //Zawodnik nowy = new Zawodnik()
            //{
            //    imie = "adam",
            //    nazwisko = "nowak",
            //    waga = 70,
            //    wzrost = 180,
            //    kraj = "pol",
            //    data_ur = new DateTime(2000, 2, 4)
            //};

            //db.Zawodnik.InsertOnSubmit(nowy); // przygotowanie do wyslania do bazy 

            //Zawodnik nowy2 = new Zawodnik()
            //{
            //    imie = "Jakub",
            //    nazwisko = "Kowalski",
            //    waga = 70,
            //    wzrost = 180,
            //    kraj = "pol",
            //    data_ur = new DateTime(2000, 2, 4)
            //};
            //db.Zawodnik.InsertOnSubmit(nowy2);

            ////db.Zawodnik.InsertAllOnSubmit();// moge wielu przekazac 

            //db.SubmitChanges(); // w tym momencie zawodnicy sa wysylani do bazy 

            //// uwaga! trzeba zdefiniować klucz główny w tabelce żeby działało dodawanie 

            //EDYCJA 

            // krok 1: najpierw pobieramy zawodnika z bazy, którego chcemy edytować 
            // krok 2: potem lokalnie zmieniamy właściwosci 
            // krok 3: wywołujemy submitchanges 
        
            var doEdycji = db.Zawodnik.FirstOrDefault(x=>x.id_zawodnika == 2);
            doEdycji.wzrost = doEdycji.wzrost + 5;
            doEdycji.nazwisko = "Nowak";
            db.SubmitChanges();

            // usuwanie 

            var doUsuniecia = db.Zawodnik.FirstOrDefault(x=>x.id_zawodnika==18);
            db.Zawodnik.DeleteOnSubmit(doUsuniecia);
            db.SubmitChanges();


        }
    }
}
