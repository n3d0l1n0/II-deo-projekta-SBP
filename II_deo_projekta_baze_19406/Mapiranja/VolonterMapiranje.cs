using FluentNHibernate.Mapping;
using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Mapiranja
{
    public class VolonterMapiranje : ClassMap<Volonter>
    {
        public VolonterMapiranje()
        {
            Table("VOLONTER");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.MaticniBroj, "MATICNI_BROJ");
            Map(x => x.LicnoIme, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.DatumRodjenja, "DATUM_RODJENJA");
            Map(x => x.AdresaStanovanja, "ADRESA_STANOVANJA");
            Map(x => x.Pol, "POL");
            Map(x => x.EmailAdresa, "EMAIL");
            References(x => x.PripadaVozilu, "ID_VOZILA").Nullable();
            HasMany(x => x.Telefoni).KeyColumn("ID_VOLONTERA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
