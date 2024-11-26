using P04Zawodnicy.Shared.Domains;
using P04Zawodnicy.Shared.Services;
using P08ZadanieFiltorwanieDanych;
using P08ZadanieFiltorwanieDanych.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace P03AplikacjaBazodanowaZawodnicy
{
    public partial class FrmStartowy : Form
    {
        IManagerZawodnikow mz;
        
        public FrmStartowy(IManagerZawodnikow mz)
        {
            InitializeComponent();
            this.mz = mz;
            mz.WczytajZawodnikow();
            var kraje = mz.PodajKraje();
            cbKraje.DataSource = kraje;

            generujObrazkiKrajow(kraje);

            foreach (var k in Zawodnik.DostepneKolumny)
                cbKolumny.Items.Add(k);

            Odswiez();
        }

        public void Odswiez()
        {
            mz.WczytajZawodnikow();
            var kraje = mz.PodajKraje();
            cbKraje.DataSource = kraje;

            generujObrazkiKrajow(kraje);
            przygotujWykres();
        }

        private void przygotujWykres(double? sredniWzrost = null)
        {
            chartWykres.BorderlineColor = Color.Green;
            chartWykres.BorderlineWidth = 7;
            chartWykres.BorderlineDashStyle = ChartDashStyle.Solid;
            chartWykres.Series.Clear();
            Series seriaDanych = new Series("Wzrosty");
            seriaDanych.ChartType= SeriesChartType.Column;

            //string[] osX = new string[] { "POL", "GER" };
            //double[] osY = new double[] { 185, 184 };

            GrupaKraju[] gk = mz.PodajSerdniWzrostDlaKazdegoKraju();
            string[] osX = gk.Select(x=>x.Kraj).ToArray();
            double[] osY = gk.Select(y => y.SredniWzrost).ToArray();

            seriaDanych.Points.DataBindXY(osX, osY);
            chartWykres.Series.Add(seriaDanych);

            chartWykres.ChartAreas[0].AxisY.Minimum = 150;
            chartWykres.ChartAreas[0].AxisY.Maximum= 200;

            //dodanie linii srednigo wzrostu 
            if(sredniWzrost != null)
            {
                Series seriaSredniegoWzrostu = new Series("Sredni wzrost");
                seriaSredniegoWzrostu.ChartType= SeriesChartType.Line;
                seriaSredniegoWzrostu.BorderWidth= 3;
                seriaSredniegoWzrostu.Color = Color.Red;

                foreach (var punkt in chartWykres.Series["Wzrosty"].Points)
                    seriaSredniegoWzrostu.Points.AddXY(punkt.AxisLabel, sredniWzrost);

                chartWykres.Series.Add(seriaSredniegoWzrostu);
            }
        }

        private void generujObrazkiKrajow(string[] kraje)
        {
            Dictionary<string, string> skroty = new Dictionary<string, string>()
            {
                {"POL","pl" },
                {"GER","de" },
                {"AUT","at" },
                {"FIN","fi" },
                {"USA","us" },
                {"NOR","no" }
            };

            string folderFlagi = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "flagi");
            for (int i = 0; i < kraje.Length; i++)
            {
                string sciezka = Path.Combine(folderFlagi, skroty[kraje[i]]+ ".png");
                if (File.Exists(sciezka))
                {
                    PictureBox pc = new PictureBox()
                    {
                        Name= "pb"+ kraje[i],
                        Size = new Size(50,30),
                        Location = new Point(10 + i*60,10),
                        ImageLocation = sciezka,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Cursor = Cursors.Hand,
                        Tag = kraje[i]
                    };
                    pc.Click += flaga_Click;
                    pnlFlagi.Controls.Add(pc);
                }
            }

        }

        private void flaga_Click(object sender, EventArgs e)
        {
            // musimy odczytac ktora dlaga zostala kliknieta 
            Control kliknietyObarzek = (Control)sender;
            string kodKraju = (string)kliknietyObarzek.Tag;
            cbKraje.SelectedItem = kodKraju;
        }

        private void btnTemperatuara_Click(object sender, EventArgs e)
        {
            // chcemy odczytac, który zawodnik jest akutalnie zaznaczony 
            Zawodnik zaznaczony = (Zawodnik)lbDane.SelectedItem;

            ManagerPogody mp = new ManagerPogody(Jednostka.Celsjusz);
            double temp = mp.PodajTemperature(zaznaczony.Kraj);

            lblRaport.Text = string.Format("W kraju {0}, skąd pochodzi zawodnik {1} temepratura wynosi {2}",
                zaznaczony.Kraj, zaznaczony.ImieNazwisko, temp);

            int rozmiar = this.Width;
            lblRaport.MaximumSize = new Size(rozmiar - 45, 0);
            lblRaport.AutoSize = true;
        
        }

        private void cbKraje_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zaznaczonyKraj = (string)cbKraje.SelectedItem;

            if(zaznaczonyKraj != null)
            {
                var dane = mz.PodajZawodnikow(zaznaczonyKraj);
                Array.Sort(dane);
                lbDane.DataSource = dane;
                lbDane.DisplayMember = "ImieNazwisko";

                double wzrost = mz.PodajSredniWzrost(zaznaczonyKraj);
                lblRaportWzrost.Text = string.Format("Sredni wzrost : {0:0.00} cm", wzrost);
                przygotujWykres(wzrost);
            }

           
        }

        private void btnSzczegoly_Click(object sender, EventArgs e)
        {
            Zawodnik zawodnik = (Zawodnik)lbDane.SelectedItem;
            FrmSzczegoly frmSzczegoly = new FrmSzczegoly(zawodnik, mz, this, TrybOkienka.Edycja);
            frmSzczegoly.Show();
        }

        private void btnNowy_Click(object sender, EventArgs e)
        {      
            FrmSzczegoly frmSzczegoly = new FrmSzczegoly(mz, this);
            frmSzczegoly.Show();
        }

        private void btnPodglad_Click(object sender, EventArgs e)
        {
            Zawodnik zawodnik = (Zawodnik)lbDane.SelectedItem;
            FrmSzczegoly frmSzczegoly = new FrmSzczegoly(zawodnik, mz, this, TrybOkienka.Podglad);
            frmSzczegoly.Show();

        }

        private void btnGenerujPDF_Click(object sender, EventArgs e)
        {
            Zawodnik[] zawodnicy = (Zawodnik[])lbDane.DataSource;

            if(zawodnicy == null || zawodnicy.Length == 0)
            {
                MessageBox.Show("Pusty zbiór danych","Ostrzeżenie",MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }

           // string sciezka = "c:\\dane\\raport.pdf";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Pliki pdf (*.pdf)|*.pdf";
            sfd.Title = "Wskaz niejsce zapisu raportu pdf";
            sfd.InitialDirectory = "c:\\dane";
            sfd.FileName = cbKraje.Text + "_" + DateTime.Now.ToString("ssmmhhddMMyy");
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                PdfManager pm = new PdfManager(sfd.FileName);
                pm.WygenerujPDF(zawodnicy);
                wbPrzegladrka.Navigate(sfd.FileName);   
            }


          
        }

        private void cbKolumny_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> zaznaczoneKolumny = new List<string>();
            foreach (string item in cbKolumny.CheckedItems)
                zaznaczoneKolumny.Add(item);

            Zawodnik.WybraneKolumny = zaznaczoneKolumny.ToArray();

            lbDane.DisplayMember = null;
            lbDane.DisplayMember = "DynamicznaWlasciwosc";
        }

        private void btnPokazSredniWeik_Click(object sender, EventArgs e)
        {
            string wybranyKraj = cbKraje.SelectedItem.ToString();
            int sredniWiek = mz.PodajSredniWiekZawodnikow(wybranyKraj);
            MessageBox.Show($"Sredni wiek zawodnikow z kraju {wybranyKraj} wynosi {sredniWiek}");
        }

        private void btnWyszukiwarka_Click(object sender, EventArgs e)
        {
            FrmWyszuiwarka frmWyszuiwarka = new FrmWyszuiwarka(mz);
            frmWyszuiwarka.ShowDialog();
        }
    }
}
