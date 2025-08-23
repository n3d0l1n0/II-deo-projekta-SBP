using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Entiteti
{
    public class AngazovanVatrogasac
    {
        public virtual int Id { get; protected set; }
        public virtual Intervencija PripadaIntervenciji { get; set; }
        public virtual AngazovanoLice AngazovaniVatrogasacLice { get; set; }
    }
}
