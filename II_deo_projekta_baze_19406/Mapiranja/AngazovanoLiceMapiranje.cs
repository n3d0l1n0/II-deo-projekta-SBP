using FluentNHibernate.Mapping;
using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Mapiranja
{
    public class AngazovanoLiceMapiranje : ClassMap<AngazovanoLice>
    {
        public AngazovanoLiceMapiranje()
        {
            Table("ANGAZOVANO_LICE");
            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();
            Map(x => x.MaticniBroj).Column("MATICNI_BROJ").Unique();
            Map(x => x.LicnoIme).Column("IME");
            Map(x => x.Prezime).Column("PREZIME");
            Map(x => x.DatumRodjenja).Column("DATUM_RODJENJA");
            Map(x => x.AdresaStanovanja).Column("ADRESA_STANOVANJA");
            Map(x => x.Pol).Column("POL");
            Map(x => x.EmailAdresa).Column("EMAIL");
            Map(x => x.DatumPocetkaAngazovanja).Column("DATUM_POC_ANGAZ");
            Map(x => x.FVatrogasac).Column("FVATROGASAC");
            Map(x => x.BrojSertifikata).Column("BROJ_SERTIFIKATA");
            Map(x => x.BrojOperativnihIntervencija).Column("BROJ_OPERATIVNIH_INTERVENCIJA");
            Map(x => x.StepenFizickeSpremnosti).Column("STEPEN_FIZICKE_SPREMNOSTI");
            Map(x => x.NivoObucenosti).Column("NIVO_OBUCENOSTI");
            Map(x => x.FDispecer).Column("FDISPECER");
            Map(x => x.EvidencijaPoziva).Column("EVIDENCIJA_POZIVA");
            Map(x => x.TipOpreme).Column("TIP_OPREME");
            Map(x => x.FTehnicar).Column("FTEHNICAR");
            Map(x => x.PodaciOAlatima).Column("PODACI_O_ALATIMA");
            Map(x => x.Specijalizacija).Column("SPECIJALIZACIJA");
            References(x => x.Stanica).Column("ID_STANICE").Nullable();
            HasMany(x => x.AngazmaniNaIntervencijama).KeyColumn("ID_VATROGASCA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.OdrzavanjaKojaObavlja).KeyColumn("ID_TEHNICARA") .LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.RadUSmenama).KeyColumn("ID_LICA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.StaniceKojeUpravlja).KeyColumn("ID_UPRAVNIKA").LazyLoad();
            HasMany(x => x.UcescaNaIntervencijama).KeyColumn("ID_VATROGASCA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Telefoni).KeyColumn("ID_LICA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
