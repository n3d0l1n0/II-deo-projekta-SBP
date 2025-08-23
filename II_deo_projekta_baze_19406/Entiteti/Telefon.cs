using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Entiteti
{
    public class Telefon
    {
        public virtual int Id { get; protected set; }
        public virtual string BrojTelefona { get; set; }
        public virtual AngazovanoLice PripadaLicu { get; set; }
        public virtual Volonter PripadaVolonteru { get; set; }
    }
}
