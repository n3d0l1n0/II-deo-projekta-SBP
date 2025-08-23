using II_deo_projekta_baze_19406.Entiteti;
using NHibernate.Hql.Ast;
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
    public partial class AngazovanoLiceForma : Form
    {
        private List<AngazovanoLiceDetaljiPregled> svaLicaPamti;
        private List<VolonterDetaljiPregled> sviVolonteriPamti;

        public AngazovanoLiceForma()
        {
            InitializeComponent();
        }

        private void AngazovanoLiceForma_Load(object sender, EventArgs e)
        {
            PopuniPodatke();
        }
        public void PopuniPodatke()
        {
            cmbPol.Items.Clear();
            cmbPol.Items.AddRange(new string[] { "M", "Z" });
            cmbPol.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbNivoObucenosti.Items.Clear();
            cmbNivoObucenosti.Items.AddRange(new string[] { "Osnovni", "Srednji", "Specijalni" });
            cmbNivoObucenosti.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbStanica.DataSource = DTOManager.VratiSveStaniceZaListu(); 
            cmbStanica.DisplayMember = "Naziv";
            cmbStanica.ValueMember = "Id";

            cmbVoziloVolontera.DataSource = DTOManager.VratiSvaVozilaZaListu();
            cmbVoziloVolontera.DisplayMember = "RegistarskaOznaka";
            cmbVoziloVolontera.ValueMember = "Id";

            cmbSpecijalizacija.Items.Clear();
            cmbSpecijalizacija.Items.AddRange(new string[] { "Mehanicka", "Zastitna oprema", "Elektronska", "Drugo" });
            cmbSpecijalizacija.DropDownStyle = ComboBoxStyle.DropDownList;

            svaLicaPamti = DTOManager.VratiSvaLicaDetaljno();
            sviVolonteriPamti = DTOManager.VratiSveVolontereDetaljno();
            PopuniListeLica();
            tabPrikazLica_SelectedIndexChanged(null, null);
            OcistiPolja();
        }
        private void PopuniListeLica()
        {
            listViewVatrogasci.Items.Clear();
            listViewDispeceri.Items.Clear();
            listViewTehnicari.Items.Clear();
            listViewVolonteri.Items.Clear();

            if (svaLicaPamti != null)
            {
                foreach (var lice in svaLicaPamti)
                {
                    ListViewItem itemStandard = new ListViewItem(lice.ID.ToString());
                    itemStandard.SubItems.Add(lice.MaticniBroj);
                    itemStandard.SubItems.Add(lice.Ime);
                    itemStandard.SubItems.Add(lice.Prezime);
                    itemStandard.SubItems.Add(lice.DatumRodjenja.ToShortDateString());
                    itemStandard.SubItems.Add(lice.Pol.ToString());
                    itemStandard.SubItems.Add(lice.Adresa);
                    itemStandard.SubItems.Add(lice.Email);
                    itemStandard.SubItems.Add(lice.DatumAngazovanja?.ToShortDateString() ?? "------");
                    itemStandard.SubItems.Add(lice.NazivStanice);
                    itemStandard.Tag = lice.ID;

                    if (lice.FTehnicar == 'T')
                    {
                        ListViewItem itemTehnicar = (ListViewItem)itemStandard.Clone();
                        itemTehnicar.SubItems.Add(lice.Specijalizacija ?? "------");
                        itemTehnicar.SubItems.Add(lice.PodaciOAlatima ?? "------");
                        listViewTehnicari.Items.Add(itemTehnicar);
                    }

                    if (lice.FDispecer == 'T')
                    {
                        ListViewItem itemDispecer = (ListViewItem)itemStandard.Clone();
                        itemDispecer.SubItems.Add(lice.EvidencijaPoziva ?? "------");
                        itemDispecer.SubItems.Add(lice.TipOpreme ?? "------");
                        listViewDispeceri.Items.Add(itemDispecer);
                    }
                    if (lice.FVatrogasac == 'T')
                    {
                        ListViewItem itemVatrogasac = (ListViewItem)itemStandard.Clone();
                        itemVatrogasac.SubItems.Add(lice.BrojOperativnihIntervencija?.ToString() ?? "0");
                        itemVatrogasac.SubItems.Add(lice.NivoObucenosti ?? "---");
                        itemVatrogasac.SubItems.Add(lice.StepenFizickeSpremnosti ?? "---");
                        itemVatrogasac.SubItems.Add(lice.BrojSertifikata?.ToString() ?? "0");
                        listViewVatrogasci.Items.Add(itemVatrogasac);
                    }
                }
            }

            if (sviVolonteriPamti != null)
            {
                foreach (var volonter in sviVolonteriPamti)
                {
                    ListViewItem item = new ListViewItem(volonter.Id.ToString());
                    item.SubItems.Add(volonter.MaticniBroj);
                    item.SubItems.Add(volonter.LicnoIme);
                    item.SubItems.Add(volonter.Prezime);
                    item.SubItems.Add(volonter.DatumRodjenja.ToShortDateString());
                    item.SubItems.Add(volonter.Pol.ToString());
                    item.SubItems.Add(volonter.AdresaStanovanja);
                    item.SubItems.Add(volonter.EmailAdresa);
                    item.SubItems.Add(volonter.RegistarskaOznaka); 
                    item.SubItems.Add(volonter.ProizvodjacVozila); 
                    item.SubItems.Add(volonter.TipVozila); item.Tag = volonter.Id;
                    listViewVolonteri.Items.Add(item);
                }
            }
        }
        private void OcistiPolja()
        {
            txtMaticniBroj.Text = string.Empty;
            txtIme.Text = string.Empty;
            txtPrezime.Text = string.Empty;
            txtAdresa.Text = string.Empty;
            txtEmail.Text = string.Empty;
            dtpDatumRodjenja.Value = DateTime.Now;
            dtpDatumAngazovanja.Value = DateTime.Now;
            dtpDatumAngazovanja.Checked = false; 
            cmbPol.SelectedIndex = -1;
            cmbStanica.SelectedIndex = -1;

            cmbVoziloVolontera.SelectedIndex = -1;

            chbVatrogasac.Checked = false;
            chbDispecer.Checked = false;
            chbTehnicar.Checked = false;

            numSertifikat.Value = 0;
            numIntervencije.Value = 0;
            txtStepenSpremnosti.Text = string.Empty;
            cmbNivoObucenosti.SelectedIndex = -1;
            txtEvidencijaPoziva.Text = string.Empty;
            txtTipOpreme.Text = string.Empty;
            txtAlati.Text = string.Empty;
            cmbSpecijalizacija.SelectedIndex = -1;

            listViewVatrogasci.SelectedItems.Clear();
            listViewDispeceri.SelectedItems.Clear();
            listViewTehnicari.SelectedItems.Clear();
            listViewVolonteri.SelectedItems.Clear();

        }
        private void PrikaziPaneleNaOsnovuUloge()
        {
            if (tabPrikazLica.SelectedTab != tabVolonteri)
            {
                gbVatrogasac.Visible = chbVatrogasac.Checked;
                gbDispeceri.Visible = chbDispecer.Checked;
                gbTehnicar.Visible = chbTehnicar.Checked;
            }
        }
        private void chbVatrogasac_CheckedChanged(object sender, EventArgs e)
        {
            PrikaziPaneleNaOsnovuUloge();
        }
        private void chbDispecer_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDispecer.Checked)
            {
                if (chbTehnicar.Checked)
                {
                    chbTehnicar.Checked = false;
                }
            }

            PrikaziPaneleNaOsnovuUloge();
        }
        private void chbTehnicar_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTehnicar.Checked)
            {
                if (chbDispecer.Checked)
                {
                    chbDispecer.Checked = false;
                }
            }
            PrikaziPaneleNaOsnovuUloge();
        }
        private void SelektovanoLice(object sender, EventArgs e)
        {
            ListView aktivnaLista = sender as ListView;
            if (aktivnaLista == null || aktivnaLista.SelectedItems.Count == 0)
            {
                OcistiPolja();
                return;
            }

            int id = (int)aktivnaLista.SelectedItems[0].Tag;

            if (aktivnaLista == listViewVolonteri)
            {
                VolonterBasic volonter = DTOManager.VratiVolontera(id);
                if (volonter != null)
                {
                    txtMaticniBroj.Text = volonter.MaticniBroj;
                    txtIme.Text = volonter.LicnoIme;
                    txtPrezime.Text = volonter.Prezime;
                    txtAdresa.Text = volonter.AdresaStanovanja;
                    txtEmail.Text = volonter.EmailAdresa;
                    dtpDatumRodjenja.Value = volonter.DatumRodjenja;
                    cmbPol.SelectedItem = volonter.Pol.ToString();
                    cmbVoziloVolontera.SelectedValue = volonter.IdVozila ?? -1;
                }
            }
            else
            {
                AngazovanoLiceBasic lice = DTOManager.VratiAngazovanoLice(id);
                if (lice != null)
                {
                    txtMaticniBroj.Text = lice.Maticni_broj;
                    txtIme.Text = lice.Licno_ime;
                    txtPrezime.Text = lice.Prezime;
                    txtAdresa.Text = lice.Adresa_stanovanja;
                    txtEmail.Text = lice.Email_adresa;
                    dtpDatumRodjenja.Value = lice.Datum_rodjenja;
                    if (lice.Datum_pocetka_angazovanja.HasValue)
                    {
                        dtpDatumAngazovanja.Checked = true;
                        dtpDatumAngazovanja.Value = lice.Datum_pocetka_angazovanja.Value;
                    }
                    else
                    {
                        dtpDatumAngazovanja.Checked = false;
                    }
                    cmbPol.SelectedItem = lice.Pol.ToString();
                    cmbStanica.SelectedValue = lice.StanicaID ?? -1;

                    chbVatrogasac.Checked = (lice.FVatrogasac == 'T');
                    chbDispecer.Checked = (lice.FDispecer == 'T');
                    chbTehnicar.Checked = (lice.FTehnicar == 'T');

                    numSertifikat.Value = lice.Broj_sertifikata ?? 0;
                    txtStepenSpremnosti.Text = lice.Stepen_fizicke_spremnosti;
                    cmbNivoObucenosti.SelectedItem = lice.Nivo_obucenosti;
                    txtEvidencijaPoziva.Text = lice.Evidencija_poziva;
                    txtTipOpreme.Text = lice.Tip_opreme;
                    txtAlati.Text = lice.Podaci_o_alatima;
                    cmbSpecijalizacija.SelectedItem = lice.Specijalizacija;
                }
            }
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabPrikazLica.SelectedTab == tabVolonteri)
                {
                    if (string.IsNullOrWhiteSpace(txtMaticniBroj.Text))
                    {
                        MessageBox.Show("Maticni broj je obavezno polje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    VolonterBasic volonter = new VolonterBasic
                    {
                        MaticniBroj = txtMaticniBroj.Text,
                        LicnoIme = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        AdresaStanovanja = txtAdresa.Text,
                        EmailAdresa = txtEmail.Text,
                        DatumRodjenja = dtpDatumRodjenja.Value,
                        Pol = Convert.ToChar(cmbPol.SelectedItem),
                        IdVozila = (int?)cmbVoziloVolontera.SelectedValue
                    };
                    DTOManager.SacuvajVolontera(volonter);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtMaticniBroj.Text) || cmbStanica.SelectedIndex == -1)
                    {
                        MessageBox.Show("Maticni broj i stanica su obavezna polja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    AngazovanoLiceBasic lice = new AngazovanoLiceBasic
                    {
                        Maticni_broj = txtMaticniBroj.Text,
                        Licno_ime = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        Datum_rodjenja = dtpDatumRodjenja.Value,
                        Adresa_stanovanja = txtAdresa.Text,
                        Pol = Convert.ToChar(cmbPol.SelectedItem),
                        Email_adresa = txtEmail.Text,
                        Datum_pocetka_angazovanja = dtpDatumAngazovanja.Checked ? (DateTime?)dtpDatumAngazovanja.Value : null,
                        StanicaID = (int)cmbStanica.SelectedValue,
                        FVatrogasac = chbVatrogasac.Checked ? 'T' : 'F',
                        FDispecer = chbDispecer.Checked ? 'T' : 'F',
                        FTehnicar = chbTehnicar.Checked ? 'T' : 'F',
                        Broj_sertifikata = chbVatrogasac.Checked ? (int)numSertifikat.Value : (int?)null,
                        Stepen_fizicke_spremnosti = chbVatrogasac.Checked ? txtStepenSpremnosti.Text : null,
                        Nivo_obucenosti = chbVatrogasac.Checked ? cmbNivoObucenosti.SelectedItem?.ToString() : null,
                        Evidencija_poziva = chbDispecer.Checked ? txtEvidencijaPoziva.Text : null,
                        Tip_opreme = chbDispecer.Checked ? txtTipOpreme.Text : null,
                        Podaci_o_alatima = chbTehnicar.Checked ? txtAlati.Text : null,
                        Specijalizacija = chbTehnicar.Checked ? cmbSpecijalizacija.SelectedItem?.ToString() : null
                    };
                    DTOManager.SacuvajAngazovanoLice(lice);
                }

                MessageBox.Show("Uspešno ste dodali izabrano lice.", "Dodavanje uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopuniPodatke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja: {ex.InnerException?.Message ?? ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnObrisi_Click(object sender, EventArgs e)
        {
            ListView aktivnaLista = tabPrikazLica.SelectedTab.Controls.OfType<ListView>().FirstOrDefault();
            if (aktivnaLista == null || aktivnaLista.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite lice koje zelite da obrizete.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var poruka = MessageBox.Show("Da li ste sigurni da zelite da obrisete izabrano lice?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (poruka != DialogResult.Yes) return;

            try
            {
                int id = (int)aktivnaLista.SelectedItems[0].Tag;
                if (tabPrikazLica.SelectedTab == tabVolonteri)
                {
                    DTOManager.ObrisiVolontera(id);
                }
                else
                {
                    DTOManager.ObrisiAngazovanoLice(id);
                }

                MessageBox.Show("Uspesno ste obrisali izabrano lice.", "Brisanje uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopuniPodatke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom brisanja: {ex.InnerException?.Message ?? ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tabPrikazLica_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcistiPolja();

            if (tabPrikazLica.SelectedTab == tabVolonteri)
            {
                gbVolonter.Visible = true;
                gbVatrogasac.Visible = false;
                gbDispeceri.Visible = false;
                gbTehnicar.Visible = false;
                cmbStanica.Visible = false;
                labelaZaStanicu.Visible = false;
            }
            else
            {
                gbVolonter.Visible = false;
                cmbStanica.Visible = true;
                labelaZaStanicu.Visible = true;
                PrikaziPaneleNaOsnovuUloge();
            }

            btnBrojSmena.Visible = (tabPrikazLica.SelectedTab == tabDispeceri);
        }
        private void btnBrojSmena_Click(object sender, EventArgs e)
        {
            if (listViewDispeceri.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite dispecera iz liste.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idDispecera = (int)listViewDispeceri.SelectedItems[0].Tag;
            string ime = listViewDispeceri.SelectedItems[0].SubItems[2].Text; 
            string prezime = listViewDispeceri.SelectedItems[0].SubItems[3].Text; 

            BrojSmenaForma forma = new BrojSmenaForma(idDispecera, $"{ime} {prezime}");
            forma.ShowDialog();
        }
        private void btnTelefon_Click(object sender, EventArgs e)
        {
            ListView aktivnaLista = tabPrikazLica.SelectedTab.Controls.OfType<ListView>().FirstOrDefault();
            if (aktivnaLista == null || aktivnaLista.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite osobu iz liste da biste videli brojeve telefona.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idOsobe = (int)aktivnaLista.SelectedItems[0].Tag;
            bool jeVolonter = (aktivnaLista == listViewVolonteri);

            string ime = aktivnaLista.SelectedItems[0].SubItems[2].Text;
            string prezime = aktivnaLista.SelectedItems[0].SubItems[3].Text;
            string imeOsobe = $"{ime} {prezime}";

            TelefonForma forma = new TelefonForma(idOsobe, jeVolonter, imeOsobe);
            forma.ShowDialog();
        }
        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            ListView aktivnaLista = tabPrikazLica.SelectedTab.Controls.OfType<ListView>().FirstOrDefault();
            if (aktivnaLista == null || aktivnaLista.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite lice koje želite da izmenite.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int id = (int)aktivnaLista.SelectedItems[0].Tag;

                if (tabPrikazLica.SelectedTab == tabVolonteri)
                {
                    // Validacija za volontere
                    if (string.IsNullOrWhiteSpace(txtMaticniBroj.Text))
                    {
                        MessageBox.Show("Matični broj je obavezno polje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    VolonterBasic volonter = new VolonterBasic
                    {
                        Id = id,
                        MaticniBroj = txtMaticniBroj.Text,
                        LicnoIme = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        DatumRodjenja = dtpDatumRodjenja.Value,
                        AdresaStanovanja = txtAdresa.Text,
                        Pol = Convert.ToChar(cmbPol.SelectedItem),
                        EmailAdresa = txtEmail.Text,
                        IdVozila = (int?)cmbVoziloVolontera.SelectedValue
                    };
                    DTOManager.IzmeniVolontera(volonter);
                }
                else
                {
                    // Validacija za angažovana lica
                    if (string.IsNullOrWhiteSpace(txtMaticniBroj.Text) || cmbStanica.SelectedIndex == -1)
                    {
                        MessageBox.Show("Matični broj i stanica su obavezna polja.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    AngazovanoLiceBasic lice = new AngazovanoLiceBasic
                    {
                        ID = id,
                        Maticni_broj = txtMaticniBroj.Text,
                        Licno_ime = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        Datum_rodjenja = dtpDatumRodjenja.Value,
                        Adresa_stanovanja = txtAdresa.Text,
                        Pol = Convert.ToChar(cmbPol.SelectedItem),
                        Email_adresa = txtEmail.Text,
                        Datum_pocetka_angazovanja = dtpDatumAngazovanja.Checked ? (DateTime?)dtpDatumAngazovanja.Value : null,
                        StanicaID = (int)cmbStanica.SelectedValue,
                        FVatrogasac = chbVatrogasac.Checked ? 'T' : 'F',
                        FDispecer = chbDispecer.Checked ? 'T' : 'F',
                        FTehnicar = chbTehnicar.Checked ? 'T' : 'F',
                        Broj_sertifikata = chbVatrogasac.Checked ? (int)numSertifikat.Value : (int?)null,
                        Stepen_fizicke_spremnosti = chbVatrogasac.Checked ? txtStepenSpremnosti.Text : null,
                        Nivo_obucenosti = chbVatrogasac.Checked ? cmbNivoObucenosti.SelectedItem?.ToString() : null,
                        Evidencija_poziva = chbDispecer.Checked ? txtEvidencijaPoziva.Text : null,
                        Tip_opreme = chbDispecer.Checked ? txtTipOpreme.Text : null,
                        Podaci_o_alatima = chbTehnicar.Checked ? txtAlati.Text : null,
                        Specijalizacija = chbTehnicar.Checked ? cmbSpecijalizacija.SelectedItem?.ToString() : null
                    };
                    DTOManager.IzmeniAngazovanoLice(lice);
                }

                MessageBox.Show("Uspesno ste izmenili podatke.", "Izmena uspesna", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopuniPodatke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom izmene: {ex.InnerException?.Message ?? ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

