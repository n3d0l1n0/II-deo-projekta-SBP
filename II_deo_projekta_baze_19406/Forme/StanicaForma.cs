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
    public partial class StanicaForma : Form
    {

        public StanicaForma()
        {
            InitializeComponent();
        }
        private void listViewStanice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewStanice.SelectedItems.Count > 0)
            {
                StanicaPregled selektovanaStanicaPregled = (StanicaPregled)listViewStanice.SelectedItems[0].Tag;

                StanicaBasic stanicaZaIzmenu = DTOManager.VratiStanicu(selektovanaStanicaPregled.ID);
                txtNaziv.Text = stanicaZaIzmenu.Naziv;
                txtAdresa.Text = stanicaZaIzmenu.Adresa;
                txtPovrsina.Text = stanicaZaIzmenu.PovrsinaObjekta.ToString();
                txtInfrastruktura.Text = stanicaZaIzmenu.DostupnaInfrastruktura; 
                txtBrojZaposlenih.Text = stanicaZaIzmenu.BrojZaposlenih.ToString();
                txtBrojVozila.Text = stanicaZaIzmenu.BrojVozila.ToString();
                txtUpravnik.Text = stanicaZaIzmenu.UpravnikPrikaz;

                this.UcitajLicaIzStanice(selektovanaStanicaPregled.ID);
                this.UcitajVozilaIzStanice(selektovanaStanicaPregled.ID);
                this.OsveziPrikazUpravnika(selektovanaStanicaPregled.ID);
                btnUpravnik.Enabled = true;
            }
            else
            {
                this.ObrisiPodatkeOStanici();
                listViewLica.Items.Clear();
                listViewVozila.Items.Clear();
                txtUpravnik.Text = string.Empty;
                btnUpravnik.Enabled = false;
            }
        }
        private void OsveziPrikazUpravnika(int stanicaId)
        {
            AngazovanoLicePregled upravnik = DTOManager.VratiUpravnikaStanice(stanicaId);
            if (upravnik != null)
            {
                txtUpravnik.Text = $"{upravnik.Licno_ime} {upravnik.Prezime}";
            }
            else
            {
                txtUpravnik.Text = "Nema upravnika";
            }
        }
        private void UcitajLicaIzStanice(int stanicaId)
        {
            listViewLica.Items.Clear();
            try
            {
                List<AngazovanoLicePregled> lica = DTOManager.VratiSvaAngazovanaLicaIzStanice(stanicaId);

                foreach (AngazovanoLicePregled lice in lica)
                {
                    ListViewItem item = new ListViewItem(new string[] { lice.ID.ToString(), $"{lice.Licno_ime} {lice.Prezime}", lice.Email_adresa, lice.FVatrogasac.ToString(), lice.FDispecer.ToString(), lice.FTehnicar.ToString()});
                    listViewLica.Items.Add(item);
                }
                listViewLica.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom ucitavanja lica iz stanice: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UcitajVozilaIzStanice(int stanicaId)
        {
            listViewVozila.Items.Clear();
            try
            {
                List<VoziloPregled> vozila = DTOManager.VratiSvaVozilaIzStanice(stanicaId);

                foreach (VoziloPregled vozilo in vozila)
                {
                    ListViewItem item = new ListViewItem(new string[] { vozilo.Id.ToString(), vozilo.RegistarskaOznaka, vozilo.Proizvodjac});
                    listViewVozila.Items.Add(item);
                }
                listViewVozila.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom ucitavanja vozila iz stanice: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ObrisiPodatkeOStanici()
        {
            txtNaziv.Text = string.Empty;
            txtAdresa.Text = string.Empty;
            txtPovrsina.Text = string.Empty;
            txtInfrastruktura.Text = string.Empty;
            txtBrojZaposlenih.Text = string.Empty;
            txtBrojVozila.Text = string.Empty;
            txtUpravnik.Text = string.Empty;
            btnUpravnik.Enabled = false;
        }
        private void UcitajSveStanice()
        {
            listViewStanice.Items.Clear();
            listViewLica.Items.Clear();
            this.ObrisiPodatkeOStanici();
            try
            {
                List<StanicaPregled> stanice = DTOManager.VratiSveStanice();

                foreach (StanicaPregled st in stanice)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        st.ID.ToString(),
                        st.Naziv,
                        st.Adresa,
                        st.PovrsinaObjekta.ToString(),
                        st.DostupnaInfrastruktura,
                        st.BrojZaposlenih.ToString()
                    });

                    item.Tag = st;
                    listViewStanice.Items.Add(item);
                }
                listViewStanice.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom ucitavanja svih stanica: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (listViewStanice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, prvo izaberite stanicu koju zelite da izmenite.");
                return;
            }

            try
            {
                int idStanice = ((StanicaPregled)listViewStanice.SelectedItems[0].Tag).ID;

                StanicaBasic stanicaZaIzmenu = new StanicaBasic
                {
                    ID = idStanice,
                    Naziv = txtNaziv.Text,
                    Adresa = txtAdresa.Text,
                    PovrsinaObjekta = Double.Parse(txtPovrsina.Text),
                    DostupnaInfrastruktura = txtInfrastruktura.Text 
                };

                DTOManager.IzmeniStanicu(stanicaZaIzmenu);
                MessageBox.Show("Uspešno ste izmenili podatke o stanici!");
                listViewLica.Refresh();
                listViewVozila.Refresh();
                this.UcitajSveStanice();
            }
            catch (FormatException)
            {
                MessageBox.Show("Greska: Povrsina objekta mora biti validan broj.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom izmene stanice: {ex.Message}");
            }
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                StanicaBasic novaStanica = new StanicaBasic
                {
                    Naziv = txtNaziv.Text,
                    Adresa = txtAdresa.Text,
                    PovrsinaObjekta = Double.Parse(txtPovrsina.Text),
                    DostupnaInfrastruktura = txtInfrastruktura.Text
                };

                DTOManager.SacuvajStanicu(novaStanica);
                MessageBox.Show("Uspešno ste dodali novu stanicu!");
                listViewLica.Refresh();
                txtUpravnik.Text = string.Empty;
                listViewVozila.Refresh();
                this.UcitajSveStanice();
            }
            catch (FormatException)
            {
                MessageBox.Show("Greska: Povrsina objekta mora biti validan broj.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja stanice: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (listViewStanice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, prvo izaberite stanicu koju zelite da obrišete.");
                return;
            }

            DialogResult result = MessageBox.Show("Da li ste sigurni da zelite da obrišete izabranu stanicu?",
                                                   "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int idStanice = ((StanicaPregled)listViewStanice.SelectedItems[0].Tag).ID;
                    DTOManager.ObrisiStanicu(idStanice);
                    MessageBox.Show("Uspesno ste obrisali stanicu!");
                    listViewLica.Refresh();
                    txtUpravnik.Text = string.Empty;
                    listViewVozila.Refresh();
                    this.UcitajSveStanice();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greska prilikom brisanja stanice: {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Stanica_Load(object sender, EventArgs e)
        {
            this.UcitajSveStanice();
        }
        private void btnSmena_Click(object sender, EventArgs e)
        {
            if (listViewStanice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite stanicu za koju zelite da vidite smene.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

                StanicaPregled selektovanaStanica = (StanicaPregled)listViewStanice.SelectedItems[0].Tag;

                int idStanice = selektovanaStanica.ID;

                string nazivStanice = selektovanaStanica.Naziv; 

                SmenaForma smenaForma = new SmenaForma(idStanice, nazivStanice);
                smenaForma.ShowDialog();
        }
        private void btnUpravnik_Click(object sender, EventArgs e)
        {
            if (listViewStanice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Molimo vas, izaberite stanicu da biste uredili upravnika.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StanicaPregled selektovanaStanica = (StanicaPregled)listViewStanice.SelectedItems[0].Tag;
            int stanicaId = selektovanaStanica.ID;
            string nazivStanice = selektovanaStanica.Naziv;

            UpravnikForma forma = new UpravnikForma(stanicaId, nazivStanice);
            forma.ShowDialog();

            OsveziPrikazUpravnika(stanicaId);
        }
    }
}
