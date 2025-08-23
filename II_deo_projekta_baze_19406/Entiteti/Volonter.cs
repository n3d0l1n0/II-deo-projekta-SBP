using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Entiteti
{
    public class Volonter
    {
        public virtual int Id { get; set; }
        public virtual string MaticniBroj { get; set; }
        public virtual string LicnoIme { get; set; }
        public virtual string Prezime { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string AdresaStanovanja { get; set; }
        public virtual char Pol { get; set; }
        public virtual string EmailAdresa { get; set; }
        public virtual Vozilo PripadaVozilu { get; set; }
        public virtual IList<Telefon> Telefoni { get; set; }

        public Volonter()
        {
            Telefoni = new List<Telefon>();
        }
    }

}
