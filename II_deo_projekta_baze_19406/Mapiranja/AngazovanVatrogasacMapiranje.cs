using FluentNHibernate.Mapping;
using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Mapiranja
{
    public class AngazovanVatrogasacMapiranje : ClassMap<AngazovanVatrogasac>
    {
        public AngazovanVatrogasacMapiranje()
        {
            Table("ANGAZOVAN_VATROGASAC");
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            References(x => x.PripadaIntervenciji, "ID_INTERVENCIJE");
            References(x => x.AngazovaniVatrogasacLice, "ID_VATROGASCA");
        }
    }
}
