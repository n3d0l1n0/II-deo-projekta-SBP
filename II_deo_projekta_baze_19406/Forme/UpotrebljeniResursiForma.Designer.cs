namespace II_deo_projekta_baze_19406.Forme
{
    partial class UpotrebljeniResursiForma
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
            this.listViewResursi = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDodajVozilo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVozila = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDodajOpremu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOprema = new System.Windows.Forms.ComboBox();
            this.btnUkloniResurs = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewResursi
            // 
            this.listViewResursi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listViewResursi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewResursi.HideSelection = false;
            this.listViewResursi.Location = new System.Drawing.Point(12, 12);
            this.listViewResursi.Name = "listViewResursi";
            this.listViewResursi.Size = new System.Drawing.Size(433, 411);
            this.listViewResursi.TabIndex = 0;
            this.listViewResursi.UseCompatibleStateImageBehavior = false;
            this.listViewResursi.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tip resursa";
            this.columnHeader1.Width = 135;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Identifikator";
            this.columnHeader2.Width = 106;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDodajVozilo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbVozila);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox1.Location = new System.Drawing.Point(460, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 148);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vozila";
            // 
            // btnDodajVozilo
            // 
            this.btnDodajVozilo.BackColor = System.Drawing.Color.Coral;
            this.btnDodajVozilo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDodajVozilo.Location = new System.Drawing.Point(38, 97);
            this.btnDodajVozilo.Name = "btnDodajVozilo";
            this.btnDodajVozilo.Size = new System.Drawing.Size(124, 28);
            this.btnDodajVozilo.TabIndex = 3;
            this.btnDodajVozilo.Text = "Dodaj vozilo";
            this.btnDodajVozilo.UseVisualStyleBackColor = false;
            this.btnDodajVozilo.Click += new System.EventHandler(this.btnDodajVozilo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Izaberi vozilo";
            // 
            // cmbVozila
            // 
            this.cmbVozila.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbVozila.FormattingEnabled = true;
            this.cmbVozila.Location = new System.Drawing.Point(18, 48);
            this.cmbVozila.Name = "cmbVozila";
            this.cmbVozila.Size = new System.Drawing.Size(176, 26);
            this.cmbVozila.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDodajOpremu);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbOprema);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox2.Location = new System.Drawing.Point(460, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 148);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Oprema";
            // 
            // btnDodajOpremu
            // 
            this.btnDodajOpremu.BackColor = System.Drawing.Color.Coral;
            this.btnDodajOpremu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDodajOpremu.Location = new System.Drawing.Point(38, 89);
            this.btnDodajOpremu.Name = "btnDodajOpremu";
            this.btnDodajOpremu.Size = new System.Drawing.Size(124, 32);
            this.btnDodajOpremu.TabIndex = 3;
            this.btnDodajOpremu.Text = "Dodaj opremu";
            this.btnDodajOpremu.UseVisualStyleBackColor = false;
            this.btnDodajOpremu.Click += new System.EventHandler(this.btnDodajOpremu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Izaberi opremu";
            // 
            // cmbOprema
            // 
            this.cmbOprema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cmbOprema.FormattingEnabled = true;
            this.cmbOprema.Location = new System.Drawing.Point(18, 48);
            this.cmbOprema.Name = "cmbOprema";
            this.cmbOprema.Size = new System.Drawing.Size(176, 26);
            this.cmbOprema.TabIndex = 3;
            this.cmbOprema.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbOprema_Format);
            // 
            // btnUkloniResurs
            // 
            this.btnUkloniResurs.BackColor = System.Drawing.Color.Coral;
            this.btnUkloniResurs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUkloniResurs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUkloniResurs.ForeColor = System.Drawing.Color.DarkRed;
            this.btnUkloniResurs.Location = new System.Drawing.Point(493, 361);
            this.btnUkloniResurs.Name = "btnUkloniResurs";
            this.btnUkloniResurs.Size = new System.Drawing.Size(140, 43);
            this.btnUkloniResurs.TabIndex = 3;
            this.btnUkloniResurs.Text = "Obrisi resurs";
            this.btnUkloniResurs.UseVisualStyleBackColor = false;
            this.btnUkloniResurs.Click += new System.EventHandler(this.btnUkloniResurs_Click);
            // 
            // UpotrebljeniResursiForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(681, 433);
            this.Controls.Add(this.btnUkloniResurs);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listViewResursi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpotrebljeniResursiForma";
            this.Text = "UpotrebljeniResursiForma";
            this.Load += new System.EventHandler(this.UpotrebljeniResursiForma_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewResursi;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDodajVozilo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVozila;
        private System.Windows.Forms.Button btnDodajOpremu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOprema;
        private System.Windows.Forms.Button btnUkloniResurs;
    }
}