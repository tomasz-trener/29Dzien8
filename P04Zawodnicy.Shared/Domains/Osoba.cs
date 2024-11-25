using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04Zawodnicy.Shared.Domains
{
    public class Osoba 
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string PelnaNazwa => $"{Imie} {Nazwisko}";
    }
}
