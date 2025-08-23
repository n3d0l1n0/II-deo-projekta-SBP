using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Entiteti
{
    public class Ponavljanje
    {
        public virtual int Id { get; set; }
        public virtual int BrojSmena { get; set; }
        public virtual string Mesec { get; set; }
        public virtual AngazovanoLice Dispecer { get; set; }
    }
}
