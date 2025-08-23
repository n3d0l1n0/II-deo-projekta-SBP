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
    public partial class BrojSmenaForma : Form
    {
        public BrojSmenaForma()
        {
            InitializeComponent();
        }
        private int idDispecera;
        public BrojSmenaForma(int idDispecera, string imePrezime)
        {
            InitializeComponent();
            this.idDispecera = idDispecera;
            this.Text = $"Broj smena po mesecima za: {imePrezime}";
        }
        private void BrojSmenaForma_Load(object sender, EventArgs e)
        {
            PopuniPodatke();
        }
        private void PopuniPodatke()
        {
            listViewPonavljanja.Items.Clear();
            List<PonavljanjePregled> podaci = DTOManager.VratiPonavljanjaZaDispecera(this.idDispecera);

            foreach (var p in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { p.Mesec, p.BrojSmena.ToString() });
                item.Tag = p.Id;
                listViewPonavljanja.Items.Add(item);
            }
            listViewPonavljanja.Refresh();
        }
        private void btnZatvori_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
