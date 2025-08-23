using FluentNHibernate.Mapping;
using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Mapiranja
{
    public class UcestvujeMapiranje : ClassMap<Ucestvuje>
    {
        public UcestvujeMapiranje()
        {
            Table("UCESTVUJE");
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            References(x => x.Vatrogasac, "ID_VATROGASCA");
            References(x => x.Smena, "ID_SMENE");
            References(x => x.Intervencija, "ID_INTERVENCIJE");
        }
    }
}
