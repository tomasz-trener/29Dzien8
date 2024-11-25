using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace P04Zawodnicy.Shared.Domains
{
    public class Zawodnik : Osoba, IComparable<Zawodnik>
    {
        public static string[] DostepneKolumny = { "Imie", "Nazwisko", "Kraj", "Waga", "Wzrost" };

        public static string[] WybraneKolumny { get; set; }
        public int Id_zawodnika { get; set; }
        public int? Id_trenera { get; set; }
     
        public string Kraj { get; set; }
       
        public int Wzrost { get; set; }
        public int Waga { get; set; }

        //public string ImieNazwisko
        //{
        //    get
        //    {
        //        return Imie + " " + Nazwisko;
        //    }
        //}
        //public string ImieNazwisko
        //{
        //    get
        //    {
        //        string imieNazwisko = Imie;
        //        if (Nazwisko.Length == 1)
        //        {
        //            imieNazwisko += " " + Nazwisko[0];
        //        }
        //        else if (Nazwisko.Length > 1)
        //        {
        //            imieNazwisko += " " + Nazwisko[0] + Nazwisko.Substring(1).ToLower();
        //        }
        //        return imieNazwisko;

        //    }
        //}

        public string ImieNazwisko => PelnaNazwa;

        public string this[string nazwaWlasciwosci]
        {
            get
            {
                return this.GetType().GetProperty(nazwaWlasciwosci).GetValue(this, null).ToString();
            }
            set
            {
                this.GetType().GetProperty(nazwaWlasciwosci).SetValue(this, value, null);
            }
        }
        public string DynamicznaWlasciwosc
        {
            get
            {
                string s = "";
                foreach (var k in WybraneKolumny)
                    s += this[k] + " "; 
                return s;
            }
        }

        public DateTime? DataUrodzenia { get; set; }
        public int CompareTo(Zawodnik inna)
        {
            int pora1 = PoraRoku(this.DataUrodzenia);
            int pora2 = PoraRoku(inna.DataUrodzenia);
            return pora1.CompareTo(pora2);
        }


        private int PoraRoku(DateTime? data)
        {
            if (data == null)
                return 5;

            if (data.Value.Month >= 3 && data.Value.Month <= 5) return 1; // wiosna
            if (data.Value.Month >= 6 && data.Value.Month <= 8) return 2; // Lato
            if (data.Value.Month >= 9 && data.Value.Month <= 11) return 3; // jesien
            return 4;// zima
        }


    }
}
