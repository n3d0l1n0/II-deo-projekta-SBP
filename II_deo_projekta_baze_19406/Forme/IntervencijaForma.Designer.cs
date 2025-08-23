namespace II_deo_projekta_baze_19406
{
    partial class IntervencijaForma
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
            this.listViewIntervencije = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpVremeOd = new System.Windows.Forms.DateTimePicker();
            this.dtpVremeDo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpVremeDolaska = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTipIntervencije = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.cmbStanjeIntervencije = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.dtpStatusDatum = new System.Windows.Forms.DateTimePicker();
            this.dtpStatusVreme = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numBrojIntervencije = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbDispecer = new System.Windows.Forms.ComboBox();
            this.btnResursi = new System.Windows.Forms.Button();
            this.btnAngazovaniVatrogasci = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbSmene = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numBrojIntervencije)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewIntervencije
            // 
            this.listViewIntervencije.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listViewIntervencije.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewIntervencije.HideSelection = false;
            this.listViewIntervencije.Location = new System.Drawing.Point(12, 23);
            this.listViewIntervencije.Name = "listViewIntervencije";
            this.listViewIntervencije.Size = new System.Drawing.Size(887, 162);
            this.listViewIntervencije.TabIndex = 0;
            this.listViewIntervencije.UseCompatibleStateImageBehavior = false;
            this.listViewIntervencije.View = System.Windows.Forms.View.Details;
            this.listViewIntervencije.SelectedIndexChanged += new System.EventHandler(this.listViewIntervencije_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Broj intervencije";
            this.columnHeader1.Width = 162;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Datum";
            this.columnHeader2.Width = 155;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tip";
            this.columnHeader3.Width = 178;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Adresa";
            this.columnHeader4.Width = 200;
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(6, 49);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(200, 24);
            this.dtpDatum.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Datum";
            // 
            // dtpVremeOd
            // 
            this.dtpVremeOd.Location = new System.Drawing.Point(6, 102);
            this.dtpVremeOd.Name = "dtpVremeOd";
            this.dtpVremeOd.Size = new System.Drawing.Size(200, 24);
            this.dtpVremeOd.TabIndex = 3;
            // 
            // dtpVremeDo
            // 
            this.dtpVremeDo.Location = new System.Drawing.Point(6, 157);
            this.dtpVremeDo.Name = "dtpVremeDo";
            this.dtpVremeDo.Size = new System.Drawing.Size(200, 24);
            this.dtpVremeDo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Vreme pocetka intervencije";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Vreme kraja intervencije";
            // 
            // dtpVremeDolaska
            // 
            this.dtpVremeDolaska.Location = new System.Drawing.Point(6, 206);
            this.dtpVremeDolaska.Name = "dtpVremeDolaska";
            this.dtpVremeDolaska.Size = new System.Drawing.Size(200, 24);
            this.dtpVremeDolaska.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Vreme dolaska na lokaciju";
            // 
            // cmbTipIntervencije
            // 
            this.cmbTipIntervencije.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbTipIntervencije.FormattingEnabled = true;
            this.cmbTipIntervencije.Items.AddRange(new object[] {
            "Pozar",
            "Saobracajna nesreca",
            "Poplava",
            "Spasavanje zivotinja",
            "Tehnicka intervencija",
            "Drugo"});
            this.cmbTipIntervencije.Location = new System.Drawing.Point(244, 51);
            this.cmbTipIntervencije.Name = "cmbTipIntervencije";
            this.cmbTipIntervencije.Size = new System.Drawing.Size(129, 26);
            this.cmbTipIntervencije.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Vrsta intervencije";
            // 
            // txtAdresa
            // 
            this.txtAdresa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtAdresa.Location = new System.Drawing.Point(244, 101);
            this.txtAdresa.MaxLength = 30;
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(129, 24);
            this.txtAdresa.TabIndex = 11;
            // 
            // txtOpis
            // 
            this.txtOpis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtOpis.Location = new System.Drawing.Point(244, 159);
            this.txtOpis.MaxLength = 20;
            this.txtOpis.Multiline = true;
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(129, 22);
            this.txtOpis.TabIndex = 12;
            // 
            // cmbStanjeIntervencije
            // 
            this.cmbStanjeIntervencije.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbStanjeIntervencije.FormattingEnabled = true;
            this.cmbStanjeIntervencije.Items.AddRange(new object[] {
            "U toku",
            "Zavrsena",
            "Odlozena"});
            this.cmbStanjeIntervencije.Location = new System.Drawing.Point(9, 73);
            this.cmbStanjeIntervencije.Name = "cmbStanjeIntervencije";
            this.cmbStanjeIntervencije.Size = new System.Drawing.Size(248, 26);
            this.cmbStanjeIntervencije.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "Adresa lokacije";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(241, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 18);
            this.label7.TabIndex = 15;
            this.label7.Text = "Opis situacije";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 18);
            this.label8.TabIndex = 16;
            this.label8.Text = "Stanje intervencije";
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.Coral;
            this.btnDodaj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodaj.ForeColor = System.Drawing.Color.DarkRed;
            this.btnDodaj.Location = new System.Drawing.Point(454, 221);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(165, 48);
            this.btnDodaj.TabIndex = 17;
            this.btnDodaj.Text = "Dodaj intervenciju";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.BackColor = System.Drawing.Color.Coral;
            this.btnIzmeni.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIzmeni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmeni.ForeColor = System.Drawing.Color.DarkRed;
            this.btnIzmeni.Location = new System.Drawing.Point(454, 283);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(165, 48);
            this.btnIzmeni.TabIndex = 18;
            this.btnIzmeni.Text = "Izmeni intervenciju";
            this.btnIzmeni.UseVisualStyleBackColor = false;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.BackColor = System.Drawing.Color.Coral;
            this.btnObrisi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnObrisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisi.ForeColor = System.Drawing.Color.DarkRed;
            this.btnObrisi.Location = new System.Drawing.Point(454, 346);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(165, 48);
            this.btnObrisi.TabIndex = 19;
            this.btnObrisi.Text = "Obrisi intervenciju";
            this.btnObrisi.UseVisualStyleBackColor = false;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // dtpStatusDatum
            // 
            this.dtpStatusDatum.Location = new System.Drawing.Point(9, 130);
            this.dtpStatusDatum.Name = "dtpStatusDatum";
            this.dtpStatusDatum.Size = new System.Drawing.Size(248, 24);
            this.dtpStatusDatum.TabIndex = 20;
            // 
            // dtpStatusVreme
            // 
            this.dtpStatusVreme.Location = new System.Drawing.Point(9, 190);
            this.dtpStatusVreme.Name = "dtpStatusVreme";
            this.dtpStatusVreme.Size = new System.Drawing.Size(248, 24);
            this.dtpStatusVreme.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 18);
            this.label9.TabIndex = 22;
            this.label9.Text = "Datum promene statusa";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(187, 18);
            this.label10.TabIndex = 23;
            this.label10.Text = "Vreme promene statusa";
            // 
            // numBrojIntervencije
            // 
            this.numBrojIntervencije.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.numBrojIntervencije.Location = new System.Drawing.Point(244, 206);
            this.numBrojIntervencije.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numBrojIntervencije.Name = "numBrojIntervencije";
            this.numBrojIntervencije.Size = new System.Drawing.Size(129, 24);
            this.numBrojIntervencije.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(241, 187);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 18);
            this.label11.TabIndex = 25;
            this.label11.Text = "Broj intervencije";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbStanjeIntervencije);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtpStatusVreme);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dtpStatusDatum);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(636, 194);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 233);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Istorija promene statusa intervencije";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkRed;
            this.label12.Location = new System.Drawing.Point(34, 453);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(222, 18);
            this.label12.TabIndex = 27;
            this.label12.Text = "Dispecer koji je primio poziv";
            // 
            // cmbDispecer
            // 
            this.cmbDispecer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbDispecer.FormattingEnabled = true;
            this.cmbDispecer.Location = new System.Drawing.Point(100, 479);
            this.cmbDispecer.Name = "cmbDispecer";
            this.cmbDispecer.Size = new System.Drawing.Size(200, 24);
            this.cmbDispecer.TabIndex = 28;
            // 
            // btnResursi
            // 
            this.btnResursi.BackColor = System.Drawing.Color.Coral;
            this.btnResursi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResursi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResursi.ForeColor = System.Drawing.Color.DarkRed;
            this.btnResursi.Location = new System.Drawing.Point(354, 444);
            this.btnResursi.Name = "btnResursi";
            this.btnResursi.Size = new System.Drawing.Size(251, 37);
            this.btnResursi.TabIndex = 29;
            this.btnResursi.Text = "Upotrebljeni resursi";
            this.btnResursi.UseVisualStyleBackColor = false;
            this.btnResursi.Click += new System.EventHandler(this.btnResursi_Click);
            // 
            // btnAngazovaniVatrogasci
            // 
            this.btnAngazovaniVatrogasci.BackColor = System.Drawing.Color.Coral;
            this.btnAngazovaniVatrogasci.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAngazovaniVatrogasci.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAngazovaniVatrogasci.ForeColor = System.Drawing.Color.DarkRed;
            this.btnAngazovaniVatrogasci.Location = new System.Drawing.Point(354, 487);
            this.btnAngazovaniVatrogasci.Name = "btnAngazovaniVatrogasci";
            this.btnAngazovaniVatrogasci.Size = new System.Drawing.Size(251, 37);
            this.btnAngazovaniVatrogasci.TabIndex = 30;
            this.btnAngazovaniVatrogasci.Text = "Vatrogasci u intervenciji";
            this.btnAngazovaniVatrogasci.UseVisualStyleBackColor = false;
            this.btnAngazovaniVatrogasci.Click += new System.EventHandler(this.btnAngazovaniVatrogasci_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtpDatum);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbTipIntervencije);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpVremeOd);
            this.groupBox2.Controls.Add(this.numBrojIntervencije);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtAdresa);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtpVremeDo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dtpVremeDolaska);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtOpis);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox2.Location = new System.Drawing.Point(15, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 236);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Podaci o intervenciji";
            // 
            // cmbSmene
            // 
            this.cmbSmene.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbSmene.FormattingEnabled = true;
            this.cmbSmene.Location = new System.Drawing.Point(645, 479);
            this.cmbSmene.Name = "cmbSmene";
            this.cmbSmene.Size = new System.Drawing.Size(248, 24);
            this.cmbSmene.TabIndex = 32;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkRed;
            this.label13.Location = new System.Drawing.Point(642, 458);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(182, 18);
            this.label13.TabIndex = 33;
            this.label13.Text = "Smena za angazovanje";
            // 
            // IntervencijaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(928, 538);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbSmene);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAngazovaniVatrogasci);
            this.Controls.Add(this.btnResursi);
            this.Controls.Add(this.cmbDispecer);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.listViewIntervencije);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IntervencijaForma";
            this.Text = "Dostupne intervencije";
            this.Load += new System.EventHandler(this.IntervencijaForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numBrojIntervencije)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewIntervencije;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpVremeOd;
        private System.Windows.Forms.DateTimePicker dtpVremeDo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpVremeDolaska;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTipIntervencije;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.ComboBox cmbStanjeIntervencije;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.DateTimePicker dtpStatusDatum;
        private System.Windows.Forms.DateTimePicker dtpStatusVreme;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numBrojIntervencije;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbDispecer;
        private System.Windows.Forms.Button btnResursi;
        private System.Windows.Forms.Button btnAngazovaniVatrogasci;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbSmene;
        private System.Windows.Forms.Label label13;
    }
}