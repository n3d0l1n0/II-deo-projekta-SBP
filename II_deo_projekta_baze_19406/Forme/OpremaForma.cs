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
    public partial class OpremaForma : Form
    {
        public OpremaForma()
        {
            InitializeComponent();
            this.UcitajLokacije();
            this.UcitajTehnicare();
            AzurirajStanjeTipovaOpreme(null);

        }
        private void UcitajTehnicare()
        {
            cmbTehnicari.DataSource = DTOManager.VratiSveTehnicare();
            cmbTehnicari.DisplayMember = "ImeIPrezime";
            cmbTehnicari.ValueMember = "Id";
            cmbTehnicari.SelectedIndex = -1;
        }
        private void UcitajLokacije()
        {
            cmbLokacijaStanica.DataSource = DTOManager.VratiSveStaniceZaListu();
            cmbLokacijaStanica.DisplayMember = "Naziv"; 
            cmbLokacijaStanica.ValueMember = "Id";      

            cmbLokacijaVozilo.DataSource = DTOManager.VratiSvaVozilaZaListu();
            cmbLokacijaVozilo.DisplayMember = "RegistarskaOznaka"; 
            cmbLokacijaVozilo.ValueMember = "Id";               

            cmbLokacijaStanica.SelectedIndex = -1;
            cmbLokacijaVozilo.SelectedIndex = -1;
        }
        private void AzurirajStanjeTipovaOpreme(CheckBox aktivniCheckbox)
        {
            if (aktivniCheckbox != chbZastitna) chbZastitna.Checked = false;
            if (aktivniCheckbox != chbZaPozare) chbZaPozare.Checked = false;
            if (aktivniCheckbox != chbSpecijalna) chbSpecijalna.Checked = false;
            if (aktivniCheckbox != chbTehnicka) chbTehnicka.Checked = false;

            cmbTipZastitna.Enabled = (aktivniCheckbox == chbZastitna);
            if (!cmbTipZastitna.Enabled) cmbTipZastitna.SelectedIndex = -1; 

            cmbTipZaPozare.Enabled = (aktivniCheckbox == chbZaPozare);
            if (!cmbTipZaPozare.Enabled) cmbTipZaPozare.SelectedIndex = -1;

            cmbTipSpecijalna.Enabled = (aktivniCheckbox == chbSpecijalna);
            if (!cmbTipSpecijalna.Enabled) cmbTipSpecijalna.SelectedIndex = -1;

            cmbTipTehnicka.Enabled = (aktivniCheckbox == chbTehnicka);
            if (!cmbTipTehnicka.Enabled) cmbTipTehnicka.SelectedIndex = -1;
        }
        private void OcistiPoljaZaUnos()
        {
            txtInventarskiBroj.Text = string.Empty;
            dtpDatumNabavke.Value = DateTime.Now;
            cmbStatus.SelectedIndex = 0;
            txtZaduzenoLice.Text = string.Empty;

            chbZastitna.Checked = false;
            chbZaPozare.Checked = false;
            chbSpecijalna.Checked = false;
            chbTehnicka.Checked = false;
            cmbTehnicari.SelectedIndex = -1;

            AzurirajStanjeTipovaOpreme(null);

            listViewOprema.SelectedItems.Clear();
            listViewIntervencija.Items.Clear();
        }
        private void UcitajSvuOpremu()
        {
            listViewOprema.Items.Clear();
            List<OpremaPregled> oprema = DTOManager.VratiSvuOpremu();

            foreach (OpremaPregled o in oprema)
            {
                ListViewItem item = new ListViewItem(new string[] 
                { 
                    o.Id.ToString(), 
                    o.InventarskiBroj, 
                    o.StatusOpreme, 
                    o.Lokacija,
                });
                item.Tag = o;
                listViewOprema.Items.Add(item);
            }
            listViewOprema.Refresh();
        }
        private void PopuniPoljaZaIzmenu(int id)
        {
            OpremaBasic oprema = DTOManager.VratiOpremu(id);

            txtInventarskiBroj.Text = oprema.InventarskiBroj;
            dtpDatumNabavke.Value = oprema.DatumNabavke;
            cmbStatus.SelectedItem = oprema.StatusOpreme;

            chbZastitna.Checked = (oprema.FZastitna == 'T');
            cmbTipZastitna.SelectedItem = oprema.TipZastitna; 
            chbZaPozare.Checked = (oprema.FZaPozare == 'T');
            cmbTipZaPozare.SelectedItem = oprema.TipZaPozare;
            chbSpecijalna.Checked = (oprema.FSpecijalna == 'T');
            cmbTipSpecijalna.SelectedItem = oprema.TipSpecijalna;
            chbTehnicka.Checked = (oprema.FTehnicka == 'T');
            cmbTipTehnicka.SelectedItem = oprema.TipTehnicka;

            if (chbZastitna.Checked) AzurirajStanjeTipovaOpreme(chbZastitna);
            else if (chbZaPozare.Checked) AzurirajStanjeTipovaOpreme(chbZaPozare);
            else if (chbSpecijalna.Checked) AzurirajStanjeTipovaOpreme(chbSpecijalna);
            else if (chbTehnicka.Checked) AzurirajStanjeTipovaOpreme(chbTehnicka);
            else AzurirajStanjeTipovaOpreme(null);

            if (oprema.IdStanice.HasValue)
            {
                cmbLokacijaStanica.SelectedValue = oprema.IdStanice.Value;
                cmbLokacijaVozilo.SelectedIndex = -1; 
            }
            else if (oprema.IdVozila.HasValue)
            {
                cmbLokacijaVozilo.SelectedValue = oprema.IdVozila.Value;
                cmbLokacijaStanica.SelectedIndex = -1; 
            }
            else
            {
                cmbLokacijaStanica.SelectedIndex = -1;
                cmbLokacijaVozilo.SelectedIndex = -1;
            }
            txtZaduzenoLice.Text = oprema.ZaduzenoLicePrikaz;
        }
        private void listViewOprema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOprema.SelectedItems.Count > 0)
            {
                OpremaPregled selektovanaOprema = (OpremaPregled)listViewOprema.SelectedItems[0].Tag;
                OpremaBasic opremaZaIzmenu = DTOManager.VratiOpremu(selektovanaOprema.Id);
                PopuniPoljaZaIzmenu(selektovanaOprema.Id);
                this.PopuniIntervencijeZaOpremu(selektovanaOprema.Id);

                if (opremaZaIzmenu.IdLica.HasValue)
                {
                    cmbTehnicari.SelectedValue = opremaZaIzmenu.IdLica.Value;
                }
                else
                {
                    cmbTehnicari.SelectedIndex = -1;
                }
            }
            else 
            {
                OcistiPoljaZaUnos();
            }
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInventarskiBroj.Text))
            {
                MessageBox.Show("Inventarski broj i Naziv ne mogu biti prazni.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbLokacijaStanica.SelectedIndex == -1 && cmbLokacijaVozilo.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati lokaciju opreme (ili stanicu ili vozilo).", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati status opreme.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            if (chbZastitna.Checked && cmbTipZastitna.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati tip zastitne opreme sa liste.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (chbZaPozare.Checked && cmbTipZaPozare.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati tip opreme za pozare sa liste.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (chbSpecijalna.Checked && cmbTipSpecijalna.SelectedIndex==-1)
            {
                MessageBox.Show("Morate uneti tip specijalne opreme sa liste.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (chbTehnicka.Checked && cmbTipTehnicka.SelectedIndex==-1)
            {
                MessageBox.Show("Morate uneti tip tehnicke opreme sa liste.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!chbZastitna.Checked && !chbZaPozare.Checked && !chbSpecijalna.Checked && !chbTehnicka.Checked)
            {
                MessageBox.Show("Morate izabrati bar jedan tip opreme (zastitna, za pozare, specijalna ili tehnicka).", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((chbZastitna.Checked && cmbTipZastitna.SelectedIndex == -1) ||
                (chbZaPozare.Checked && cmbTipZaPozare.SelectedIndex == -1) ||
                (chbSpecijalna.Checked && cmbTipSpecijalna.SelectedIndex == -1) ||
                (chbTehnicka.Checked && cmbTipTehnicka.SelectedIndex == -1))
            {
                MessageBox.Show("Morate odabrati specificnu vrstu opreme sa liste.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DTOManager.DaLiPostojiOprema(txtInventarskiBroj.Text))
            {
                MessageBox.Show("Oprema sa unetim inventarskim brojem vec postoji.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                OpremaBasic oprema = new OpremaBasic
                {
                    InventarskiBroj = txtInventarskiBroj.Text,
                    DatumNabavke = dtpDatumNabavke.Value,
                    StatusOpreme = cmbStatus.SelectedItem.ToString(),


                    FZastitna = chbZastitna.Checked ? 'T' : (char?)null,
                    TipZastitna = chbZastitna.Checked ? cmbTipZastitna.SelectedItem.ToString() : null,

                    FZaPozare = chbZaPozare.Checked ? 'T' : (char?)null,
                    TipZaPozare = chbZaPozare.Checked ? cmbTipZaPozare.SelectedItem.ToString() : null,

                    FSpecijalna = chbSpecijalna.Checked ? 'T' : (char?)null,
                    TipSpecijalna = chbSpecijalna.Checked ? cmbTipSpecijalna.SelectedItem.ToString() : null,

                    FTehnicka = chbTehnicka.Checked ? 'T' : (char?)null,
                    TipTehnicka = chbTehnicka.Checked ? cmbTipTehnicka.SelectedItem.ToString() : null
                };
                if (cmbLokacijaStanica.SelectedValue != null)
                {
                    oprema.IdStanice = (int)cmbLokacijaStanica.SelectedValue;
                    oprema.IdVozila = null; 
                }
                else if (cmbLokacijaVozilo.SelectedValue != null)
                {
                    oprema.IdVozila = (int)cmbLokacijaVozilo.SelectedValue;
                    oprema.IdStanice = null; 
                }
                DTOManager.SacuvajOpremu(oprema);
                MessageBox.Show("Uspesno ste dodali novu opremu!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.UcitajSvuOpremu();
                OcistiPoljaZaUnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja opreme: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (listViewOprema.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite opremu koju zelite da izmenite.");
                return;
            }
      
            if (!chbZastitna.Checked && !chbZaPozare.Checked && !chbSpecijalna.Checked && !chbTehnicka.Checked)
            {
                MessageBox.Show("Morate izabrati bar jedan tip opreme (zastitna, za pozare, specijalna ili tehnicka).", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((chbZastitna.Checked && cmbTipZastitna.SelectedIndex == -1) ||
                (chbZaPozare.Checked && cmbTipZaPozare.SelectedIndex == -1) ||
                (chbSpecijalna.Checked && cmbTipSpecijalna.SelectedIndex == -1) ||
                (chbTehnicka.Checked && cmbTipTehnicka.SelectedIndex == -1))
            {
                MessageBox.Show("Ako je tip opreme izabran, morate odabrati i specificnu vrednost sa liste.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int idOpreme = ((OpremaPregled)listViewOprema.SelectedItems[0].Tag).Id;

                OpremaBasic oprema = new OpremaBasic
                {
                    Id = idOpreme,
                    InventarskiBroj = txtInventarskiBroj.Text,
                    DatumNabavke = dtpDatumNabavke.Value,
                    StatusOpreme = cmbStatus.SelectedItem.ToString(),

                    FZastitna = chbZastitna.Checked ? 'T' : (char?)null,
                    TipZastitna = chbZastitna.Checked ? cmbTipZastitna.SelectedItem.ToString() : null,

                    FZaPozare = chbZaPozare.Checked ? 'T' : (char?)null,
                    TipZaPozare = chbZaPozare.Checked ? cmbTipZaPozare.SelectedItem.ToString() : null,

                    FSpecijalna = chbSpecijalna.Checked ? 'T' : (char?)null,
                    TipSpecijalna = chbSpecijalna.Checked ? cmbTipSpecijalna.SelectedItem.ToString() : null,

                    FTehnicka = chbTehnicka.Checked ? 'T' : (char?)null,
                    TipTehnicka = chbTehnicka.Checked ? cmbTipTehnicka.SelectedItem.ToString() : null
                };
                if (cmbLokacijaStanica.SelectedValue != null)
                {
                    oprema.IdStanice = (int)cmbLokacijaStanica.SelectedValue;
                    oprema.IdVozila = null;
                }
                else if (cmbLokacijaVozilo.SelectedValue != null)
                {
                    oprema.IdVozila = (int)cmbLokacijaVozilo.SelectedValue;
                    oprema.IdStanice = null;
                }
                DTOManager.IzmeniOpremu(oprema);
                MessageBox.Show("Uspesno ste izmenili podatke o opremi!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.UcitajSvuOpremu();
                OcistiPoljaZaUnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom izmene opreme: {ex.Message}");
            }
        }
        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (listViewOprema.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite opremu koju zelite da obrisete.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Da li ste sigurni da zelite da obrisete izabranu opremu?",
                                                   "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int idOpreme = ((OpremaPregled)listViewOprema.SelectedItems[0].Tag).Id;
                    DTOManager.ObrisiOpremu(idOpreme);
                    MessageBox.Show("Uspesno ste obrisali opremu!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.UcitajSvuOpremu(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greska prilikom brisanja opreme: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void chbZastitna_CheckedChanged(object sender, EventArgs e)
        {
            if (chbZastitna.Checked) AzurirajStanjeTipovaOpreme(chbZastitna);
        }
        private void chbZaPozare_CheckedChanged(object sender, EventArgs e)
        {
            if (chbZaPozare.Checked) AzurirajStanjeTipovaOpreme(chbZaPozare);
        }
        private void chbSpecijalna_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSpecijalna.Checked) AzurirajStanjeTipovaOpreme(chbSpecijalna);
        }
        private void chbTehnicka_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTehnicka.Checked) AzurirajStanjeTipovaOpreme(chbTehnicka);
        }
        private void cmbLokacijaStanica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLokacijaStanica.Focused && cmbLokacijaStanica.SelectedIndex != -1)
            {
                cmbLokacijaVozilo.SelectedIndex = -1;
            }
        }
        private void cmbLokacijaVozilo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLokacijaVozilo.Focused && cmbLokacijaVozilo.SelectedIndex != -1)
            {
                cmbLokacijaStanica.SelectedIndex = -1;
            }
        }
        private void PopuniIntervencijeZaOpremu(int idOpreme)
        {
            listViewIntervencija.Items.Clear();
            List<UpotrebaIntervencijePregled> upotrebe = DTOManager.VratiUpotrebuZaOpremu(idOpreme);

            foreach (var u in upotrebe)
            {
                ListViewItem item = new ListViewItem(new string[] { u.IdIntervencije.ToString(), u.TipIntervencije, u.DatumIntervencije.ToString()});
                listViewIntervencija.Items.Add(item);
            }
            listViewIntervencija.Refresh();
        }
        private void OpremaForma_Load(object sender, EventArgs e)
        {
            this.UcitajSvuOpremu();
            this.UcitajTehnicare();
        }
        private void btnZaduzi_Click(object sender, EventArgs e)
        {

            if (listViewOprema.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite opremu koju zelite da zaduzite.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbTehnicari.SelectedIndex == -1)
            {
                MessageBox.Show("Molimo vas, izaberite lice kojem zaduzujete opremu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idOpreme = ((OpremaPregled)listViewOprema.SelectedItems[0].Tag).Id;
                int idTehnicara = (int)cmbTehnicari.SelectedValue;

                DTOManager.ZaduziOpremuTehnicaru(idOpreme, idTehnicara);
                MessageBox.Show("Oprema je uspesno zaduzena.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtZaduzenoLice.Text = cmbTehnicari.Text;
                UcitajSvuOpremu(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom zaduzivanja opreme: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRazduzi_Click(object sender, EventArgs e)
        {
            if (listViewOprema.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite opremu koju zelite da razduzite.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idOpreme = ((OpremaPregled)listViewOprema.SelectedItems[0].Tag).Id;

                DTOManager.RazduziOpremu(idOpreme);
                MessageBox.Show("Oprema je uspesno razduzena.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtZaduzenoLice.Text = "Nije zaduzeno";
                cmbTehnicari.SelectedIndex = -1;
                UcitajSvuOpremu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom razduzivanja opreme: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
