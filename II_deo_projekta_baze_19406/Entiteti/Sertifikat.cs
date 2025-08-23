using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Entiteti
{
    public class Sertifikat
    {
        public virtual int Id { get; protected set; }
        public virtual string NazivSertifikata { get; set; }
        public virtual Vozilo PripadaVozilu { get; set; }
    }

}
