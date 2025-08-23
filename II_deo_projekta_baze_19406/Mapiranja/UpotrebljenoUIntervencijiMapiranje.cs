using FluentNHibernate.Mapping;
using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Mapiranja
{
    public class UpotrebljenoUIntervencijiMapiranje : ClassMap<UpotrebljenoUIntervenciji>
    {
        public UpotrebljenoUIntervencijiMapiranje()
        {
            Table("UPOTREBLJENO_U_INTERVENCIJI");
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            References(x => x.NaIntervenciji, "ID_INTERVENCIJE");
            References(x => x.UpotrebljenoVozilo, "ID_VOZILA").Nullable();
            References(x => x.UpotrebljenaOprema, "ID_OPREME").Nullable();
        }
    }
}
