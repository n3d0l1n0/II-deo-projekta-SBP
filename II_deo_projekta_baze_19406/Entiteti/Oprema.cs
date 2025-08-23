using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Entiteti
{
    public class Oprema
    {
        public virtual int Id { get; protected set; }
        public virtual string InventarskiBroj { get; set; }
        public virtual DateTime DatumNabavke { get; set; }
        public virtual string StatusOpreme { get; set; }
        public virtual char? FZastitna { get; set; }
        public virtual string TipZastitna { get; set; }
        public virtual char? FZaPozare { get; set; }
        public virtual string TipZaPozare { get; set; }
        public virtual char? FSpecijalna { get; set; }
        public virtual string TipSpecijalna { get; set; }
        public virtual char? FTehnicka { get; set; }
        public virtual string TipTehnicka { get; set; }
        public virtual Vozilo PripadaVozilu { get; set; }
        public virtual Stanica PripadaStanici { get; set; }
        public virtual AngazovanoLice PripadaLicu { get; set; }
        public virtual IList<UpotrebljenoUIntervenciji> UpotrebaUIntervencijama { get; set; }

        public Oprema()
        {
            UpotrebaUIntervencijama = new List<UpotrebljenoUIntervenciji>();

        }
    }
}
