using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static II_deo_projekta_baze_19406.DTOs;

namespace II_deo_projekta_baze_19406.Forme
{
    public partial class UpravnikForma : Form
    {
        public UpravnikForma()
        {
            InitializeComponent();
        }
        private int stanicaId;

        public UpravnikForma(int stanicaId, string nazivStanice)
        {
            InitializeComponent();
            this.stanicaId = stanicaId;
            this.Text = $"Uredjivanje komandira za stanicu: {nazivStanice}";
        }
        private void UpravnikForma_Load(object sender, EventArgs e)
        {
            PopuniPodatke();
        }
        private void PopuniPodatke()
        {
            cmbSvaLica.DataSource = DTOManager.VratiSvaAngazovanaLica();
            cmbSvaLica.DisplayMember = "ImeIPrezime"; 
            cmbSvaLica.ValueMember = "ID";
            cmbSvaLica.SelectedIndex = -1; 

            AngazovanoLicePregled trenutniUpravnik = DTOManager.VratiUpravnikaStanice(this.stanicaId);

            if (trenutniUpravnik != null)
            {
                txtTrenutniUpravnik.Text = $"{trenutniUpravnik.Licno_ime} {trenutniUpravnik.Prezime}";
                btnUkloni.Enabled = true;
            }
            else
            {
                txtTrenutniUpravnik.Text = "Nije dodeljen komandir";
                btnUkloni.Enabled = false;
            }
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (cmbSvaLica.SelectedItem == null)
            {
                MessageBox.Show("Molimo vas, izaberite lice koje zelite da postavite za komandira.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int novoLiceId = (int)cmbSvaLica.SelectedValue;
                DTOManager.PostaviUpravnika(this.stanicaId, novoLiceId);

                MessageBox.Show("Komandir je uspesno postavljen.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja komandira: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUkloni_Click(object sender, EventArgs e)
        {
            var potvrda = MessageBox.Show("Da li ste sigurni da zelite da uklonite trenutnog komandira sa ove stanice?", "Potvrda uklanjanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (potvrda == DialogResult.Yes)
            {
                try
                {
                    DTOManager.UkloniUpravnika(this.stanicaId);
                    MessageBox.Show("Komandir je uspesno uklonjen.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greska prilikom brisanja komandira: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
