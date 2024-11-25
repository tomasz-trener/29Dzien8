using P04Zawodnicy.Shared.Domains;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace P08ZadanieFiltorwanieDanych.Services
{
    internal class PdfManager
    {
        private readonly string sciezka;

        public PdfManager(string sciezka)
        {
            this.sciezka = sciezka;
        }


        public void WygenerujPDF(Zawodnik[] zawodnicy)
        {
            // Create a new PDF document.
            var document = new PdfDocument();
            document.Info.Title = "Raport zawodnicy";
           // document.Info.Subject = "Just a simple Hello-World program.";

            // Create an empty page in this document.
            var page = document.AddPage();

            // Get an XGraphics object for drawing on this page.
            var gfx = XGraphics.FromPdfPage(page);

            // Create a font.
            var font = new XFont("Times New Roman", 20, XFontStyleEx.BoldItalic);

            for (int i = 0; i < zawodnicy.Length; i++)
            {
                gfx.DrawString(zawodnicy[i].ImieNazwisko, font, XBrushes.Black,20, 50+25*i);                   
            }
      

            // Save the document...
        
            document.Save(sciezka);
        }
    }
}
