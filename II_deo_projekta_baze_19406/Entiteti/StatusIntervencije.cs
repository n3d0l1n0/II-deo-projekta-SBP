using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Entiteti
{
    public class StatusIntervencije
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime Vreme { get; set; }
        public virtual DateTime Datum { get; set; }
        public virtual string StanjeIntervencije { get; set; }
        public virtual IList<Intervencija> Intervencije { get; set; }

        public StatusIntervencije()
        {
            Intervencije = new List<Intervencija>();
        }
    }
}
