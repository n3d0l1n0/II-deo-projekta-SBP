using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Entiteti
{
    public class ServisVozila
    {
        public virtual int Id { get; protected set; }
        public virtual string StatusServisa { get; set; }
        public virtual DateTime DatumPocetka { get; set; }
        public virtual DateTime? DatumKraja { get; set; }
        public virtual Vozilo Vozilo { get; set; }
    }
}
