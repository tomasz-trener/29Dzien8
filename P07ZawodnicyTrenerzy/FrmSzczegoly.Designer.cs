namespace P03AplikacjaBazodanowaZawodnicy
{
    partial class FrmSzczegoly
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
            this.lblImie = new System.Windows.Forms.Label();
            this.txtImie = new System.Windows.Forms.TextBox();
            this.txtNazwisko = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKraj = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numWzrost = new System.Windows.Forms.NumericUpDown();
            this.numWaga = new System.Windows.Forms.NumericUpDown();
            this.btnZapisz = new System.Windows.Forms.Button();
            this.btnUsun = new System.Windows.Forms.Button();
            this.pnlKontrolkiDoEdycji = new System.Windows.Forms.Panel();
            this.cbTrenerzy = new System.Windows.Forms.ComboBox();
            this.dtpDataUr = new P08ZadanieFiltorwanieDanych.CustomDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.numWzrost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaga)).BeginInit();
            this.pnlKontrolkiDoEdycji.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblImie
            // 
            this.lblImie.AutoSize = true;
            this.lblImie.Location = new System.Drawing.Point(11, 14);
            this.lblImie.Name = "lblImie";
            this.lblImie.Size = new System.Drawing.Size(26, 13);
            this.lblImie.TabIndex = 0;
            this.lblImie.Text = "Imie";
            // 
            // txtImie
            // 
            this.txtImie.Location = new System.Drawing.Point(14, 31);
            this.txtImie.Name = "txtImie";
            this.txtImie.Size = new System.Drawing.Size(184, 20);
            this.txtImie.TabIndex = 1;
            // 
            // txtNazwisko
            // 
            this.txtNazwisko.Location = new System.Drawing.Point(14, 74);
            this.txtNazwisko.Name = "txtNazwisko";
            this.txtNazwisko.Size = new System.Drawing.Size(184, 20);
            this.txtNazwisko.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nazwisko";
            // 
            // txtKraj
            // 
            this.txtKraj.Location = new System.Drawing.Point(14, 119);
            this.txtKraj.Name = "txtKraj";
            this.txtKraj.Size = new System.Drawing.Size(184, 20);
            this.txtKraj.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kraj";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data Urodzenia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Wzrost";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Waga";
            // 
            // numWzrost
            // 
            this.numWzrost.Location = new System.Drawing.Point(14, 202);
            this.numWzrost.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numWzrost.Name = "numWzrost";
            this.numWzrost.Size = new System.Drawing.Size(184, 20);
            this.numWzrost.TabIndex = 13;
            // 
            // numWaga
            // 
            this.numWaga.Location = new System.Drawing.Point(14, 243);
            this.numWaga.Name = "numWaga";
            this.numWaga.Size = new System.Drawing.Size(184, 20);
            this.numWaga.TabIndex = 14;
            // 
            // btnZapisz
            // 
            this.btnZapisz.Location = new System.Drawing.Point(123, 300);
            this.btnZapisz.Name = "btnZapisz";
            this.btnZapisz.Size = new System.Drawing.Size(75, 23);
            this.btnZapisz.TabIndex = 16;
            this.btnZapisz.Text = "Zapisz";
            this.btnZapisz.UseVisualStyleBackColor = true;
            this.btnZapisz.Click += new System.EventHandler(this.btnZapisz_Click);
            // 
            // btnUsun
            // 
            this.btnUsun.Location = new System.Drawing.Point(14, 300);
            this.btnUsun.Name = "btnUsun";
            this.btnUsun.Size = new System.Drawing.Size(75, 23);
            this.btnUsun.TabIndex = 17;
            this.btnUsun.Text = "Usuń";
            this.btnUsun.UseVisualStyleBackColor = true;
            this.btnUsun.Click += new System.EventHandler(this.btnUsun_Click);
            // 
            // pnlKontrolkiDoEdycji
            // 
            this.pnlKontrolkiDoEdycji.Controls.Add(this.dtpDataUr);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.cbTrenerzy);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.txtKraj);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.btnUsun);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.lblImie);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.btnZapisz);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.txtImie);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.numWaga);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.label2);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.numWzrost);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.txtNazwisko);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.label3);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.label6);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.label4);
            this.pnlKontrolkiDoEdycji.Controls.Add(this.label5);
            this.pnlKontrolkiDoEdycji.Location = new System.Drawing.Point(12, 12);
            this.pnlKontrolkiDoEdycji.Name = "pnlKontrolkiDoEdycji";
            this.pnlKontrolkiDoEdycji.Size = new System.Drawing.Size(213, 345);
            this.pnlKontrolkiDoEdycji.TabIndex = 18;
            // 
            // cbTrenerzy
            // 
            this.cbTrenerzy.FormattingEnabled = true;
            this.cbTrenerzy.Location = new System.Drawing.Point(14, 273);
            this.cbTrenerzy.Name = "cbTrenerzy";
            this.cbTrenerzy.Size = new System.Drawing.Size(184, 21);
            this.cbTrenerzy.TabIndex = 18;
            // 
            // dtpDataUr
            // 
            this.dtpDataUr.Location = new System.Drawing.Point(14, 161);
            this.dtpDataUr.Name = "dtpDataUr";
            this.dtpDataUr.Size = new System.Drawing.Size(184, 22);
            this.dtpDataUr.TabIndex = 19;
            this.dtpDataUr.Value = new System.DateTime(2024, 11, 15, 13, 40, 34, 177);
            // 
            // FrmSzczegoly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 369);
            this.Controls.Add(this.pnlKontrolkiDoEdycji);
            this.Name = "FrmSzczegoly";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.numWzrost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaga)).EndInit();
            this.pnlKontrolkiDoEdycji.ResumeLayout(false);
            this.pnlKontrolkiDoEdycji.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblImie;
        private System.Windows.Forms.TextBox txtImie;
        private System.Windows.Forms.TextBox txtNazwisko;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKraj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numWzrost;
        private System.Windows.Forms.NumericUpDown numWaga;
        private System.Windows.Forms.Button btnZapisz;
        private System.Windows.Forms.Button btnUsun;
        private System.Windows.Forms.Panel pnlKontrolkiDoEdycji;
        private System.Windows.Forms.ComboBox cbTrenerzy;
        private P08ZadanieFiltorwanieDanych.CustomDateTimePicker dtpDataUr;
    }
}