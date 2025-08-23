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
    public partial class TehnicarOdrzavaVoziloForma : Form
    {
        public TehnicarOdrzavaVoziloForma()
        {
            InitializeComponent();
        }
        private int voziloId;

        public TehnicarOdrzavaVoziloForma(int voziloId, string registarskaOznaka)
        {
            InitializeComponent();
            this.voziloId = voziloId;
            this.Text = $"Zaduzeni tehnicari za vozilo: {registarskaOznaka}";
        }
        private void TehnicarOdrzavaVoziloForma_Load(object sender, EventArgs e)
        {
            PopuniListe();
        }
        private void PopuniListe()
        {
            listViewDostupni.Items.Clear();
            listViewZaduzeni.Items.Clear();

            List<AngazovanoLicePregled> zaduzeni = DTOManager.VratiSveTehnicareZaVozilo(this.voziloId);
            List<AngazovanoLicePregled> svi = DTOManager.VratiSvaAngazovanaLica().Where(p => p.FTehnicar == 'T').ToList();

            List<int> zaduzeniIds = zaduzeni.Select(z => z.ID).ToList();

            foreach (var tehnicar in zaduzeni)
            {
                ListViewItem item = new ListViewItem($"{tehnicar.Licno_ime} {tehnicar.Prezime}");
                item.Tag = tehnicar.ID;
                listViewZaduzeni.Items.Add(item);
            }

            foreach (var tehnicar in svi)
            {
                if (!zaduzeniIds.Contains(tehnicar.ID))
                {
                    ListViewItem item = new ListViewItem($"{tehnicar.Licno_ime} {tehnicar.Prezime}");
                    item.Tag = tehnicar.ID;
                    listViewDostupni.Items.Add(item);
                }
            }
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewDostupni.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = listViewDostupni.SelectedItems[0];
                    listViewDostupni.Items.Remove(selectedItem);
                    listViewZaduzeni.Items.Add(selectedItem);
                    MessageBox.Show("Uspesno ste dodali novog tehnicara", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnObrisi_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewZaduzeni.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = listViewZaduzeni.SelectedItems[0];
                    listViewZaduzeni.Items.Remove(selectedItem);
                    listViewDostupni.Items.Add(selectedItem);
                    MessageBox.Show("Uspesno ste obrisali tehnicara", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja izmene: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> idjeviZaduzenih = new List<int>();
                foreach (ListViewItem item in listViewZaduzeni.Items)
                {
                    idjeviZaduzenih.Add((int)item.Tag);
                }

                DTOManager.AzurirajTehnicareZaVozilo(this.voziloId, idjeviZaduzenih);

                MessageBox.Show("Uspesno ste sacuvali izmene!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom cuvanja: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
