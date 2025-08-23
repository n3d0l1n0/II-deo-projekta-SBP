using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Entiteti
{
    public class Vozilo
    {
        public virtual int Id { get; protected set; }
        public virtual string RegistarskaOznaka { get; set; }
        public virtual int? Kapacitet { get; set; }
        public virtual string Proizvodjac { get; set; }
        public virtual int? GodinaProizvodnje { get; set; }
        public virtual DateTime? DatumPoslednjegPregleda { get; set; }
        public virtual DateTime? DatumIstekaRegistracije { get; set; }
        public virtual string StatusVozila { get; set; }
        public virtual char? FVatrogasno { get; set; }
        public virtual string TipVatrogasno { get; set; }
        public virtual char? FSpasilacko { get; set; }
        public virtual string TipSpasilacko { get; set; }
        public virtual char? FTehnickaPodrska { get; set; }
        public virtual string TipTehnickaPodrska { get; set; }
        public virtual Stanica PripadaStanici { get; set; }
        public virtual IList<ServisVozila> Servisi { get; set; }
        public virtual IList<Oprema> OpremaNaVozilu { get; set; }
        public virtual IList<Sertifikat> Sertifikati { get; set; }
        public virtual IList<Odrzavanje> Odrzavanja { get; set; }
        public virtual IList<Volonter> VolonteriSaVozilom { get; set; }
        public virtual IList<UpotrebljenoUIntervenciji> UpotrebaUIntervencijama { get; set; }

        public Vozilo()
        {
            Servisi = new List<ServisVozila>();
            OpremaNaVozilu = new List<Oprema>();
            Sertifikati = new List<Sertifikat>();
            UpotrebaUIntervencijama = new List<UpotrebljenoUIntervenciji>();
            Odrzavanja = new List<Odrzavanje>();
            VolonteriSaVozilom = new List<Volonter>();
        }
    }
}
