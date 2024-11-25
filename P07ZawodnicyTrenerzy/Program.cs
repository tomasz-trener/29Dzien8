using P04Zawodnicy.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P03AplikacjaBazodanowaZawodnicy
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var formularz = UstawSerwisy();
            Application.Run(formularz);
        }

        static FrmStartowy UstawSerwisy()
        {
            return new FrmStartowy(new ManagerZawodnikowLINQ());
        }
    }
}
