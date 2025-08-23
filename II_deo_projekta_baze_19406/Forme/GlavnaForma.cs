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

namespace II_deo_projekta_baze_19406
{
    public partial class GlavnaForma : Form
    {
        public GlavnaForma()
        {
            InitializeComponent();
        }
        private void btnOtvoriStanice_Click(object sender, EventArgs e)
        {
            StanicaForma formaStanica = new StanicaForma();
            formaStanica.ShowDialog();
        }
        private void btnZaposleni_Click(object sender, EventArgs e)
        {
            AngazovanoLiceForma angazovanForma = new AngazovanoLiceForma();
            angazovanForma.ShowDialog();
        }
        private void btnOprema_Click(object sender, EventArgs e)
        {
            OpremaForma formaOprema = new OpremaForma();
            formaOprema.ShowDialog();
        }
        private void btnIntervencija_Click(object sender, EventArgs e)
        {
            IntervencijaForma formaIntervencija = new IntervencijaForma();
            formaIntervencija.ShowDialog();
        }
        private void btnVozila_Click(object sender, EventArgs e)
        {
            VoziloForma formaVozilo = new VoziloForma();
            formaVozilo.ShowDialog();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void GlavnaForma_Load(object sender, EventArgs e)
        {

        }
    }
}
