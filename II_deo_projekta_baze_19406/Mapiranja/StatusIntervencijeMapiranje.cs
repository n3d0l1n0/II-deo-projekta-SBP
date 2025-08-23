using FluentNHibernate.Mapping;
using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Mapiranja
{
    public class StatusIntervencijeMapiranje : ClassMap<StatusIntervencije>
    {
        public StatusIntervencijeMapiranje()
        {
            Table("STATUS_INTERVENCIJE");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.Vreme, "VREME");
            Map(x => x.Datum, "DATUM");
            Map(x => x.StanjeIntervencije, "STANJE_INTERVENCIJE");
        }
    }
}