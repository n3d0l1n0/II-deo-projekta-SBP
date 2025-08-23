using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using II_deo_projekta_baze_19406.Entiteti;

namespace II_deo_projekta_baze_19406.Mapiranja
{
    public class VoziloMapiranje : ClassMap<Vozilo>
    {
        public VoziloMapiranje()
        {
            Table("VOZILO");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.RegistarskaOznaka, "REGISTARSKA_OZNAKA").Unique();
            Map(x => x.Kapacitet, "KAPACITET");
            Map(x => x.Proizvodjac, "PROIZVODJAC");
            Map(x => x.GodinaProizvodnje, "GODINA_PROIZVODNJE");
            Map(x => x.DatumPoslednjegPregleda, "DATUM_POSLEDNJEG_PREGLEDA");
            Map(x => x.DatumIstekaRegistracije, "DATUM_ISTEKA_REGISTRACIJE");
            Map(x => x.StatusVozila, "STATUS_VOZILA");
            Map(x => x.FVatrogasno, "FVATROGASNO");
            Map(x => x.TipVatrogasno, "TIP_VATROGASNO");
            Map(x => x.FSpasilacko, "FSPASILACKO");
            Map(x => x.TipSpasilacko, "TIP_SPASILACKO");
            Map(x => x.FTehnickaPodrska, "FTEHNICKA_PODRSKA");
            Map(x => x.TipTehnickaPodrska, "TIP_TEHNICKA_PODRSKA");
            References(x => x.PripadaStanici, "ID_STANICE");
            HasMany(x => x.Servisi).KeyColumn("ID_VOZILA").LazyLoad().Cascade.AllDeleteOrphan().Inverse();
            HasMany(x => x.OpremaNaVozilu).KeyColumn("ID_VOZILA").LazyLoad().Inverse();
            HasMany(x => x.Sertifikati).KeyColumn("ID_VOZILA").LazyLoad().Cascade.AllDeleteOrphan().Inverse();
            HasMany(x => x.UpotrebaUIntervencijama).KeyColumn("ID_VOZILA").LazyLoad().Inverse();
            HasMany(x => x.Odrzavanja).KeyColumn("ID_VOZILA").LazyLoad().Cascade.AllDeleteOrphan() .Inverse();
            HasMany(x => x.VolonteriSaVozilom).KeyColumn("ID_VOZILA").LazyLoad().Inverse();
        }
    }
}
