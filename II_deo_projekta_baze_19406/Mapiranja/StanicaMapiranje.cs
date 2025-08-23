using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Type;
using FluentNHibernate.Mapping;
using II_deo_projekta_baze_19406.Entiteti;

namespace II_deo_projekta_baze_19406.Mapiranja
{
    public class StanicaMapiranje : ClassMap<Entiteti.Stanica>
    {
        public StanicaMapiranje()
        {
            Table("STANICA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.PovrsinaObjekta, "POVRSINA_OBJEKTA");
            Map(x => x.Adresa, "ADRESA");
            Map(x => x.DostupnaInfrastruktura, "DOSTUPNA_INFRASTRUKTURA");
            Map(x => x.BrojZaposlenih, "BROJ_ZAPOSLENIH");
            Map(x => x.BrojVozila, "BROJ_VOZILA");
            References(x => x.Upravnik, "ID_UPRAVNIKA").LazyLoad();
            HasMany(x => x.Vozila).KeyColumn("ID_STANICE").LazyLoad().Cascade.All();
            HasMany(x => x.AngazovanaLica).KeyColumn("ID_STANICE").LazyLoad().Cascade.All();
            HasMany(x => x.Smene).KeyColumn("ID_STANICE").LazyLoad().Cascade.All();
        }
    }
}
