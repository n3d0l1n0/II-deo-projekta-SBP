using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Entiteti
{
    public class UpotrebljenoUIntervenciji
    {
        public virtual int Id { get; protected set; }
        public virtual Intervencija NaIntervenciji { get; set; }
        public virtual Vozilo UpotrebljenoVozilo { get; set; }
        public virtual Oprema UpotrebljenaOprema { get; set; }
    }
}
