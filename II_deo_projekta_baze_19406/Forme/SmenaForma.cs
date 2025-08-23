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
    public partial class SmenaForma : Form
    {
        public SmenaForma()
        {
            InitializeComponent();
        }
        private int stanicaId;
        public SmenaForma(int stanicaId, string nazivStanice)
        {
            InitializeComponent();
            this.stanicaId = stanicaId;
            this.Text = $"Smene za stanicu: {nazivStanice}";
        }
        private void SmenaForma_Load(object sender, EventArgs e)
        {
            PopuniPodatke();
        }
        public void PopuniPodatke()
        {
            dtpVremePocetka.Format = DateTimePickerFormat.Custom;
            dtpVremePocetka.CustomFormat = "HH:mm";
            dtpVremePocetka.ShowUpDown = true;

            dtpVremeKraja.Format = DateTimePickerFormat.Custom;
            dtpVremeKraja.CustomFormat = "HH:mm";
            dtpVremeKraja.ShowUpDown = true;
            cmbSviRadnici.DataSource = DTOManager.VratiSvaAngazovanaLica();
            cmbSviRadnici.DisplayMember = "ImeIPrezime";
            cmbSviRadnici.ValueMember = "ID";
            cmbSviRadnici.SelectedIndex = -1;
            listViewSmene.Items.Clear();
            List<SmenaPregled> podaci = DTOManager.VratiSveSmeneZaStanicu(this.stanicaId);

            foreach (var p in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { p.Datum.ToShortDateString(), p.VremeRada });
                item.Tag = p.Id;
                listViewSmene.Items.Add(item);
            }

            listViewSmene.Refresh();
            OcistiPolja();
        }
        private void OcistiPolja()
        {
            dtpDatum.Value = DateTime.Now;
            dtpVremePocetka.Value = DateTime.Now;
            dtpVremeKraja.Value = DateTime.Now;
            listViewSmene.SelectedItems.Clear();

            OcistiListeRadnika();
        }
        private void OcistiListeRadnika()
        {
            listViewSviRadnici.Items.Clear();
            listViewVatrogasci.Items.Clear();
            listViewDispeceri.Items.Clear();
        }
        private void PopuniListeRadnika(int smenaId)
        {
            OcistiListeRadnika();

            List<AngazovanoLicePregled> radnici = DTOManager.VratiRadnikeZaSmenu(smenaId);

            foreach (var radnik in radnici)
            {
                string imeIPrezime = $"{radnik.Licno_ime} {radnik.Prezime}";

                ListViewItem itemSvi = new ListViewItem(imeIPrezime);
                itemSvi.Tag = radnik.ID; 
                listViewSviRadnici.Items.Add(itemSvi);

                if (radnik.FVatrogasac == 'T') 
                {
                    ListViewItem itemVatrogasac = new ListViewItem(imeIPrezime);
                    itemVatrogasac.Tag = radnik.ID;
                    listViewVatrogasci.Items.Add(itemVatrogasac);
                }

                if (radnik.FDispecer == 'T')
                {
                    ListViewItem itemDispecer = new ListViewItem(imeIPrezime);
                    itemDispecer.Tag = radnik.ID;
                    listViewDispeceri.Items.Add(itemDispecer);
                }
            }
        }
        private void OcistiListeIntervencija()
        {
            listViewIntervencije.Items.Clear();
            lblUkupno.Text = "Broj intervencija: 0";
        }
        private void PopuniListuIntervencija(int smenaId)
        {
            OcistiListeIntervencija();

            List<IntervencijaPregled> intervencije = DTOManager.VratiIntervencijeZaSmenu(smenaId);
            foreach (var intervencija in intervencije)
            {
                ListViewItem item = new ListViewItem(new string[] { intervencija.BrojIntervencije.ToString(), intervencija.Datum.ToShortDateString(), intervencija.TipIntervencije });
                item.Tag = intervencija.Id;
                listViewIntervencije.Items.Add(item);
            }
            lblUkupno.Text = $"Broj ukupnih intervencija: {listViewIntervencije.Items.Count}";
        }
        private void listViewSmene_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSmene.SelectedItems.Count == 0)
            {
                btnDodajRadnika.Enabled = false;
                btnUkloniIzSvih.Enabled = false;
                btnUkloniVatrogasca.Enabled = false;
                btnUkloniDispecera.Enabled = false;
                OcistiPolja();
                return;
            }
            btnDodajRadnika.Enabled = true;
            btnUkloniIzSvih.Enabled = true;
            btnUkloniVatrogasca.Enabled = true;
            btnUkloniDispecera.Enabled = true;

            int idSmene = (int)listViewSmene.SelectedItems[0].Tag;
            SmenaBasic s = DTOManager.VratiSmenu(idSmene);

            if (s != null)
            {
                dtpDatum.Value = s.Datum;
                dtpVremePocetka.Value = s.VremePocetka;
                dtpVremeKraja.Value = s.VremeKraja;
                PopuniListeRadnika(idSmene);
                PopuniListuIntervencija(idSmene);
            }
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                SmenaBasic novaSmena = new SmenaBasic
                {
                    Datum = dtpDatum.Value.Date,
                    VremePocetka = dtpVremePocetka.Value,
                    VremeKraja = dtpVremeKraja.Value,
                    IdStanice = this.stanicaId
                };

                DTOManager.SacuvajSmenu(novaSmena);
                MessageBox.Show("Uspesno ste dodali novu smenu.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopuniPodatke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja smene: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (listViewSmene.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite smenu koju želite da izmenite.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int idSmene = (int)listViewSmene.SelectedItems[0].Tag;
                SmenaBasic smenaZaIzmenu = new SmenaBasic
                {
                    Id = idSmene,
                    Datum = dtpDatum.Value.Date,
                    VremePocetka = dtpVremePocetka.Value,
                    VremeKraja = dtpVremeKraja.Value,
                    IdStanice = this.stanicaId
                };

                DTOManager.IzmeniSmenu(smenaZaIzmenu);
                MessageBox.Show("Uspesno ste izmenili smenu.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopuniPodatke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom izmene smene: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (listViewSmene.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite smenu koju želite da obrišete.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int idSmene = (int)listViewSmene.SelectedItems[0].Tag;
                var poruka = MessageBox.Show("Da li ste sigurni da želite da obrišete izabranu smenu?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (poruka == DialogResult.Yes)
                {
                    DTOManager.ObrisiSmenu(idSmene);
                    MessageBox.Show("Uspesno ste obrisali smenu.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopuniPodatke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom brisanja smene: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDodajRadnika_Click(object sender, EventArgs e)
        {
            if (listViewSmene.SelectedItems.Count == 0 || cmbSviRadnici.SelectedIndex == -1)
            {
                MessageBox.Show("Morate prvo izabrati smenu i radnika kojeg zelite da dodate.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int smenaId = (int)listViewSmene.SelectedItems[0].Tag;
            int radnikId = (int)cmbSviRadnici.SelectedValue;

            DTOManager.DodajRadnikaUSmenu(smenaId, radnikId);
            PopuniListeRadnika(smenaId);
        }
        private void UkloniRadnika(ListView listView)
        {
            if (listViewSmene.SelectedItems.Count == 0 || listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate izabrati smenu i radnika iz liste kojeg zelite da uklonite.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int smenaId = (int)listViewSmene.SelectedItems[0].Tag;
            int radnikId = (int)listView.SelectedItems[0].Tag;

            DTOManager.UkloniRadnikaIzSmene(smenaId, radnikId);
            PopuniListeRadnika(smenaId);
        }
        private void btnUkloniIzSvih_Click(object sender, EventArgs e)
        {
            UkloniRadnika(listViewSviRadnici);
        }
        private void btnUkloniVatrogasca_Click(object sender, EventArgs e)
        {
            UkloniRadnika(listViewVatrogasci);
        }
        private void btnUkloniDispecera_Click(object sender, EventArgs e)
        {
            UkloniRadnika(listViewDispeceri);
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
