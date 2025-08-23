using FluentNHibernate.Mapping;
using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Mapiranja
{
    public class TelefonMapiranje : ClassMap<Telefon>
    {
        public TelefonMapiranje()
        {
            Table("TELEFON");
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.BrojTelefona, "TELEFON");
            References(x => x.PripadaLicu, "ID_LICA").Nullable();
            References(x => x.PripadaVolonteru, "ID_VOLONTERA").Nullable();
        }
    }
}
