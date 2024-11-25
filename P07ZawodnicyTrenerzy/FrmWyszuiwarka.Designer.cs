namespace P08ZadanieFiltorwanieDanych
{
    partial class FrmWyszuiwarka
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
            this.txtSzukaj = new System.Windows.Forms.TextBox();
            this.btnSzukaj = new System.Windows.Forms.Button();
            this.pnlOsoby = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtSzukaj
            // 
            this.txtSzukaj.Location = new System.Drawing.Point(12, 12);
            this.txtSzukaj.Name = "txtSzukaj";
            this.txtSzukaj.Size = new System.Drawing.Size(365, 20);
            this.txtSzukaj.TabIndex = 0;
            // 
            // btnSzukaj
            // 
            this.btnSzukaj.Location = new System.Drawing.Point(384, 13);
            this.btnSzukaj.Name = "btnSzukaj";
            this.btnSzukaj.Size = new System.Drawing.Size(75, 23);
            this.btnSzukaj.TabIndex = 1;
            this.btnSzukaj.Text = "Szukaj";
            this.btnSzukaj.UseVisualStyleBackColor = true;
            this.btnSzukaj.Click += new System.EventHandler(this.btnSzukaj_Click);
            // 
            // pnlOsoby
            // 
            this.pnlOsoby.Location = new System.Drawing.Point(12, 38);
            this.pnlOsoby.Name = "pnlOsoby";
            this.pnlOsoby.Size = new System.Drawing.Size(447, 338);
            this.pnlOsoby.TabIndex = 2;
            // 
            // FrmWyszuiwarka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 388);
            this.Controls.Add(this.pnlOsoby);
            this.Controls.Add(this.btnSzukaj);
            this.Controls.Add(this.txtSzukaj);
            this.Name = "FrmWyszuiwarka";
            this.Text = "FrmWyszuiwarka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSzukaj;
        private System.Windows.Forms.Button btnSzukaj;
        private System.Windows.Forms.Panel pnlOsoby;
    }
}