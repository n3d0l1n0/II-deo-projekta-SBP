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
    public partial class ServisVozilaForma : Form
    {
        private int voziloId;
        private string registarskaOznaka;
        public ServisVozilaForma()
        {
            InitializeComponent();
        }
        public ServisVozilaForma(int voziloId, string registarskaOznaka)
        {
            InitializeComponent();
            this.voziloId = voziloId;
            this.registarskaOznaka = registarskaOznaka;
        }

        public void PopuniPodatke()
        {
            cmbStatusServisa.Items.Clear();
            cmbStatusServisa.Items.AddRange(new string[] { "Redovan","Vanredni" });
            cmbStatusServisa.DropDownStyle = ComboBoxStyle.DropDownList;
            listViewServisi.Items.Clear();

            List<ServisVozilaPregled> podaci = DTOManager.VratiSveServiseZaVozilo(this.voziloId);

            foreach (var p in podaci)
            {
                ServisVozilaBasic servis = DTOManager.VratiServisVozila(p.Id);
                ListViewItem item = new ListViewItem(new string[] { servis.StatusServisa, servis.DatumPocetka.ToShortDateString(), servis.DatumKraja?.ToShortDateString() ?? "-------" });
                item.Tag = servis.Id; 
                listViewServisi.Items.Add(item);
            }

            listViewServisi.Refresh();
            OcistiPolja();
        }
        private void OcistiPolja()
        {
            cmbStatusServisa.SelectedIndex = -1;
            dtpPocetak.Value = DateTime.Now;
            dtpKraj.Value = DateTime.Now;
            chbZavrsen.Checked = false;
            dtpKraj.Enabled = false;
            listViewServisi.SelectedItems.Clear();
        }
        private void chbZavrsen_CheckedChanged(object sender, EventArgs e)
        {
            dtpKraj.Enabled = chbZavrsen.Checked;
        }
        private void listViewServisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewServisi.SelectedItems.Count == 0)
            {
                return;
            }

            int idServisa = (int)listViewServisi.SelectedItems[0].Tag;
            ServisVozilaBasic servis = DTOManager.VratiServisVozila(idServisa);

            if (servis != null)
            {
                cmbStatusServisa.SelectedItem = servis.StatusServisa;
                dtpPocetak.Value = servis.DatumPocetka;

                if (servis.DatumKraja.HasValue)
                {
                    chbZavrsen.Checked = true;
                    dtpKraj.Enabled = true;
                    dtpKraj.Value = servis.DatumKraja.Value;
                }
                else
                {
                    chbZavrsen.Checked = false;
                    dtpKraj.Enabled = false;
                }
            }
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (cmbStatusServisa.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati status servisa.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ServisVozilaBasic servis = new ServisVozilaBasic
                {
                    StatusServisa = cmbStatusServisa.SelectedItem.ToString(),
                    DatumPocetka = dtpPocetak.Value,
                    DatumKraja = chbZavrsen.Checked ? (DateTime?)dtpKraj.Value : null,
                    VoziloId = this.voziloId
                };

                DTOManager.SacuvajServisVozila(servis);
                MessageBox.Show("Uspešno ste dodali novi servis.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopuniPodatke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja servisa: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (listViewServisi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite servis koji želite da izmenite.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbStatusServisa.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati status servisa.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int idServisa = (int)listViewServisi.SelectedItems[0].Tag;

                ServisVozilaBasic servis = new ServisVozilaBasic
                {
                    Id = idServisa,
                    StatusServisa = cmbStatusServisa.SelectedItem.ToString(),
                    DatumPocetka = dtpPocetak.Value,
                    DatumKraja = chbZavrsen.Checked ? (DateTime?)dtpKraj.Value : null,
                    VoziloId = this.voziloId
                };

                DTOManager.IzmeniServisVozila(servis);
                MessageBox.Show("Uspešno ste izmenili servis.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopuniPodatke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja izmene servisa: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (listViewServisi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite servis koji želite da obrišete.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int idServisa = (int)listViewServisi.SelectedItems[0].Tag;
                var poruka = MessageBox.Show("Da li ste sigurni da želite da obrišete izabrani servis?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (poruka == DialogResult.Yes)
                {
                    DTOManager.ObrisiServisVozila(idServisa);
                    MessageBox.Show("Uspešno ste obrisali servis.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopuniPodatke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom brisanja servisa: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ServisVozilaForma_Load(object sender, EventArgs e)
        {
            PopuniPodatke();
        }
    }
    
}
