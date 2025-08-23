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
    public partial class TelefonForma : Form
    {
        public TelefonForma()
        {
            InitializeComponent();
        }
        private int idOsobe;
        private bool jeVolonter;

        public TelefonForma(int idOsobe, bool jeVolonter, string imeOsobe)
        {
            InitializeComponent();
            this.idOsobe = idOsobe;
            this.jeVolonter = jeVolonter;
            this.Text = $"Telefoni za: {imeOsobe}";
        }
        private void TelefonForma_Load(object sender, EventArgs e)
        {
            PopuniTelefone();
        }
        private void PopuniTelefone()
        {
            listViewTelefoni.Items.Clear();
            List<TelefonPregled> telefoni;

            if (this.jeVolonter)
            {
                telefoni = DTOManager.VratiTelefoneZaVolontera(this.idOsobe);
            }
            else
            {
                telefoni = DTOManager.VratiTelefoneZaLice(this.idOsobe);
            }

            foreach (var tel in telefoni)
            {
                ListViewItem item = new ListViewItem(tel.BrojTelefona);
                item.Tag = tel.Id;
                listViewTelefoni.Items.Add(item);
            }
            listViewTelefoni.Refresh();
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoviTelefon.Text))
            {
                MessageBox.Show("Unesite broj telefona.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                TelefonBasic noviTelefon = new TelefonBasic
                {
                    BrojTelefona = txtNoviTelefon.Text
                };

                if (this.jeVolonter)
                {
                    noviTelefon.IdVolontera = this.idOsobe;
                }
                else
                {
                    noviTelefon.IdLica = this.idOsobe;
                }

                DTOManager.DodajTelefon(noviTelefon);
                PopuniTelefone();
                txtNoviTelefon.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja telefona: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (listViewTelefoni.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite broj telefona koji želite da obrišete.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int idTelefona = (int)listViewTelefoni.SelectedItems[0].Tag;

                var poruka = MessageBox.Show("Da li ste sigurni da želite da obrišete ovaj broj?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (poruka == DialogResult.Yes)
                {
                    DTOManager.ObrisiTelefon(idTelefona);
                    PopuniTelefone();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom brisanja telefona: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnZatvori_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
