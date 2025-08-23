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
    public partial class VoziloForma : Form
    {
        public VoziloForma()
        {
            InitializeComponent();
        }

        public void PopuniPodatke()
        {

            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] { "Operativno", "Neispravno", "U servisu" });
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbStanica.DataSource = DTOManager.VratiSveStaniceZaListu();
            cmbStanica.DisplayMember = "Naziv";
            cmbStanica.ValueMember = "Id";

            cmbTipVatrogasno.Items.Clear();
            cmbTipVatrogasno.Items.AddRange(new string[] { "Cisterna", "Platforma", "Za gasenje suma" });
            cmbTipVatrogasno.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbTipSpasilacko.Items.Clear();
            cmbTipSpasilacko.Items.AddRange(new string[] { "Poplave", "Saobracajne nesrece" });
            cmbTipSpasilacko.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbTipTehnickaPodrska.Items.Clear();
            cmbTipTehnickaPodrska.Items.AddRange(new string[] { "Oprema", "Tehnicar" });
            cmbTipTehnickaPodrska.DropDownStyle = ComboBoxStyle.DropDownList;


            listViewVozila.Items.Clear();
            List<VoziloPregled> podaci = DTOManager.VratiSvaVozila();
            foreach (VoziloPregled v in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { v.Id.ToString(), v.RegistarskaOznaka, v.Proizvodjac, v.StatusVozila, v.TipVozila });
                item.Tag = v.Id;
                listViewVozila.Items.Add(item);
            }
            listViewVozila.Refresh();

            OcistiPolja();
        }
        private void OcistiPolja()
        {
            txtRegistracija.Text = string.Empty;
            txtProizvodjac.Text = string.Empty;
            numKapacitet.Value = 0;
            numGodinaProizvodnje.Value = DateTime.Now.Year;
            dtpPregled.Value = DateTime.Now;
            dtpRegistracija.Value = DateTime.Now;
            cmbStatus.SelectedIndex = 0;
            cmbStanica.SelectedIndex = -1;

            AzurirajStanjeTipova(null);
            listViewVozila.SelectedItems.Clear();
        }
        private void AzurirajStanjeTipova(CheckBox aktivniCheckbox)
        {
            if (aktivniCheckbox != chbVatrogasno) chbVatrogasno.Checked = false;
            if (aktivniCheckbox != chbSpasilacko) chbSpasilacko.Checked = false;
            if (aktivniCheckbox != chbTehnickaPodrska) chbTehnickaPodrska.Checked = false;

            cmbTipVatrogasno.Enabled = (aktivniCheckbox == chbVatrogasno);
            if (!cmbTipVatrogasno.Enabled) cmbTipVatrogasno.SelectedIndex = -1;

            cmbTipSpasilacko.Enabled = (aktivniCheckbox == chbSpasilacko);
            if (!cmbTipSpasilacko.Enabled) cmbTipSpasilacko.SelectedIndex = -1;

            cmbTipTehnickaPodrska.Enabled = (aktivniCheckbox == chbTehnickaPodrska);
            if (!cmbTipTehnickaPodrska.Enabled) cmbTipTehnickaPodrska.SelectedIndex = -1;
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegistracija.Text))
            {
                MessageBox.Show("Registarska oznaka ne sme biti prazna.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbStanica.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati stanicu kojoj vozilo pripada.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (chbVatrogasno.Checked && cmbTipVatrogasno.SelectedIndex == -1 ||
                chbSpasilacko.Checked && cmbTipSpasilacko.SelectedIndex == -1 ||
                chbTehnickaPodrska.Checked && cmbTipTehnickaPodrska.SelectedIndex == -1)
            {
                MessageBox.Show("Ako je tip vozila izabran, morate odabrati i specificnu vrednost sa liste.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!chbVatrogasno.Checked && !chbSpasilacko.Checked && !chbTehnickaPodrska.Checked)
            {
                MessageBox.Show("Morate izabrati bar jedan tip vozila (vatrogasno, spasilacko ili tehnicka podrska).", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((chbVatrogasno.Checked && cmbTipVatrogasno.SelectedIndex == -1) ||
                (chbSpasilacko.Checked && cmbTipSpasilacko.SelectedIndex == -1) ||
                (chbTehnickaPodrska.Checked && cmbTipTehnickaPodrska.SelectedIndex == -1))
            {
                MessageBox.Show("Morate odabrati i specificno vozilo sa liste.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                VoziloBasic v = new VoziloBasic
                {
                    RegistarskaOznaka = txtRegistracija.Text,
                    Proizvodjac = txtProizvodjac.Text,
                    Kapacitet = (int)numKapacitet.Value,
                    GodinaProizvodnje = (int)numGodinaProizvodnje.Value,
                    DatumPoslednjegPregleda = dtpPregled.Value,
                    DatumIstekaRegistracije = dtpRegistracija.Value,
                    StatusVozila = cmbStatus.SelectedItem.ToString(),
                    IdStanice = (int)cmbStanica.SelectedValue,

                    FVatrogasno = chbVatrogasno.Checked ? 'T' : (char?)null,
                    TipVatrogasno = chbVatrogasno.Checked ? cmbTipVatrogasno.SelectedItem.ToString() : null,

                    FSpasilacko = chbSpasilacko.Checked ? 'T' : (char?)null,
                    TipSpasilacko = chbSpasilacko.Checked ? cmbTipSpasilacko.SelectedItem.ToString() : null,

                    FTehnickaPodrska = chbTehnickaPodrska.Checked ? 'T' : (char?)null,
                    TipTehnickaPodrska = chbTehnickaPodrska.Checked ? cmbTipTehnickaPodrska.SelectedItem.ToString() : null
                };

                DTOManager.SacuvajVozilo(v);
                MessageBox.Show("Uspesno ste dodali novo vozilo!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopuniPodatke(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja vozila: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (listViewVozila.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite vozilo koje zelite da obrisete.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idVozila = (int)listViewVozila.SelectedItems[0].Tag;
            var poruka = MessageBox.Show($"Da li ste sigurni da zelite da obrisete vozilo?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (poruka == DialogResult.Yes)
            {
                try
                {
                    DTOManager.ObrisiVozilo(idVozila);
                    MessageBox.Show("Uspesno ste obrisali vozilo!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopuniPodatke();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greska prilikom brisanja vozila: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void chbVatrogasno_CheckedChanged(object sender, EventArgs e)
        {
            if (chbVatrogasno.Checked)
            {
                AzurirajStanjeTipova(chbVatrogasno);
            }
        }
        private void chbSpasilacko_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSpasilacko.Checked)
            {
                AzurirajStanjeTipova(chbSpasilacko);
            }
        }
        private void chbTehnickaPodrska_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTehnickaPodrska.Checked)
            {
                AzurirajStanjeTipova(chbTehnickaPodrska);
            }
        }
        private void btnServisVozila_Click(object sender, EventArgs e)
        {
            if (listViewVozila.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite vozilo za koje zelite da vidite istoriju servisa.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idVozila = (int)listViewVozila.SelectedItems[0].Tag;
            string regOznaka = listViewVozila.SelectedItems[0].SubItems[1].Text; 

            ServisVozilaForma servisForma = new ServisVozilaForma(idVozila, regOznaka);
            servisForma.ShowDialog(); 
            PopuniPodatke();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listViewVozila.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite vozilo za koje zelite da uredite tehnicare.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idVozila = (int)listViewVozila.SelectedItems[0].Tag;
            string regOznaka = listViewVozila.SelectedItems[0].SubItems[1].Text;

            TehnicarOdrzavaVoziloForma tehnicariForma = new TehnicarOdrzavaVoziloForma(idVozila, regOznaka);
            tehnicariForma.ShowDialog(); 
        }
        private void VoziloForma_Load(object sender, EventArgs e)
        {
            PopuniPodatke();
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void btnSertifikat_Click(object sender, EventArgs e)
        {
            if (listViewVozila.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite vozilo za koje zelite da vidite sertifikate.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idVozila = (int)listViewVozila.SelectedItems[0].Tag;
            string regOznaka = listViewVozila.SelectedItems[0].SubItems[1].Text; 

            SertifikatForma sertifikatForma = new SertifikatForma(idVozila, regOznaka);
            sertifikatForma.ShowDialog(); 
        }
        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (listViewVozila.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite vozilo koje zelite da izmenite.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int idVozila = (int)listViewVozila.SelectedItems[0].Tag;
                VoziloBasic v = new VoziloBasic
                {
                    Id = idVozila,
                    RegistarskaOznaka = txtRegistracija.Text,
                    Proizvodjac = txtProizvodjac.Text,
                    Kapacitet = (int)numKapacitet.Value,
                    GodinaProizvodnje = (int)numGodinaProizvodnje.Value,
                    DatumPoslednjegPregleda = dtpPregled.Value,
                    DatumIstekaRegistracije = dtpRegistracija.Value,
                    StatusVozila = cmbStatus.SelectedItem.ToString(),
                    IdStanice = (int)cmbStanica.SelectedValue,
                    FVatrogasno = chbVatrogasno.Checked ? 'T' : (char?)null,
                    TipVatrogasno = chbVatrogasno.Checked ? cmbTipVatrogasno.SelectedItem.ToString() : null,
                    FSpasilacko = chbSpasilacko.Checked ? 'T' : (char?)null,
                    TipSpasilacko = chbSpasilacko.Checked ? cmbTipSpasilacko.SelectedItem.ToString() : null,
                    FTehnickaPodrska = chbTehnickaPodrska.Checked ? 'T' : (char?)null,
                    TipTehnickaPodrska = chbTehnickaPodrska.Checked ? cmbTipTehnickaPodrska.SelectedItem.ToString() : null
                };

                DTOManager.IzmeniVozilo(v);
                MessageBox.Show("Uspesno ste izmenili podatke o vozilu!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopuniPodatke();
            }
            catch (Exception ex)
            {
                string errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show($"Greska prilikom izmene vozila: {errorMessage}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void listViewVozila_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listViewVozila.SelectedItems.Count == 0)
            {
                OcistiPolja();
                return;
            }

            int idVozila = (int)listViewVozila.SelectedItems[0].Tag;
            VoziloBasic v = DTOManager.VratiVozilo(idVozila);

            if (v == null)
            {
                MessageBox.Show("Nije moguce ucitati podatke za izabrano vozilo.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                txtRegistracija.Text = v.RegistarskaOznaka;
                txtProizvodjac.Text = v.Proizvodjac;
                numKapacitet.Value = v.Kapacitet ?? 0;
                numGodinaProizvodnje.Value = v.GodinaProizvodnje ?? DateTime.Now.Year;
                dtpPregled.Value = v.DatumPoslednjegPregleda ?? DateTime.Now;
                dtpRegistracija.Value = v.DatumIstekaRegistracije ?? DateTime.Now;
                cmbStatus.SelectedItem = v.StatusVozila;
                cmbStanica.SelectedValue = v.IdStanice ?? -1;

                AzurirajStanjeTipova(null);

                if (v.FVatrogasno == 'T')
                {
                    chbVatrogasno.Checked = true;
                    AzurirajStanjeTipova(chbVatrogasno);
                    cmbTipVatrogasno.SelectedItem = v.TipVatrogasno; 
                }
                else if (v.FSpasilacko == 'T')
                {
                    chbSpasilacko.Checked = true;
                    AzurirajStanjeTipova(chbSpasilacko); 
                    cmbTipSpasilacko.SelectedItem = v.TipSpasilacko; 
                }
                else if (v.FTehnickaPodrska == 'T')
                {
                    chbTehnickaPodrska.Checked = true;
                    AzurirajStanjeTipova(chbTehnickaPodrska);
                    cmbTipTehnickaPodrska.SelectedItem = v.TipTehnickaPodrska; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do greske prilikom prikazivanja podataka: " + ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
