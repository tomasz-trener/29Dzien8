using P07ZawodnicyDynamiczneKolumny;
using P04Zawodnicy.Shared.Domains;
using P04Zawodnicy.Shared.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P03AplikacjaBazodanowaZawodnicy
{
    public enum TrybOkienka
    {
        Dodawanie,
        Edycja,
        Podglad
    }
    public partial class FrmSzczegoly : Form
    {
        Zawodnik wyswietlanyZawodnik;
        IManagerZawodnikow mz;
        FrmStartowy frmStartowy;
        TrybOkienka trybOkienka;

        // tworzymy nowego zawodnika
        public FrmSzczegoly(IManagerZawodnikow mz,FrmStartowy frmStartowy)
        {
            InitializeComponent();

            this.mz = mz;
            this.frmStartowy = frmStartowy;

            wyswietlanyZawodnik = new Zawodnik()
            {
                DataUrodzenia = DateTime.Now
            };

            var trenerzy = mz.PodajTrenerow();
            cbTrenerzy.DataSource = trenerzy;
            cbTrenerzy.DisplayMember = "PelnaNazwa";
            cbTrenerzy.ValueMember = "Id";
          

        }
        public FrmSzczegoly(Zawodnik zawodnik, IManagerZawodnikow mz, FrmStartowy frmStartowy, TrybOkienka trybOkienka ) : this(mz, frmStartowy)
        {
          //  InitializeComponent();

            this.wyswietlanyZawodnik = zawodnik;
            //this.mz = mz;
            //this.frmStartowy = frmStartowy;
            this.trybOkienka = trybOkienka;

            txtImie.Text = zawodnik.Imie;
            txtNazwisko.Text = zawodnik.Nazwisko;
            txtKraj.Text = zawodnik.Kraj;
            dtpDataUr.Value = zawodnik.DataUrodzenia;
            numWzrost.Value = zawodnik.Wzrost;
            numWaga.Value = zawodnik.Waga;

            if (trybOkienka == TrybOkienka.Podglad)
            {
                // txtImie.ReadOnly = true;
                foreach (Control c in pnlKontrolkiDoEdycji.Controls)
                {
                    if(c is TextBox)
                        ((TextBox)c).ReadOnly = true;
                    if (c is NumericUpDown)
                        ((NumericUpDown)c).ReadOnly = true;
                    if (c is DateTimePicker)
                        ((DateTimePicker)c).Enabled = false;
                }
                btnZapisz.Visible = false;
                btnUsun.Visible = false;
            }

            if (wyswietlanyZawodnik != null)
                cbTrenerzy.SelectedValue = wyswietlanyZawodnik.Id_trenera;
        }


        private void btnZapisz_Click(object sender, EventArgs e)
        {
            if(trybOkienka == TrybOkienka.Edycja)
            {
                zczytajDaneZkontrolek();
                mz.Edytuj(wyswietlanyZawodnik);
                this.Close();
                frmStartowy.Odswiez();
            }
            else if(trybOkienka== TrybOkienka.Dodawanie)
            {
                zczytajDaneZkontrolek();
                mz.Dodaj(wyswietlanyZawodnik);
              //  mz.Zapisz();
                this.Close();
                frmStartowy.Odswiez();
            }
           
        }

        private void zczytajDaneZkontrolek()
        {
            wyswietlanyZawodnik.Imie = txtImie.Text;
            wyswietlanyZawodnik.Nazwisko = txtNazwisko.Text;
            wyswietlanyZawodnik.Kraj = txtKraj.Text;
            wyswietlanyZawodnik.DataUrodzenia = dtpDataUr.Value;
            wyswietlanyZawodnik.Waga = Convert.ToInt32(numWaga.Value);
            wyswietlanyZawodnik.Wzrost = Convert.ToInt32(numWzrost.Value);
            wyswietlanyZawodnik.Id_trenera = (int)cbTrenerzy.SelectedValue;
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
           DialogResult dr= MessageBox.Show($"Czy napewno chcesz usunać zawodika {wyswietlanyZawodnik.ImieNazwisko} ?", "Usuwanie",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes) 
            {
                mz.Usun(wyswietlanyZawodnik.Id_zawodnika);
                this.Close();
              //  mz.Zapisz();
                frmStartowy.Odswiez();

            }

        }
    }
}
