namespace II_deo_projekta_baze_19406
{
    partial class VoziloForma
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
            this.listViewVozila = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtRegistracija = new System.Windows.Forms.TextBox();
            this.txtProizvodjac = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numKapacitet = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numGodinaProizvodnje = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpPregled = new System.Windows.Forms.DateTimePicker();
            this.dtpRegistracija = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbStanica = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chbVatrogasno = new System.Windows.Forms.CheckBox();
            this.chbSpasilacko = new System.Windows.Forms.CheckBox();
            this.chbTehnickaPodrska = new System.Windows.Forms.CheckBox();
            this.cmbTipVatrogasno = new System.Windows.Forms.ComboBox();
            this.cmbTipSpasilacko = new System.Windows.Forms.ComboBox();
            this.cmbTipTehnickaPodrska = new System.Windows.Forms.ComboBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnServisVozila = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSertifikat = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numKapacitet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGodinaProizvodnje)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewVozila
            // 
            this.listViewVozila.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listViewVozila.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewVozila.HideSelection = false;
            this.listViewVozila.Location = new System.Drawing.Point(12, 22);
            this.listViewVozila.Name = "listViewVozila";
            this.listViewVozila.Size = new System.Drawing.Size(654, 136);
            this.listViewVozila.TabIndex = 0;
            this.listViewVozila.UseCompatibleStateImageBehavior = false;
            this.listViewVozila.View = System.Windows.Forms.View.Details;
            this.listViewVozila.SelectedIndexChanged += new System.EventHandler(this.listViewVozila_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Registarska oznaka";
            this.columnHeader2.Width = 168;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Proizvodjac";
            this.columnHeader3.Width = 108;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status vozila";
            this.columnHeader4.Width = 119;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tip vozila";
            this.columnHeader5.Width = 115;
            // 
            // txtRegistracija
            // 
            this.txtRegistracija.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtRegistracija.Location = new System.Drawing.Point(9, 51);
            this.txtRegistracija.MaxLength = 30;
            this.txtRegistracija.Name = "txtRegistracija";
            this.txtRegistracija.Size = new System.Drawing.Size(121, 24);
            this.txtRegistracija.TabIndex = 1;
            // 
            // txtProizvodjac
            // 
            this.txtProizvodjac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtProizvodjac.Location = new System.Drawing.Point(9, 99);
            this.txtProizvodjac.MaxLength = 30;
            this.txtProizvodjac.Name = "txtProizvodjac";
            this.txtProizvodjac.Size = new System.Drawing.Size(121, 24);
            this.txtProizvodjac.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Proizvodjac";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Registarska oznaka";
            // 
            // numKapacitet
            // 
            this.numKapacitet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.numKapacitet.Location = new System.Drawing.Point(10, 194);
            this.numKapacitet.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numKapacitet.Name = "numKapacitet";
            this.numKapacitet.Size = new System.Drawing.Size(123, 24);
            this.numKapacitet.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kapacitet";
            // 
            // numGodinaProizvodnje
            // 
            this.numGodinaProizvodnje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.numGodinaProizvodnje.Location = new System.Drawing.Point(10, 241);
            this.numGodinaProizvodnje.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numGodinaProizvodnje.Name = "numGodinaProizvodnje";
            this.numGodinaProizvodnje.Size = new System.Drawing.Size(123, 24);
            this.numGodinaProizvodnje.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Godina proizvodnje";
            // 
            // dtpPregled
            // 
            this.dtpPregled.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dtpPregled.Location = new System.Drawing.Point(207, 72);
            this.dtpPregled.Name = "dtpPregled";
            this.dtpPregled.Size = new System.Drawing.Size(200, 24);
            this.dtpPregled.TabIndex = 9;
            // 
            // dtpRegistracija
            // 
            this.dtpRegistracija.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dtpRegistracija.Location = new System.Drawing.Point(207, 126);
            this.dtpRegistracija.Name = "dtpRegistracija";
            this.dtpRegistracija.Size = new System.Drawing.Size(200, 24);
            this.dtpRegistracija.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(204, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Datum poslednjeg pregleda";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(204, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Datum isteka registracije";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Operativno",
            "Neispravno",
            "U servisu"});
            this.cmbStatus.Location = new System.Drawing.Point(9, 143);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 26);
            this.cmbStatus.TabIndex = 13;
            // 
            // cmbStanica
            // 
            this.cmbStanica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbStanica.FormattingEnabled = true;
            this.cmbStanica.Location = new System.Drawing.Point(207, 174);
            this.cmbStanica.Name = "cmbStanica";
            this.cmbStanica.Size = new System.Drawing.Size(200, 26);
            this.cmbStanica.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(204, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Stanica";
            // 
            // chbVatrogasno
            // 
            this.chbVatrogasno.AutoSize = true;
            this.chbVatrogasno.Location = new System.Drawing.Point(31, 30);
            this.chbVatrogasno.Name = "chbVatrogasno";
            this.chbVatrogasno.Size = new System.Drawing.Size(109, 20);
            this.chbVatrogasno.TabIndex = 17;
            this.chbVatrogasno.Text = "Vatrogasno";
            this.chbVatrogasno.UseVisualStyleBackColor = true;
            this.chbVatrogasno.CheckedChanged += new System.EventHandler(this.chbVatrogasno_CheckedChanged);
            // 
            // chbSpasilacko
            // 
            this.chbSpasilacko.AutoSize = true;
            this.chbSpasilacko.Location = new System.Drawing.Point(31, 86);
            this.chbSpasilacko.Name = "chbSpasilacko";
            this.chbSpasilacko.Size = new System.Drawing.Size(107, 20);
            this.chbSpasilacko.TabIndex = 18;
            this.chbSpasilacko.Text = "Spasilacko";
            this.chbSpasilacko.UseVisualStyleBackColor = true;
            this.chbSpasilacko.CheckedChanged += new System.EventHandler(this.chbSpasilacko_CheckedChanged);
            // 
            // chbTehnickaPodrska
            // 
            this.chbTehnickaPodrska.AutoSize = true;
            this.chbTehnickaPodrska.Location = new System.Drawing.Point(31, 142);
            this.chbTehnickaPodrska.Name = "chbTehnickaPodrska";
            this.chbTehnickaPodrska.Size = new System.Drawing.Size(154, 20);
            this.chbTehnickaPodrska.TabIndex = 19;
            this.chbTehnickaPodrska.Text = "Tehnicka podrska";
            this.chbTehnickaPodrska.UseVisualStyleBackColor = true;
            this.chbTehnickaPodrska.CheckedChanged += new System.EventHandler(this.chbTehnickaPodrska_CheckedChanged);
            // 
            // cmbTipVatrogasno
            // 
            this.cmbTipVatrogasno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbTipVatrogasno.FormattingEnabled = true;
            this.cmbTipVatrogasno.Items.AddRange(new object[] {
            "Cisterna",
            "Platforma",
            "Za gasenje suma"});
            this.cmbTipVatrogasno.Location = new System.Drawing.Point(78, 56);
            this.cmbTipVatrogasno.Name = "cmbTipVatrogasno";
            this.cmbTipVatrogasno.Size = new System.Drawing.Size(121, 24);
            this.cmbTipVatrogasno.TabIndex = 20;
            // 
            // cmbTipSpasilacko
            // 
            this.cmbTipSpasilacko.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbTipSpasilacko.FormattingEnabled = true;
            this.cmbTipSpasilacko.Items.AddRange(new object[] {
            "Poplave",
            "Saobracajne nesrece"});
            this.cmbTipSpasilacko.Location = new System.Drawing.Point(78, 110);
            this.cmbTipSpasilacko.Name = "cmbTipSpasilacko";
            this.cmbTipSpasilacko.Size = new System.Drawing.Size(121, 24);
            this.cmbTipSpasilacko.TabIndex = 21;
            // 
            // cmbTipTehnickaPodrska
            // 
            this.cmbTipTehnickaPodrska.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbTipTehnickaPodrska.FormattingEnabled = true;
            this.cmbTipTehnickaPodrska.Items.AddRange(new object[] {
            "Oprema",
            "Tehnicar"});
            this.cmbTipTehnickaPodrska.Location = new System.Drawing.Point(78, 168);
            this.cmbTipTehnickaPodrska.Name = "cmbTipTehnickaPodrska";
            this.cmbTipTehnickaPodrska.Size = new System.Drawing.Size(121, 24);
            this.cmbTipTehnickaPodrska.TabIndex = 22;
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.Coral;
            this.btnDodaj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDodaj.Location = new System.Drawing.Point(212, 283);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(200, 46);
            this.btnDodaj.TabIndex = 23;
            this.btnDodaj.Text = "Dodaj vozilo";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.BackColor = System.Drawing.Color.Coral;
            this.btnObrisi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnObrisi.Location = new System.Drawing.Point(6, 283);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(200, 46);
            this.btnObrisi.TabIndex = 25;
            this.btnObrisi.Text = "Obrisi vozilo";
            this.btnObrisi.UseVisualStyleBackColor = false;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // btnServisVozila
            // 
            this.btnServisVozila.BackColor = System.Drawing.Color.Coral;
            this.btnServisVozila.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnServisVozila.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServisVozila.ForeColor = System.Drawing.Color.DarkRed;
            this.btnServisVozila.Location = new System.Drawing.Point(452, 488);
            this.btnServisVozila.Name = "btnServisVozila";
            this.btnServisVozila.Size = new System.Drawing.Size(214, 44);
            this.btnServisVozila.TabIndex = 26;
            this.btnServisVozila.Text = "Servisi vozila";
            this.btnServisVozila.UseVisualStyleBackColor = false;
            this.btnServisVozila.Click += new System.EventHandler(this.btnServisVozila_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbVatrogasno);
            this.groupBox1.Controls.Add(this.cmbTipVatrogasno);
            this.groupBox1.Controls.Add(this.chbSpasilacko);
            this.groupBox1.Controls.Add(this.cmbTipSpasilacko);
            this.groupBox1.Controls.Add(this.cmbTipTehnickaPodrska);
            this.groupBox1.Controls.Add(this.chbTehnickaPodrska);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(452, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 218);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tip vozila";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnIzmeni);
            this.groupBox2.Controls.Add(this.btnSertifikat);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtRegistracija);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnObrisi);
            this.groupBox2.Controls.Add(this.txtProizvodjac);
            this.groupBox2.Controls.Add(this.btnDodaj);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbStanica);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cmbStatus);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtpRegistracija);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.numKapacitet);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpPregled);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numGodinaProizvodnje);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox2.Location = new System.Drawing.Point(12, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 386);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Podaci o vozilu";
            // 
            // btnSertifikat
            // 
            this.btnSertifikat.BackColor = System.Drawing.Color.Coral;
            this.btnSertifikat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSertifikat.Location = new System.Drawing.Point(207, 222);
            this.btnSertifikat.Name = "btnSertifikat";
            this.btnSertifikat.Size = new System.Drawing.Size(205, 43);
            this.btnSertifikat.TabIndex = 26;
            this.btnSertifikat.Text = "Dodatni sertifikati";
            this.btnSertifikat.UseVisualStyleBackColor = false;
            this.btnSertifikat.Click += new System.EventHandler(this.btnSertifikat_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Coral;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkRed;
            this.button1.Location = new System.Drawing.Point(452, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 46);
            this.button1.TabIndex = 33;
            this.button1.Text = "Zaduzeni tehnicar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.BackColor = System.Drawing.Color.Coral;
            this.btnIzmeni.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIzmeni.Location = new System.Drawing.Point(6, 335);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(406, 43);
            this.btnIzmeni.TabIndex = 27;
            this.btnIzmeni.Text = "Izmeni vozilo";
            this.btnIzmeni.UseVisualStyleBackColor = false;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // VoziloForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(685, 562);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listViewVozila);
            this.Controls.Add(this.btnServisVozila);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VoziloForma";
            this.Text = "Vozila stanice";
            this.Load += new System.EventHandler(this.VoziloForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numKapacitet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGodinaProizvodnje)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewVozila;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox txtRegistracija;
        private System.Windows.Forms.TextBox txtProizvodjac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numKapacitet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numGodinaProizvodnje;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpPregled;
        private System.Windows.Forms.DateTimePicker dtpRegistracija;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbStanica;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chbVatrogasno;
        private System.Windows.Forms.CheckBox chbSpasilacko;
        private System.Windows.Forms.CheckBox chbTehnickaPodrska;
        private System.Windows.Forms.ComboBox cmbTipVatrogasno;
        private System.Windows.Forms.ComboBox cmbTipSpasilacko;
        private System.Windows.Forms.ComboBox cmbTipTehnickaPodrska;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnServisVozila;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSertifikat;
        private System.Windows.Forms.Button btnIzmeni;
    }
}