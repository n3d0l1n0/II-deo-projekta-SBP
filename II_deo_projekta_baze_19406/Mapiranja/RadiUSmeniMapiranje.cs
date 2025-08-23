using FluentNHibernate.Mapping;
using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Mapiranja
{
    public class RadiUSmeniMapiranje : ClassMap<RadiUSmeni>
    {
        public RadiUSmeniMapiranje()
        {
            Table("RADI_U_SMENI");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            References(x => x.Smena, "ID_SMENE");
            References(x => x.Radnik, "ID_LICA");
        }
    }
}
