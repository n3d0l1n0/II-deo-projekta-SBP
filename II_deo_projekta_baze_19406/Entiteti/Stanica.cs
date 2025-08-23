using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Entiteti
{
    public class Stanica
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual double? PovrsinaObjekta { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string DostupnaInfrastruktura { get; set; }
        public virtual int BrojZaposlenih { get; set; }
        public virtual int BrojVozila { get; set; }
        public virtual AngazovanoLice Upravnik { get; set; }
        public virtual IList<Vozilo> Vozila { get; set; }
        public virtual IList<AngazovanoLice> AngazovanaLica { get; set; }
        public virtual IList<Smena> Smene { get; set; }

        public Stanica()
        {
            Vozila= new List<Vozilo>();
            AngazovanaLica = new List<AngazovanoLice>();
            Smene = new List<Smena>();
        }
    }
}
