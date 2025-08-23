using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Entiteti
{
    public class RadiUSmeni
    {
        public virtual int Id { get; protected set; }
        public virtual Smena Smena { get; set; }
        public virtual AngazovanoLice Radnik { get; set; }
    }
}
