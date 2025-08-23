using FluentNHibernate.Mapping;
using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Mapiranja
{
    public class SmenaMapiranje : ClassMap<Smena>
    {
        public SmenaMapiranje()
        {
            Table("SMENA");
            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();
            Map(x => x.Datum).Column("DATUM");
            Map(x => x.VremePocetka).Column("VREME_POCETKA");
            Map(x => x.VremeKraja).Column("VREME_KRAJA");
            References(x => x.Stanica).Column("ID_STANICE");
            HasMany(x => x.AngazovaniRadnici).KeyColumn("ID_SMENE").LazyLoad().Cascade.AllDeleteOrphan().Inverse();
            HasMany(x => x.UcescaIzSmene).KeyColumn("ID_SMENE").LazyLoad().Cascade.AllDeleteOrphan().Inverse();
        }
    }
}
