using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Entiteti
{
    public class Smena
    {
        public virtual int Id { get; set; }
        public virtual DateTime Datum { get; set; }
        public virtual DateTime VremePocetka { get; set; }
        public virtual DateTime VremeKraja { get; set; }
        public virtual Stanica Stanica { get; set; }
        public virtual IList<RadiUSmeni> AngazovaniRadnici { get; set; }
        public virtual IList<Ucestvuje> UcescaIzSmene { get; set; }

        public Smena()
        {
            UcescaIzSmene = new List<Ucestvuje>();
            AngazovaniRadnici = new List<RadiUSmeni>();
        }
    }
}
