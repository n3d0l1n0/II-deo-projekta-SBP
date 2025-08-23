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
    public partial class AngazovanVatrogasacForma : Form
    {
        private int intervencijaId;
        private int smenaId; 
        public AngazovanVatrogasacForma(int intervencijaId, int smenaId, int brojIntervencije)
        {
            InitializeComponent();
            this.intervencijaId = intervencijaId;
            this.smenaId = smenaId;
            this.Text = $"Angazovani vatrogasci na intervenciji br. {brojIntervencije}";
        }
        public AngazovanVatrogasacForma()
        {
            InitializeComponent();
        }
        private void AngazovanVatrogasacForma_Load(object sender, EventArgs e)
        {
            PopuniPodatke();
        }
        public void PopuniPodatke()
        {
            var vatrogasciUSmeni = DTOManager.VratiRadnikeZaSmenu(this.smenaId)
                                             .Where(r => r.FVatrogasac == 'T')
                                             .Select(r => new VatrogasacPregled(r.ID, r.Licno_ime, r.Prezime))
                                             .ToList();

            cmbVatrogasci.DataSource = vatrogasciUSmeni;
            cmbVatrogasci.DisplayMember = "ImeIPrezime";
            cmbVatrogasci.ValueMember = "Id";
            cmbVatrogasci.SelectedIndex = -1;

            listViewAngazovani.Items.Clear();
            List<AngazovanVatrogasacPregled> podaci = DTOManager.VratiAngazovanjaZaIntervenciju(this.intervencijaId);

            foreach (var p in podaci)
            {
                ListViewItem item = new ListViewItem(p.VatrogasacInfo);
                item.Tag = p.ID; 
                listViewAngazovani.Items.Add(item);
            }

            int ukupno = listViewAngazovani.Items.Count;
            lblUkupno.Text = $"Ukupno angazovano: {ukupno}";

            listViewAngazovani.Refresh();
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (cmbVatrogasci.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati vatrogasca iz liste.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int idZaDodavanje = (int)cmbVatrogasci.SelectedValue;
                var postojeci = DTOManager.VratiAngazovanjaZaIntervenciju(this.intervencijaId);
                if (postojeci.Any(p => p.VatrogasacInfo == cmbVatrogasci.Text))
                {
                    MessageBox.Show("Ovaj vatrogasac je vec dodat na intervenciju.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int idVatrogasca = (int)cmbVatrogasci.SelectedValue;

                AngazovanVatrogasacBasic noviAngazman = new AngazovanVatrogasacBasic
                {
                    IdIntervencije = this.intervencijaId,
                    IdVatrogasca = idVatrogasca,
                    IdSmene = this.smenaId
                };

                DTOManager.DodajVatrogascaNaIntervenciju(noviAngazman);
                MessageBox.Show("Uspešno ste dodali izabrano lice.", "Dodavanje uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopuniPodatke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja vatrogasca: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (listViewAngazovani.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite osobu koju zelite da uklonite.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int idVatrogasca = (int)listViewAngazovani.SelectedItems[0].Tag;
                var poruka = MessageBox.Show("Da li ste sigurni da zelite da uklonite ovog vatrogasca sa intervencije?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (poruka == DialogResult.Yes)
                {
                    DTOManager.UkloniVatrogascaSaIntervencije(idVatrogasca);
                    MessageBox.Show("Uspesno ste obrisali izabrano lice.", "Brisanje uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopuniPodatke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom brisanja vatrogasca: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
