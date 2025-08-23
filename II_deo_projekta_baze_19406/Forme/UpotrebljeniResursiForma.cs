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
    public partial class UpotrebljeniResursiForma : Form
    {
        public UpotrebljeniResursiForma()
        {
            InitializeComponent();
        }
        private int intervencijaId;

        public UpotrebljeniResursiForma(int intervencijaId, int brojIntervencije)
        {
            InitializeComponent();
            this.intervencijaId = intervencijaId;
            this.Text = $"Resursi za intervenciju br. {brojIntervencije}";
            this.cmbOprema.Format += new ListControlConvertEventHandler(cmbOprema_Format);
        }
        private void UpotrebljeniResursiForma_Load(object sender, EventArgs e)
        {
            PopuniPodatke();
        }
        public void PopuniPodatke()
        {
            cmbVozila.DataSource = DTOManager.VratiSvaVozilaZaListu();
            cmbVozila.DisplayMember = "RegistarskaOznaka";
            cmbVozila.ValueMember = "Id";
            cmbVozila.SelectedIndex = -1;
            cmbOprema.DataSource = DTOManager.VratiSvuOpremu();
            cmbOprema.DisplayMember = "InventarskiBroj";
            cmbOprema.ValueMember = "Id";
            cmbOprema.SelectedIndex = -1;

            listViewResursi.Items.Clear();
            List<UpotrebljenoUIntervencijiPregled> podaci = DTOManager.VratiUpotrebljeneResurse(this.intervencijaId);
            foreach (var p in podaci)
            {
                string tip = (p.VoziloInfo != "---") ? "Vozilo" : "Oprema";
                string identifikator = (p.VoziloInfo != "---") ? p.VoziloInfo : p.OpremaInfo;
                ListViewItem item = new ListViewItem(new string[] { tip, identifikator });
                item.Tag = p.ID;
                listViewResursi.Items.Add(item);
            }
            listViewResursi.Refresh();
        }
        private void btnDodajVozilo_Click(object sender, EventArgs e)
        {
            if (cmbVozila.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati vozilo iz liste.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                UpotrebljenoUIntervencijiBasic noviResurs = new UpotrebljenoUIntervencijiBasic
                {
                    IdIntervencije = this.intervencijaId,
                    IdVozila = (int)cmbVozila.SelectedValue
                };

                DTOManager.DodajResursNaIntervenciju(noviResurs);
                PopuniPodatke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja vozila: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDodajOpremu_Click(object sender, EventArgs e)
        {
            if (cmbOprema.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati opremu iz liste.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                UpotrebljenoUIntervencijiBasic noviResurs = new UpotrebljenoUIntervencijiBasic
                {
                    IdIntervencije = this.intervencijaId,
                    IdOpreme = (int)cmbOprema.SelectedValue
                };

                DTOManager.DodajResursNaIntervenciju(noviResurs);
                PopuniPodatke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja opreme: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUkloniResurs_Click(object sender, EventArgs e)
        {
            if (listViewResursi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite resurs koji želite da uklonite.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int idUpotrebe = (int)listViewResursi.SelectedItems[0].Tag;
                var poruka = MessageBox.Show("Da li ste sigurni da želite da uklonite ovaj resurs sa intervencije?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (poruka == DialogResult.Yes)
                {
                    DTOManager.UkloniResursSaIntervencije(idUpotrebe);
                    PopuniPodatke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom brisanja resursa: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbOprema_Format(object sender, ListControlConvertEventArgs e)
        {
            OpremaPregled oprema = e.ListItem as OpremaPregled;
            if (oprema != null)
            {
                e.Value = $"{oprema.InventarskiBroj} ({oprema.StatusOpreme})";
            }
        }
    }
}
