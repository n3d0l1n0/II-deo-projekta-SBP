using FluentNHibernate.Mapping;
using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Mapiranja
{
    public class ServisVozilaMapiranje : ClassMap<ServisVozila>
    {
        public ServisVozilaMapiranje()
        {
            Table("SERVIS_VOZILA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.StatusServisa, "STATUS");
            Map(x => x.DatumPocetka, "DATUM_POCETKA");
            Map(x => x.DatumKraja, "DATUM_KRAJA").Nullable();
            References(x => x.Vozilo, "ID_VOZILA");
        }
    }
}
