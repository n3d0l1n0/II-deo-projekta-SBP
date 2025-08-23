namespace II_deo_projekta_baze_19406
{
    partial class OpremaForma
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
            this.listViewOprema = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txtInventarskiBroj = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDatumNabavke = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chbZastitna = new System.Windows.Forms.CheckBox();
            this.chbTehnicka = new System.Windows.Forms.CheckBox();
            this.chbZaPozare = new System.Windows.Forms.CheckBox();
            this.chbSpecijalna = new System.Windows.Forms.CheckBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTipTehnicka = new System.Windows.Forms.ComboBox();
            this.cmbTipSpecijalna = new System.Windows.Forms.ComboBox();
            this.cmbTipZaPozare = new System.Windows.Forms.ComboBox();
            this.cmbTipZastitna = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbLokacijaVozilo = new System.Windows.Forms.ComboBox();
            this.cmbLokacijaStanica = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listViewIntervencija = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtZaduzenoLice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTehnicari = new System.Windows.Forms.ComboBox();
            this.btnZaduzi = new System.Windows.Forms.Button();
            this.btnRazduzi = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewOprema
            // 
            this.listViewOprema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listViewOprema.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewOprema.HideSelection = false;
            this.listViewOprema.Location = new System.Drawing.Point(12, 46);
            this.listViewOprema.Name = "listViewOprema";
            this.listViewOprema.Size = new System.Drawing.Size(659, 175);
            this.listViewOprema.TabIndex = 0;
            this.listViewOprema.UseCompatibleStateImageBehavior = false;
            this.listViewOprema.View = System.Windows.Forms.View.Details;
            this.listViewOprema.SelectedIndexChanged += new System.EventHandler(this.listViewOprema_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Inventarski broj";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            this.columnHeader4.Width = 153;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Lokacija";
            this.columnHeader5.Width = 144;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Prikaz dostupne opreme";
            // 
            // txtInventarskiBroj
            // 
            this.txtInventarskiBroj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtInventarskiBroj.Location = new System.Drawing.Point(17, 44);
            this.txtInventarskiBroj.Name = "txtInventarskiBroj";
            this.txtInventarskiBroj.Size = new System.Drawing.Size(200, 24);
            this.txtInventarskiBroj.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Inventarski broj";
            // 
            // dtpDatumNabavke
            // 
            this.dtpDatumNabavke.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatumNabavke.CalendarForeColor = System.Drawing.Color.DarkRed;
            this.dtpDatumNabavke.Location = new System.Drawing.Point(17, 96);
            this.dtpDatumNabavke.Name = "dtpDatumNabavke";
            this.dtpDatumNabavke.Size = new System.Drawing.Size(200, 24);
            this.dtpDatumNabavke.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Datum nabavke";
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Rashodovano",
            "Ispravno",
            "Osteceno"});
            this.cmbStatus.Location = new System.Drawing.Point(17, 149);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 26);
            this.cmbStatus.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Status opreme";
            // 
            // chbZastitna
            // 
            this.chbZastitna.AutoSize = true;
            this.chbZastitna.Location = new System.Drawing.Point(11, 30);
            this.chbZastitna.Name = "chbZastitna";
            this.chbZastitna.Size = new System.Drawing.Size(90, 22);
            this.chbZastitna.TabIndex = 14;
            this.chbZastitna.Text = "Zastitna";
            this.chbZastitna.UseVisualStyleBackColor = true;
            this.chbZastitna.CheckedChanged += new System.EventHandler(this.chbZastitna_CheckedChanged);
            // 
            // chbTehnicka
            // 
            this.chbTehnicka.AutoSize = true;
            this.chbTehnicka.Location = new System.Drawing.Point(11, 210);
            this.chbTehnicka.Name = "chbTehnicka";
            this.chbTehnicka.Size = new System.Drawing.Size(98, 22);
            this.chbTehnicka.TabIndex = 15;
            this.chbTehnicka.Text = "Tehnicka";
            this.chbTehnicka.UseVisualStyleBackColor = true;
            this.chbTehnicka.CheckedChanged += new System.EventHandler(this.chbTehnicka_CheckedChanged);
            // 
            // chbZaPozare
            // 
            this.chbZaPozare.AutoSize = true;
            this.chbZaPozare.Location = new System.Drawing.Point(11, 86);
            this.chbZaPozare.Name = "chbZaPozare";
            this.chbZaPozare.Size = new System.Drawing.Size(106, 22);
            this.chbZaPozare.TabIndex = 16;
            this.chbZaPozare.Text = "Za pozare";
            this.chbZaPozare.UseVisualStyleBackColor = true;
            this.chbZaPozare.CheckedChanged += new System.EventHandler(this.chbZaPozare_CheckedChanged);
            // 
            // chbSpecijalna
            // 
            this.chbSpecijalna.AutoSize = true;
            this.chbSpecijalna.Location = new System.Drawing.Point(11, 147);
            this.chbSpecijalna.Name = "chbSpecijalna";
            this.chbSpecijalna.Size = new System.Drawing.Size(107, 22);
            this.chbSpecijalna.TabIndex = 17;
            this.chbSpecijalna.Text = "Specijalna";
            this.chbSpecijalna.UseVisualStyleBackColor = true;
            this.chbSpecijalna.CheckedChanged += new System.EventHandler(this.chbSpecijalna_CheckedChanged);
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.Coral;
            this.btnDodaj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodaj.ForeColor = System.Drawing.Color.DarkRed;
            this.btnDodaj.Location = new System.Drawing.Point(687, 57);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(203, 46);
            this.btnDodaj.TabIndex = 18;
            this.btnDodaj.Text = "Dodaj opremu";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.BackColor = System.Drawing.Color.Coral;
            this.btnIzmeni.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIzmeni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmeni.ForeColor = System.Drawing.Color.DarkRed;
            this.btnIzmeni.Location = new System.Drawing.Point(687, 109);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(203, 46);
            this.btnIzmeni.TabIndex = 19;
            this.btnIzmeni.Text = "Izmeni opremu";
            this.btnIzmeni.UseVisualStyleBackColor = false;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.BackColor = System.Drawing.Color.Coral;
            this.btnObrisi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnObrisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisi.ForeColor = System.Drawing.Color.DarkRed;
            this.btnObrisi.Location = new System.Drawing.Point(687, 161);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(203, 46);
            this.btnObrisi.TabIndex = 20;
            this.btnObrisi.Text = "Obrisi opremu";
            this.btnObrisi.UseVisualStyleBackColor = false;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTipTehnicka);
            this.groupBox1.Controls.Add(this.cmbTipSpecijalna);
            this.groupBox1.Controls.Add(this.cmbTipZaPozare);
            this.groupBox1.Controls.Add(this.cmbTipZastitna);
            this.groupBox1.Controls.Add(this.chbZastitna);
            this.groupBox1.Controls.Add(this.chbZaPozare);
            this.groupBox1.Controls.Add(this.chbTehnicka);
            this.groupBox1.Controls.Add(this.chbSpecijalna);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(320, 227);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 292);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tip opreme";
            // 
            // cmbTipTehnicka
            // 
            this.cmbTipTehnicka.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbTipTehnicka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipTehnicka.FormattingEnabled = true;
            this.cmbTipTehnicka.Items.AddRange(new object[] {
            "Testera",
            "Makaze",
            "Radio"});
            this.cmbTipTehnicka.Location = new System.Drawing.Point(110, 238);
            this.cmbTipTehnicka.Name = "cmbTipTehnicka";
            this.cmbTipTehnicka.Size = new System.Drawing.Size(146, 26);
            this.cmbTipTehnicka.TabIndex = 21;
            // 
            // cmbTipSpecijalna
            // 
            this.cmbTipSpecijalna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbTipSpecijalna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipSpecijalna.FormattingEnabled = true;
            this.cmbTipSpecijalna.Items.AddRange(new object[] {
            "Kamera",
            "Dron",
            "Detektor"});
            this.cmbTipSpecijalna.Location = new System.Drawing.Point(110, 175);
            this.cmbTipSpecijalna.Name = "cmbTipSpecijalna";
            this.cmbTipSpecijalna.Size = new System.Drawing.Size(146, 26);
            this.cmbTipSpecijalna.TabIndex = 20;
            // 
            // cmbTipZaPozare
            // 
            this.cmbTipZaPozare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbTipZaPozare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipZaPozare.FormattingEnabled = true;
            this.cmbTipZaPozare.Items.AddRange(new object[] {
            "Crevo",
            "Pumpa",
            "Aparat"});
            this.cmbTipZaPozare.Location = new System.Drawing.Point(110, 104);
            this.cmbTipZaPozare.Name = "cmbTipZaPozare";
            this.cmbTipZaPozare.Size = new System.Drawing.Size(146, 26);
            this.cmbTipZaPozare.TabIndex = 19;
            // 
            // cmbTipZastitna
            // 
            this.cmbTipZastitna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbTipZastitna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipZastitna.FormattingEnabled = true;
            this.cmbTipZastitna.Items.AddRange(new object[] {
            "Odelo",
            "Kaciga",
            "Cizme"});
            this.cmbTipZastitna.Location = new System.Drawing.Point(110, 44);
            this.cmbTipZastitna.Name = "cmbTipZastitna";
            this.cmbTipZastitna.Size = new System.Drawing.Size(146, 26);
            this.cmbTipZastitna.TabIndex = 18;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbLokacijaVozilo);
            this.groupBox2.Controls.Add(this.cmbLokacijaStanica);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtInventarskiBroj);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbStatus);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpDatumNabavke);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox2.Location = new System.Drawing.Point(24, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 292);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Podaci o opremi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "stanica";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 18);
            this.label7.TabIndex = 23;
            this.label7.Text = "vozilo";
            // 
            // cmbLokacijaVozilo
            // 
            this.cmbLokacijaVozilo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbLokacijaVozilo.FormattingEnabled = true;
            this.cmbLokacijaVozilo.Location = new System.Drawing.Point(128, 243);
            this.cmbLokacijaVozilo.Name = "cmbLokacijaVozilo";
            this.cmbLokacijaVozilo.Size = new System.Drawing.Size(121, 26);
            this.cmbLokacijaVozilo.TabIndex = 23;
            this.cmbLokacijaVozilo.SelectedIndexChanged += new System.EventHandler(this.cmbLokacijaVozilo_SelectedIndexChanged);
            // 
            // cmbLokacijaStanica
            // 
            this.cmbLokacijaStanica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbLokacijaStanica.FormattingEnabled = true;
            this.cmbLokacijaStanica.Location = new System.Drawing.Point(128, 205);
            this.cmbLokacijaStanica.Name = "cmbLokacijaStanica";
            this.cmbLokacijaStanica.Size = new System.Drawing.Size(121, 26);
            this.cmbLokacijaStanica.TabIndex = 23;
            this.cmbLokacijaStanica.SelectedIndexChanged += new System.EventHandler(this.cmbLokacijaStanica_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 18);
            this.label6.TabIndex = 23;
            this.label6.Text = "Lokacija";
            // 
            // listViewIntervencija
            // 
            this.listViewIntervencija.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listViewIntervencija.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader7});
            this.listViewIntervencija.HideSelection = false;
            this.listViewIntervencija.Location = new System.Drawing.Point(12, 562);
            this.listViewIntervencija.Name = "listViewIntervencija";
            this.listViewIntervencija.Size = new System.Drawing.Size(878, 164);
            this.listViewIntervencija.TabIndex = 23;
            this.listViewIntervencija.UseCompatibleStateImageBehavior = false;
            this.listViewIntervencija.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID intervencije";
            this.columnHeader3.Width = 113;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tip intervencije";
            this.columnHeader6.Width = 180;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Datum intervencije";
            this.columnHeader7.Width = 200;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(12, 541);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 18);
            this.label3.TabIndex = 24;
            this.label3.Text = "Istorija upotrebe opreme u intervencijama";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(684, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(198, 18);
            this.label9.TabIndex = 25;
            this.label9.Text = "Zaduzeno lice za opremu";
            // 
            // txtZaduzenoLice
            // 
            this.txtZaduzenoLice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtZaduzenoLice.Location = new System.Drawing.Point(687, 282);
            this.txtZaduzenoLice.Name = "txtZaduzenoLice";
            this.txtZaduzenoLice.ReadOnly = true;
            this.txtZaduzenoLice.Size = new System.Drawing.Size(203, 22);
            this.txtZaduzenoLice.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkRed;
            this.label10.Location = new System.Drawing.Point(684, 328);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(151, 18);
            this.label10.TabIndex = 27;
            this.label10.Text = "Zaduzi opremu licu";
            // 
            // cmbTehnicari
            // 
            this.cmbTehnicari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbTehnicari.FormattingEnabled = true;
            this.cmbTehnicari.Location = new System.Drawing.Point(687, 351);
            this.cmbTehnicari.Name = "cmbTehnicari";
            this.cmbTehnicari.Size = new System.Drawing.Size(203, 24);
            this.cmbTehnicari.TabIndex = 28;
            // 
            // btnZaduzi
            // 
            this.btnZaduzi.BackColor = System.Drawing.Color.Coral;
            this.btnZaduzi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnZaduzi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZaduzi.ForeColor = System.Drawing.Color.DarkRed;
            this.btnZaduzi.Location = new System.Drawing.Point(721, 394);
            this.btnZaduzi.Name = "btnZaduzi";
            this.btnZaduzi.Size = new System.Drawing.Size(139, 65);
            this.btnZaduzi.TabIndex = 29;
            this.btnZaduzi.Text = "Zaduzi opremu";
            this.btnZaduzi.UseVisualStyleBackColor = false;
            this.btnZaduzi.Click += new System.EventHandler(this.btnZaduzi_Click);
            // 
            // btnRazduzi
            // 
            this.btnRazduzi.BackColor = System.Drawing.Color.Coral;
            this.btnRazduzi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRazduzi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRazduzi.ForeColor = System.Drawing.Color.DarkRed;
            this.btnRazduzi.Location = new System.Drawing.Point(721, 473);
            this.btnRazduzi.Name = "btnRazduzi";
            this.btnRazduzi.Size = new System.Drawing.Size(139, 66);
            this.btnRazduzi.TabIndex = 30;
            this.btnRazduzi.Text = "Razduzi opremu";
            this.btnRazduzi.UseVisualStyleBackColor = false;
            this.btnRazduzi.Click += new System.EventHandler(this.btnRazduzi_Click);
            // 
            // OpremaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(910, 738);
            this.Controls.Add(this.btnRazduzi);
            this.Controls.Add(this.btnZaduzi);
            this.Controls.Add(this.cmbTehnicari);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtZaduzenoLice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listViewIntervencija);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewOprema);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpremaForma";
            this.Text = "Oprema stanice";
            this.Load += new System.EventHandler(this.OpremaForma_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewOprema;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInventarskiBroj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDatumNabavke;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbZastitna;
        private System.Windows.Forms.CheckBox chbTehnicka;
        private System.Windows.Forms.CheckBox chbZaPozare;
        private System.Windows.Forms.CheckBox chbSpecijalna;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbLokacijaVozilo;
        private System.Windows.Forms.ComboBox cmbLokacijaStanica;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTipTehnicka;
        private System.Windows.Forms.ComboBox cmbTipSpecijalna;
        private System.Windows.Forms.ComboBox cmbTipZaPozare;
        private System.Windows.Forms.ComboBox cmbTipZastitna;
        private System.Windows.Forms.ListView listViewIntervencija;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtZaduzenoLice;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbTehnicari;
        private System.Windows.Forms.Button btnZaduzi;
        private System.Windows.Forms.Button btnRazduzi;
    }
}