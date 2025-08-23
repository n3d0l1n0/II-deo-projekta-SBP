using II_deo_projekta_baze_19406.Entiteti;
using II_deo_projekta_baze_19406.Forme;
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
    public partial class IntervencijaForma : Form
    {
        public IntervencijaForma()
        {
            InitializeComponent();
        }

        private void IntervencijaForma_Load(object sender, EventArgs e)
        {
            PopuniPodatke();
        }
        public void PopuniPodatke()
        {
            dtpVremeOd.Format = DateTimePickerFormat.Custom;
            dtpVremeOd.CustomFormat = "HH:mm";
            dtpVremeOd.ShowUpDown = true;

            dtpVremeDo.Format = DateTimePickerFormat.Custom;
            dtpVremeDo.CustomFormat = "HH:mm";
            dtpVremeDo.ShowUpDown = true;

            dtpVremeDolaska.Format = DateTimePickerFormat.Custom;
            dtpVremeDolaska.CustomFormat = "HH:mm";
            dtpVremeDolaska.ShowUpDown = true;

            dtpStatusVreme.Format = DateTimePickerFormat.Custom;
            dtpStatusVreme.CustomFormat = "HH:mm";
            dtpStatusVreme.ShowUpDown = true;

            cmbSmene.DataSource = DTOManager.VratiSveSmene();
            cmbSmene.DisplayMember = "PrikazZaListu";
            cmbSmene.ValueMember = "Id"; 

            cmbTipIntervencije.Items.Clear();
            cmbTipIntervencije.Items.AddRange(new string[] { "Pozar", "Saobracajna nesreca", "Poplava", "Spasavanje zivotinja", "Tehnicka intervencija", "Drugo" });
            cmbTipIntervencije.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbStanjeIntervencije.Items.Clear();
            cmbStanjeIntervencije.Items.AddRange(new string[] { "U toku", "Zavrsena", "Odlozena" });
            cmbStanjeIntervencije.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbDispecer.DataSource = DTOManager.VratiSveDispecere();
            cmbDispecer.DisplayMember = "ImeIPrezime";
            cmbDispecer.ValueMember = "Id";

            listViewIntervencije.Items.Clear();
            List<IntervencijaPregled> podaci = DTOManager.VratiSveIntervencije();
            foreach (var p in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { p.BrojIntervencije.ToString(), p.Datum.ToShortDateString(), p.TipIntervencije, p.AdresaLokacije })
                {
                    Tag = p.Id
                };
                listViewIntervencije.Items.Add(item);
            }

            listViewIntervencije.Refresh();
            OcistiPolja();
        }
        private void OcistiPolja()
        {
            numBrojIntervencije.Value = 0;
            dtpDatum.Value = DateTime.Now;
            dtpVremeOd.Value = DateTime.Now;
            dtpVremeDo.Value = DateTime.Now;
            dtpVremeDolaska.Value = DateTime.Now;
            cmbTipIntervencije.SelectedIndex = -1;
            txtAdresa.Text = string.Empty;
            txtOpis.Text = string.Empty;
            cmbDispecer.SelectedIndex = -1;
            cmbSmene.SelectedIndex = -1;
            cmbStanjeIntervencije.SelectedIndex = -1;
            dtpStatusDatum.Value = DateTime.Now;
            dtpStatusVreme.Value = DateTime.Now;
            listViewIntervencije.SelectedItems.Clear();
        }
        private void listViewIntervencije_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewIntervencije.SelectedItems.Count == 0)
            {
                btnAngazovaniVatrogasci.Enabled = false;
                btnResursi.Enabled = false;
                OcistiPolja();
                return;
            }
            btnAngazovaniVatrogasci.Enabled = true;
            btnResursi.Enabled = true;

            int idIntervencije = (int)listViewIntervencije.SelectedItems[0].Tag;
            IntervencijaBasic i = DTOManager.VratiIntervenciju(idIntervencije);

            if (i != null)
            {
                numBrojIntervencije.Value = i.BrojIntervencije;
                dtpDatum.Value = i.Datum;
                dtpVremeOd.Value = i.VremeOd; 
                dtpVremeDo.Value = i.VremeDo; 
                dtpVremeDolaska.Value = i.VremeDolaska;
                cmbTipIntervencije.SelectedItem = i.TipIntervencije;
                txtAdresa.Text = i.AdresaLokacije;
                txtOpis.Text = i.OpisSituacije;
                if (i.IdDispecera.HasValue)
                {
                    cmbDispecer.SelectedValue = i.IdDispecera.Value;
                }
                else
                {
                    cmbDispecer.SelectedIndex = -1; 
                }
                StatusIntervencijeBasic status = DTOManager.VratiStatusIntervencije(i.IdStatusa);
                if (status != null)
                {
                    cmbStanjeIntervencije.SelectedItem = status.StanjeIntervencije;
                    dtpStatusDatum.Value = status.Datum;
                    dtpStatusVreme.Value = status.Vreme;
                }
            }
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (cmbStanjeIntervencije.SelectedIndex == -1 || cmbTipIntervencije.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati dispecera, stanje i tip intervencije.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                StatusIntervencijeBasic statusDto = new StatusIntervencijeBasic
                {
                    StanjeIntervencije = cmbStanjeIntervencije.SelectedItem.ToString(),
                    Datum = dtpStatusDatum.Value.Date,
                    Vreme = dtpStatusVreme.Value
                };

                IntervencijaBasic intervencijaDto = new IntervencijaBasic
                {
                    BrojIntervencije = (int)numBrojIntervencije.Value,
                    OpisSituacije = txtOpis.Text,
                    Datum = dtpDatum.Value.Date,
                    VremeOd = dtpVremeOd.Value, 
                    VremeDo = dtpVremeDo.Value, 
                    VremeDolaska = dtpVremeDolaska.Value,
                    TipIntervencije = cmbTipIntervencije.SelectedItem.ToString(),
                    AdresaLokacije = txtAdresa.Text,
                    IdDispecera = (int?)cmbDispecer.SelectedValue
                };

                DTOManager.SacuvajIntervenciju(intervencijaDto, statusDto);

                MessageBox.Show("Uspesno ste dodali novu intervenciju.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopuniPodatke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja izmene: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (listViewIntervencije.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite intervenciju koju zelite da izmenite.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                IntervencijaBasic postojecaIntervencija = DTOManager.VratiIntervenciju((int)listViewIntervencije.SelectedItems[0].Tag);

                StatusIntervencijeBasic statusDto = new StatusIntervencijeBasic
                {
                    Id = postojecaIntervencija.IdStatusa,
                    StanjeIntervencije = cmbStanjeIntervencije.SelectedItem.ToString(),
                    Datum = dtpStatusDatum.Value.Date,
                    Vreme = dtpStatusVreme.Value
                };

                IntervencijaBasic intervencijaDto = new IntervencijaBasic
                {
                    Id = postojecaIntervencija.Id,
                    BrojIntervencije = (int)numBrojIntervencije.Value,
                    OpisSituacije = txtOpis.Text,
                    Datum = dtpDatum.Value.Date,
                    VremeOd = dtpVremeOd.Value, 
                    VremeDo = dtpVremeDo.Value, 
                    VremeDolaska = dtpVremeDolaska.Value,
                    TipIntervencije = cmbTipIntervencije.SelectedItem.ToString(),
                    AdresaLokacije = txtAdresa.Text,
                    IdDispecera = (int?)cmbDispecer.SelectedValue,
                    IdStatusa = postojecaIntervencija.IdStatusa
                };

                DTOManager.IzmeniIntervenciju(intervencijaDto, statusDto);

                MessageBox.Show("Uspesno ste izmenili podatke o intervenciji.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopuniPodatke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom izmene: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (listViewIntervencije.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite intervenciju koju zelite da obrisete.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)listViewIntervencije.SelectedItems[0].Tag;
            var poruka = MessageBox.Show("Da li ste sigurni da zelite da obrišete izabranu intervenciju?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (poruka == DialogResult.Yes)
            {
                try
                {
                    DTOManager.ObrisiIntervenciju(id);
                    MessageBox.Show("Uspesno ste obrisali intervenciju.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopuniPodatke();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greska prilikom brisanja: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnResursi_Click(object sender, EventArgs e)
        {
            if (listViewIntervencije.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite intervenciju za koju zelite da vidite upotrebljene resurse.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idIntervencije = (int)listViewIntervencije.SelectedItems[0].Tag;
            int brojIntervencije = int.Parse(listViewIntervencije.SelectedItems[0].SubItems[0].Text);

           UpotrebljeniResursiForma resursiForma = new UpotrebljeniResursiForma(idIntervencije, brojIntervencije);
           resursiForma.ShowDialog();
        }
        private void btnAngazovaniVatrogasci_Click(object sender, EventArgs e)
        {
            if (listViewIntervencije.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite intervenciju.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbSmene.SelectedIndex == -1)
            {
                MessageBox.Show("Molimo vas, izaberite i smenu iz koje zelite da angazujete vatrogasce.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int intervencijaId = (int)listViewIntervencije.SelectedItems[0].Tag;
            int brojIntervencije = int.Parse(listViewIntervencije.SelectedItems[0].SubItems[0].Text);
            int smenaId = (int)cmbSmene.SelectedValue; 

            AngazovanVatrogasacForma forma = new AngazovanVatrogasacForma(intervencijaId, smenaId, brojIntervencije);
            forma.ShowDialog();
        }
    }
    
}
