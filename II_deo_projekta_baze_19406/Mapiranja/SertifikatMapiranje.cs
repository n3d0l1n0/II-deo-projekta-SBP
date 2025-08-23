using FluentNHibernate.Mapping;
using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Mapiranja
{
    public class SertifikatMapiranje : ClassMap<Sertifikat>
    {
        public SertifikatMapiranje()
        {
            Table("SERTIFIKAT");
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.NazivSertifikata, "SERTIFIKAT");
            References(x => x.PripadaVozilu, "ID_VOZILA");
        }
    }
}
