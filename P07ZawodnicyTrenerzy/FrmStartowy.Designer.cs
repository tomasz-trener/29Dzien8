namespace P03AplikacjaBazodanowaZawodnicy
{
    partial class FrmStartowy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lbDane = new System.Windows.Forms.ListBox();
            this.btnTemperatuara = new System.Windows.Forms.Button();
            this.lblRaport = new System.Windows.Forms.Label();
            this.cbKraje = new System.Windows.Forms.ComboBox();
            this.lblRaportWzrost = new System.Windows.Forms.Label();
            this.btnSzczegoly = new System.Windows.Forms.Button();
            this.btnNowy = new System.Windows.Forms.Button();
            this.btnPodglad = new System.Windows.Forms.Button();
            this.btnGenerujPDF = new System.Windows.Forms.Button();
            this.wbPrzegladrka = new System.Windows.Forms.WebBrowser();
            this.cbKolumny = new System.Windows.Forms.CheckedListBox();
            this.btnPokazSredniWeik = new System.Windows.Forms.Button();
            this.pnlFlagi = new System.Windows.Forms.Panel();
            this.btnWyszukiwarka = new System.Windows.Forms.Button();
            this.chartWykres = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartWykres)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDane
            // 
            this.lbDane.FormattingEnabled = true;
            this.lbDane.Location = new System.Drawing.Point(12, 39);
            this.lbDane.Name = "lbDane";
            this.lbDane.Size = new System.Drawing.Size(164, 147);
            this.lbDane.TabIndex = 0;
            // 
            // btnTemperatuara
            // 
            this.btnTemperatuara.Location = new System.Drawing.Point(12, 231);
            this.btnTemperatuara.Name = "btnTemperatuara";
            this.btnTemperatuara.Size = new System.Drawing.Size(164, 23);
            this.btnTemperatuara.TabIndex = 2;
            this.btnTemperatuara.Text = "Podaj temperature";
            this.btnTemperatuara.UseVisualStyleBackColor = true;
            this.btnTemperatuara.Click += new System.EventHandler(this.btnTemperatuara_Click);
            // 
            // lblRaport
            // 
            this.lblRaport.AutoSize = true;
            this.lblRaport.Location = new System.Drawing.Point(13, 271);
            this.lblRaport.Name = "lblRaport";
            this.lblRaport.Size = new System.Drawing.Size(35, 13);
            this.lblRaport.TabIndex = 3;
            this.lblRaport.Text = "label1";
            // 
            // cbKraje
            // 
            this.cbKraje.FormattingEnabled = true;
            this.cbKraje.Location = new System.Drawing.Point(12, 13);
            this.cbKraje.Name = "cbKraje";
            this.cbKraje.Size = new System.Drawing.Size(164, 21);
            this.cbKraje.TabIndex = 4;
            this.cbKraje.SelectedIndexChanged += new System.EventHandler(this.cbKraje_SelectedIndexChanged);
            // 
            // lblRaportWzrost
            // 
            this.lblRaportWzrost.AutoSize = true;
            this.lblRaportWzrost.Location = new System.Drawing.Point(12, 198);
            this.lblRaportWzrost.Name = "lblRaportWzrost";
            this.lblRaportWzrost.Size = new System.Drawing.Size(35, 13);
            this.lblRaportWzrost.TabIndex = 5;
            this.lblRaportWzrost.Text = "label1";
            // 
            // btnSzczegoly
            // 
            this.btnSzczegoly.Location = new System.Drawing.Point(183, 39);
            this.btnSzczegoly.Name = "btnSzczegoly";
            this.btnSzczegoly.Size = new System.Drawing.Size(102, 23);
            this.btnSzczegoly.TabIndex = 6;
            this.btnSzczegoly.Text = "Szczegóły";
            this.btnSzczegoly.UseVisualStyleBackColor = true;
            this.btnSzczegoly.Click += new System.EventHandler(this.btnSzczegoly_Click);
            // 
            // btnNowy
            // 
            this.btnNowy.Location = new System.Drawing.Point(182, 68);
            this.btnNowy.Name = "btnNowy";
            this.btnNowy.Size = new System.Drawing.Size(102, 23);
            this.btnNowy.TabIndex = 7;
            this.btnNowy.Text = "Nowy";
            this.btnNowy.UseVisualStyleBackColor = true;
            this.btnNowy.Click += new System.EventHandler(this.btnNowy_Click);
            // 
            // btnPodglad
            // 
            this.btnPodglad.Location = new System.Drawing.Point(183, 98);
            this.btnPodglad.Name = "btnPodglad";
            this.btnPodglad.Size = new System.Drawing.Size(101, 23);
            this.btnPodglad.TabIndex = 8;
            this.btnPodglad.Text = "Podgląd";
            this.btnPodglad.UseVisualStyleBackColor = true;
            this.btnPodglad.Click += new System.EventHandler(this.btnPodglad_Click);
            // 
            // btnGenerujPDF
            // 
            this.btnGenerujPDF.Location = new System.Drawing.Point(182, 127);
            this.btnGenerujPDF.Name = "btnGenerujPDF";
            this.btnGenerujPDF.Size = new System.Drawing.Size(101, 23);
            this.btnGenerujPDF.TabIndex = 9;
            this.btnGenerujPDF.Text = "Raport PDF";
            this.btnGenerujPDF.UseVisualStyleBackColor = true;
            this.btnGenerujPDF.Click += new System.EventHandler(this.btnGenerujPDF_Click);
            // 
            // wbPrzegladrka
            // 
            this.wbPrzegladrka.Location = new System.Drawing.Point(289, 12);
            this.wbPrzegladrka.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPrzegladrka.Name = "wbPrzegladrka";
            this.wbPrzegladrka.Size = new System.Drawing.Size(214, 302);
            this.wbPrzegladrka.TabIndex = 10;
            // 
            // cbKolumny
            // 
            this.cbKolumny.CheckOnClick = true;
            this.cbKolumny.FormattingEnabled = true;
            this.cbKolumny.Location = new System.Drawing.Point(183, 217);
            this.cbKolumny.Name = "cbKolumny";
            this.cbKolumny.Size = new System.Drawing.Size(100, 94);
            this.cbKolumny.TabIndex = 11;
            this.cbKolumny.SelectedIndexChanged += new System.EventHandler(this.cbKolumny_SelectedIndexChanged);
            // 
            // btnPokazSredniWeik
            // 
            this.btnPokazSredniWeik.Location = new System.Drawing.Point(182, 158);
            this.btnPokazSredniWeik.Name = "btnPokazSredniWeik";
            this.btnPokazSredniWeik.Size = new System.Drawing.Size(101, 23);
            this.btnPokazSredniWeik.TabIndex = 12;
            this.btnPokazSredniWeik.Text = "ŚredniWiek";
            this.btnPokazSredniWeik.UseVisualStyleBackColor = true;
            this.btnPokazSredniWeik.Click += new System.EventHandler(this.btnPokazSredniWeik_Click);
            // 
            // pnlFlagi
            // 
            this.pnlFlagi.Location = new System.Drawing.Point(12, 317);
            this.pnlFlagi.Name = "pnlFlagi";
            this.pnlFlagi.Size = new System.Drawing.Size(491, 113);
            this.pnlFlagi.TabIndex = 13;
            // 
            // btnWyszukiwarka
            // 
            this.btnWyszukiwarka.Location = new System.Drawing.Point(184, 188);
            this.btnWyszukiwarka.Name = "btnWyszukiwarka";
            this.btnWyszukiwarka.Size = new System.Drawing.Size(101, 23);
            this.btnWyszukiwarka.TabIndex = 14;
            this.btnWyszukiwarka.Text = "Wyszukiwarka";
            this.btnWyszukiwarka.UseVisualStyleBackColor = true;
            this.btnWyszukiwarka.Click += new System.EventHandler(this.btnWyszukiwarka_Click);
            // 
            // chartWykres
            // 
            chartArea1.Name = "ChartArea1";
            this.chartWykres.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartWykres.Legends.Add(legend1);
            this.chartWykres.Location = new System.Drawing.Point(509, 14);
            this.chartWykres.Name = "chartWykres";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartWykres.Series.Add(series1);
            this.chartWykres.Size = new System.Drawing.Size(300, 300);
            this.chartWykres.TabIndex = 15;
            this.chartWykres.Text = "chart1";
            // 
            // FrmStartowy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 452);
            this.Controls.Add(this.chartWykres);
            this.Controls.Add(this.btnWyszukiwarka);
            this.Controls.Add(this.pnlFlagi);
            this.Controls.Add(this.btnPokazSredniWeik);
            this.Controls.Add(this.cbKolumny);
            this.Controls.Add(this.wbPrzegladrka);
            this.Controls.Add(this.btnGenerujPDF);
            this.Controls.Add(this.btnPodglad);
            this.Controls.Add(this.btnNowy);
            this.Controls.Add(this.btnSzczegoly);
            this.Controls.Add(this.lblRaportWzrost);
            this.Controls.Add(this.cbKraje);
            this.Controls.Add(this.lblRaport);
            this.Controls.Add(this.btnTemperatuara);
            this.Controls.Add(this.lbDane);
            this.Name = "FrmStartowy";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chartWykres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbDane;
        private System.Windows.Forms.Button btnTemperatuara;
        private System.Windows.Forms.Label lblRaport;
        private System.Windows.Forms.ComboBox cbKraje;
        private System.Windows.Forms.Label lblRaportWzrost;
        private System.Windows.Forms.Button btnSzczegoly;
        private System.Windows.Forms.Button btnNowy;
        private System.Windows.Forms.Button btnPodglad;
        private System.Windows.Forms.Button btnGenerujPDF;
        private System.Windows.Forms.WebBrowser wbPrzegladrka;
        private System.Windows.Forms.CheckedListBox cbKolumny;
        private System.Windows.Forms.Button btnPokazSredniWeik;
        private System.Windows.Forms.Panel pnlFlagi;
        private System.Windows.Forms.Button btnWyszukiwarka;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWykres;
    }
}

