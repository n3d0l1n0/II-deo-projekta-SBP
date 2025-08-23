using FluentNHibernate.Mapping;
using II_deo_projekta_baze_19406.Entiteti;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Mapiranja
{
    public class IntervencijaMapiranje : ClassMap<Entiteti.Intervencija>
    {
        public IntervencijaMapiranje()
        {
            Table("INTERVENCIJA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.BrojIntervencije, "BROJ_INTERVENCIJE").Unique();
            Map(x => x.OpisSituacije, "OPIS_SITUACIJE");
            Map(x => x.Datum, "DATUM");
            Map(x => x.VremeOd, "VREME_OD");
            Map(x => x.VremeDo, "VREME_DO");
            Map(x => x.VremeDolaska, "VREME_DOLASKA");
            Map(x => x.TipIntervencije, "TIP_INTERVENCIJE");
            Map(x => x.AdresaLokacije, "ADRESA_LOKACIJE");
            References(x => x.Dispecer, "ID_DISPECERA");
            References(x => x.Status, "ID_STATUSA_INTERVENCIJE").Unique().Cascade.All();
            HasMany(x => x.AngazovaniVatrogasciNaIntervenciji).KeyColumn("ID_INTERVENCIJE").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.UpotrebljeniResursi).KeyColumn("ID_INTERVENCIJE").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.UcesniciNaIntervenciji).KeyColumn("ID_INTERVENCIJE").LazyLoad().Inverse();
        }
    }
}
