using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Entiteti
{
    public class Intervencija
    {
        public virtual int Id { get; protected set; }
        public virtual int BrojIntervencije { get; set; }
        public virtual string OpisSituacije { get; set; }
        public virtual DateTime Datum { get; set; }
        public virtual DateTime VremeOd { get; set; }
        public virtual DateTime VremeDo { get; set; }
        public virtual DateTime VremeDolaska { get; set; }
        public virtual string TipIntervencije { get; set; }
        public virtual string AdresaLokacije { get; set; }
        public virtual AngazovanoLice Dispecer { get; set; }
        public virtual StatusIntervencije Status { get; set; }
        public virtual IList<AngazovanVatrogasac> AngazovaniVatrogasciNaIntervenciji { get; set; }
        public virtual IList<UpotrebljenoUIntervenciji> UpotrebljeniResursi { get; set; }
        public virtual IList<Ucestvuje> UcesniciNaIntervenciji { get; set; }

        public Intervencija()
        {
            AngazovaniVatrogasciNaIntervenciji = new List<AngazovanVatrogasac>();
            UpotrebljeniResursi = new List<UpotrebljenoUIntervenciji>();
            UcesniciNaIntervenciji = new List<Ucestvuje>();
        }
    }
}
