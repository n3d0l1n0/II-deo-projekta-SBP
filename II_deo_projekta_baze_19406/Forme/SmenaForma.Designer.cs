namespace II_deo_projekta_baze_19406.Forme
{
    partial class SmenaForma
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
            this.listViewSmene = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpVremeKraja = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpVremePocetka = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.listViewSviRadnici = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.listViewVatrogasci = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.listViewDispeceri = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSviRadnici = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDodajRadnika = new System.Windows.Forms.Button();
            this.btnUkloniIzSvih = new System.Windows.Forms.Button();
            this.btnUkloniVatrogasca = new System.Windows.Forms.Button();
            this.btnUkloniDispecera = new System.Windows.Forms.Button();
            this.listViewIntervencije = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblUkupno = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewSmene
            // 
            this.listViewSmene.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listViewSmene.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewSmene.HideSelection = false;
            this.listViewSmene.Location = new System.Drawing.Point(12, 30);
            this.listViewSmene.Name = "listViewSmene";
            this.listViewSmene.Size = new System.Drawing.Size(431, 97);
            this.listViewSmene.TabIndex = 0;
            this.listViewSmene.UseCompatibleStateImageBehavior = false;
            this.listViewSmene.View = System.Windows.Forms.View.Details;
            this.listViewSmene.SelectedIndexChanged += new System.EventHandler(this.listViewSmene_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Datum smene";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Vreme rada";
            this.columnHeader2.Width = 260;
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(6, 52);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(200, 24);
            this.dtpDatum.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpVremeKraja);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpVremePocetka);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDatum);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(12, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 239);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podaci o smeni";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Vreme kraja";
            // 
            // dtpVremeKraja
            // 
            this.dtpVremeKraja.Location = new System.Drawing.Point(6, 183);
            this.dtpVremeKraja.Name = "dtpVremeKraja";
            this.dtpVremeKraja.Size = new System.Drawing.Size(200, 24);
            this.dtpVremeKraja.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vreme pocetka";
            // 
            // dtpVremePocetka
            // 
            this.dtpVremePocetka.Location = new System.Drawing.Point(6, 115);
            this.dtpVremePocetka.Name = "dtpVremePocetka";
            this.dtpVremePocetka.Size = new System.Drawing.Size(200, 24);
            this.dtpVremePocetka.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Datum";
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.Coral;
            this.btnDodaj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodaj.ForeColor = System.Drawing.Color.DarkRed;
            this.btnDodaj.Location = new System.Drawing.Point(269, 152);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(142, 38);
            this.btnDodaj.TabIndex = 3;
            this.btnDodaj.Text = "Dodaj smenu";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.BackColor = System.Drawing.Color.Coral;
            this.btnIzmeni.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIzmeni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmeni.ForeColor = System.Drawing.Color.DarkRed;
            this.btnIzmeni.Location = new System.Drawing.Point(269, 230);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(142, 40);
            this.btnIzmeni.TabIndex = 4;
            this.btnIzmeni.Text = "Izmeni smenu";
            this.btnIzmeni.UseVisualStyleBackColor = false;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.BackColor = System.Drawing.Color.Coral;
            this.btnObrisi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnObrisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisi.ForeColor = System.Drawing.Color.DarkRed;
            this.btnObrisi.Location = new System.Drawing.Point(269, 314);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(142, 40);
            this.btnObrisi.TabIndex = 5;
            this.btnObrisi.Text = "Obrisi smenu";
            this.btnObrisi.UseVisualStyleBackColor = false;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // listViewSviRadnici
            // 
            this.listViewSviRadnici.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listViewSviRadnici.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listViewSviRadnici.HideSelection = false;
            this.listViewSviRadnici.Location = new System.Drawing.Point(469, 30);
            this.listViewSviRadnici.Name = "listViewSviRadnici";
            this.listViewSviRadnici.Size = new System.Drawing.Size(458, 116);
            this.listViewSviRadnici.TabIndex = 6;
            this.listViewSviRadnici.UseCompatibleStateImageBehavior = false;
            this.listViewSviRadnici.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ime i prezime";
            this.columnHeader3.Width = 286;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(466, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Lista svih zaposlenih u smeni";
            // 
            // listViewVatrogasci
            // 
            this.listViewVatrogasci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listViewVatrogasci.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.listViewVatrogasci.HideSelection = false;
            this.listViewVatrogasci.Location = new System.Drawing.Point(469, 227);
            this.listViewVatrogasci.Name = "listViewVatrogasci";
            this.listViewVatrogasci.Size = new System.Drawing.Size(458, 97);
            this.listViewVatrogasci.TabIndex = 8;
            this.listViewVatrogasci.UseCompatibleStateImageBehavior = false;
            this.listViewVatrogasci.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ime i prezime";
            this.columnHeader4.Width = 293;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(466, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Dezurna ekipa vatrogasaca";
            // 
            // listViewDispeceri
            // 
            this.listViewDispeceri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listViewDispeceri.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.listViewDispeceri.HideSelection = false;
            this.listViewDispeceri.Location = new System.Drawing.Point(469, 404);
            this.listViewDispeceri.Name = "listViewDispeceri";
            this.listViewDispeceri.Size = new System.Drawing.Size(458, 97);
            this.listViewDispeceri.TabIndex = 10;
            this.listViewDispeceri.UseCompatibleStateImageBehavior = false;
            this.listViewDispeceri.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ime i prezime";
            this.columnHeader5.Width = 294;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(466, 383);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Angazovani dispeceri";
            // 
            // cmbSviRadnici
            // 
            this.cmbSviRadnici.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbSviRadnici.FormattingEnabled = true;
            this.cmbSviRadnici.Location = new System.Drawing.Point(499, 593);
            this.cmbSviRadnici.Name = "cmbSviRadnici";
            this.cmbSviRadnici.Size = new System.Drawing.Size(196, 24);
            this.cmbSviRadnici.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(496, 574);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Izaberite radnika";
            // 
            // btnDodajRadnika
            // 
            this.btnDodajRadnika.BackColor = System.Drawing.Color.Coral;
            this.btnDodajRadnika.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDodajRadnika.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajRadnika.ForeColor = System.Drawing.Color.DarkRed;
            this.btnDodajRadnika.Location = new System.Drawing.Point(721, 574);
            this.btnDodajRadnika.Name = "btnDodajRadnika";
            this.btnDodajRadnika.Size = new System.Drawing.Size(190, 43);
            this.btnDodajRadnika.TabIndex = 14;
            this.btnDodajRadnika.Text = "Dodaj radnika";
            this.btnDodajRadnika.UseVisualStyleBackColor = false;
            this.btnDodajRadnika.Click += new System.EventHandler(this.btnDodajRadnika_Click);
            // 
            // btnUkloniIzSvih
            // 
            this.btnUkloniIzSvih.BackColor = System.Drawing.Color.Coral;
            this.btnUkloniIzSvih.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUkloniIzSvih.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUkloniIzSvih.ForeColor = System.Drawing.Color.Maroon;
            this.btnUkloniIzSvih.Location = new System.Drawing.Point(600, 152);
            this.btnUkloniIzSvih.Name = "btnUkloniIzSvih";
            this.btnUkloniIzSvih.Size = new System.Drawing.Size(215, 27);
            this.btnUkloniIzSvih.TabIndex = 15;
            this.btnUkloniIzSvih.Text = "Obrisi zaposlenog";
            this.btnUkloniIzSvih.UseVisualStyleBackColor = false;
            this.btnUkloniIzSvih.Click += new System.EventHandler(this.btnUkloniIzSvih_Click);
            // 
            // btnUkloniVatrogasca
            // 
            this.btnUkloniVatrogasca.BackColor = System.Drawing.Color.Coral;
            this.btnUkloniVatrogasca.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUkloniVatrogasca.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUkloniVatrogasca.ForeColor = System.Drawing.Color.DarkRed;
            this.btnUkloniVatrogasca.Location = new System.Drawing.Point(600, 330);
            this.btnUkloniVatrogasca.Name = "btnUkloniVatrogasca";
            this.btnUkloniVatrogasca.Size = new System.Drawing.Size(215, 27);
            this.btnUkloniVatrogasca.TabIndex = 16;
            this.btnUkloniVatrogasca.Text = "Obrisi vatrogasca";
            this.btnUkloniVatrogasca.UseVisualStyleBackColor = false;
            this.btnUkloniVatrogasca.Click += new System.EventHandler(this.btnUkloniVatrogasca_Click);
            // 
            // btnUkloniDispecera
            // 
            this.btnUkloniDispecera.BackColor = System.Drawing.Color.Coral;
            this.btnUkloniDispecera.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUkloniDispecera.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUkloniDispecera.ForeColor = System.Drawing.Color.DarkRed;
            this.btnUkloniDispecera.Location = new System.Drawing.Point(600, 513);
            this.btnUkloniDispecera.Name = "btnUkloniDispecera";
            this.btnUkloniDispecera.Size = new System.Drawing.Size(215, 27);
            this.btnUkloniDispecera.TabIndex = 17;
            this.btnUkloniDispecera.Text = "Obrisi dispecera";
            this.btnUkloniDispecera.UseVisualStyleBackColor = false;
            this.btnUkloniDispecera.Click += new System.EventHandler(this.btnUkloniDispecera_Click);
            // 
            // listViewIntervencije
            // 
            this.listViewIntervencije.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listViewIntervencije.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listViewIntervencije.HideSelection = false;
            this.listViewIntervencije.Location = new System.Drawing.Point(12, 404);
            this.listViewIntervencije.Name = "listViewIntervencije";
            this.listViewIntervencije.Size = new System.Drawing.Size(431, 155);
            this.listViewIntervencije.TabIndex = 18;
            this.listViewIntervencije.UseCompatibleStateImageBehavior = false;
            this.listViewIntervencije.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Broj intervencije";
            this.columnHeader6.Width = 132;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Datum";
            this.columnHeader7.Width = 97;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Tip";
            this.columnHeader8.Width = 74;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Adresa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(15, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 18);
            this.label8.TabIndex = 19;
            this.label8.Text = "Dostupne smene u stanici";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(9, 383);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(284, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "Dokumentovane intervencije u smeni";
            // 
            // lblUkupno
            // 
            this.lblUkupno.AutoSize = true;
            this.lblUkupno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUkupno.ForeColor = System.Drawing.Color.DarkRed;
            this.lblUkupno.Location = new System.Drawing.Point(18, 573);
            this.lblUkupno.Name = "lblUkupno";
            this.lblUkupno.Size = new System.Drawing.Size(194, 18);
            this.lblUkupno.TabIndex = 21;
            this.lblUkupno.Text = "Ukupan broj intervencija:";
            // 
            // SmenaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(966, 639);
            this.Controls.Add(this.lblUkupno);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listViewIntervencije);
            this.Controls.Add(this.btnUkloniDispecera);
            this.Controls.Add(this.btnUkloniVatrogasca);
            this.Controls.Add(this.btnUkloniIzSvih);
            this.Controls.Add(this.btnDodajRadnika);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbSviRadnici);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listViewDispeceri);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listViewVatrogasci);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listViewSviRadnici);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listViewSmene);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SmenaForma";
            this.Text = "SmenaForma";
            this.Load += new System.EventHandler(this.SmenaForma_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewSmene;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpVremeKraja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpVremePocetka;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.ListView listViewSviRadnici;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listViewVatrogasci;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listViewDispeceri;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSviRadnici;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDodajRadnika;
        private System.Windows.Forms.Button btnUkloniIzSvih;
        private System.Windows.Forms.Button btnUkloniVatrogasca;
        private System.Windows.Forms.Button btnUkloniDispecera;
        private System.Windows.Forms.ListView listViewIntervencije;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblUkupno;
    }
}