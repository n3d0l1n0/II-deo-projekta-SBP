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

namespace II_deo_projekta_baze_19406
{
    public partial class SertifikatForma : Form
    {
        public SertifikatForma()
        {
            InitializeComponent();
        }
        private int voziloId;
        public SertifikatForma(int voziloId, string registarskaOznaka)
        {
            InitializeComponent();
            this.voziloId = voziloId;
            this.Text = $"Sertifikati za vozilo: {registarskaOznaka}";
        }
        private void SertifikatForma_Load(object sender, EventArgs e)
        {
            PopuniPodatke();
        }
        public void PopuniPodatke()
        {
            listViewSertifikati.Items.Clear();
            List<SertifikatPregled> podaci = DTOManager.VratiSertifikateZaVozilo(this.voziloId);

            foreach (var p in podaci)
            {
                ListViewItem item = new ListViewItem(p.NazivSertifikata);
                item.Tag = p.Id; 
                listViewSertifikati.Items.Add(item);
            }

            listViewSertifikati.Refresh();
            OcistiPolja();
        }
        private void OcistiPolja()
        {
            txtNazivSertifikata.Text = string.Empty;
            listViewSertifikati.SelectedItems.Clear();
        }
        private void listViewSertifikati_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSertifikati.SelectedItems.Count == 0)
            {
                txtNazivSertifikata.Text = string.Empty;
                return;
            }

            txtNazivSertifikata.Text = listViewSertifikati.SelectedItems[0].Text;
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazivSertifikata.Text))
            {
                MessageBox.Show("Morate uneti naziv sertifikata.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try 
            {
                SertifikatBasic noviSertifikat = new SertifikatBasic
                {
                    NazivSertifikata = txtNazivSertifikata.Text,
                    IdVozila = this.voziloId
                };

                DTOManager.DodajSertifikatVozilu(noviSertifikat);
                MessageBox.Show("Uspešno ste dodali novi sertifikat.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopuniPodatke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja sertifikata: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (listViewSertifikati.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite sertifikat koji zelite da obrisete.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try 
            {

                int idSertifikata = (int)listViewSertifikati.SelectedItems[0].Tag;
                var poruka = MessageBox.Show("Da li ste sigurni da zelite da obrisete izabrani sertifikat?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (poruka == DialogResult.Yes)
                {
                    DTOManager.ObrisiSertifikat(idSertifikata);
                    MessageBox.Show("Uspesno ste obrisali sertifikat.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopuniPodatke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom brisanja sertifikata: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (listViewSertifikati.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite sertifikat koji zelite da izmenite.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNazivSertifikata.Text))
            {
                MessageBox.Show("Naziv sertifikata ne sme biti prazan.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try 
            {
                int idSertifikata = (int)listViewSertifikati.SelectedItems[0].Tag;

                SertifikatBasic sertifikatZaIzmenu = new SertifikatBasic
                {
                    Id = idSertifikata,
                    NazivSertifikata = txtNazivSertifikata.Text
                };

                DTOManager.IzmeniSertifikat(sertifikatZaIzmenu);
                MessageBox.Show("Uspesno ste izmenili sertifikat.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopuniPodatke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom izmene sertifikata: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
